package com.example.modb;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URI;
import java.util.Calendar;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Set;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.location.Location;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

public class BlueToothCoreActivity extends Activity implements OnClickListener {
	BluetoothAdapter blueToothAdapter;
	Set<BlueToothDevice> scannedDevices = new HashSet<BlueToothDevice>();
	Button startScanButton;
	Button addDeviceButton;
	Button postResultsButton;

	ArrayAdapter<String> devicesAdapter;

	boolean autoScan = true;
	boolean enableTableDisplay = true;

	Location deviceLocation;
	Location previousLocation;
	float previousDistanceToDevice;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_INDETERMINATE_PROGRESS);

		devicesAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item);
	}

	void setAutoScan(boolean value) {
		autoScan = value;
	}

	void enableTableDisplay(boolean value) {
		enableTableDisplay = value;
	}

	public void initializeView() {
		IntentFilter actionFoundFilter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
		this.registerReceiver(mReceiver, actionFoundFilter);

		IntentFilter discoveryFinishedIntend = new IntentFilter(BluetoothAdapter.ACTION_DISCOVERY_FINISHED);
		this.registerReceiver(mReceiver, discoveryFinishedIntend);
	}

	public void onClick(View view) {
		try {
			if (view == startScanButton) {
				startBluetoothDeviceDiscovery();
			} else if (view == addDeviceButton) {
				String deviceName = ((EditText) findViewById(R.id.deviceNameTextView)).getText().toString();
				String deviceMac = ((EditText) findViewById(R.id.macAddressTextView)).getText().toString();
				int rssi = Integer.parseInt(((EditText) findViewById(R.id.rssiTextView)).getText().toString());
				addDevice(deviceName, deviceMac, rssi);
			} else if (view == postResultsButton) {
				updateDeviceDetailsToRemoteServer();
			}
		} catch (Exception e) {
			Toast.makeText(this, e.getMessage() + e.getStackTrace(), Toast.LENGTH_LONG).show();
		}
	}

	void startBluetoothDeviceDiscovery() {
		blueToothAdapter = BluetoothAdapter.getDefaultAdapter();

		if (blueToothAdapter == null) {
			Log.d("debug", "No bluetooth available.");
		} else {
			Log.d("debug", "Bluetooth available. Success!");

			if (!blueToothAdapter.isEnabled()) {
				Log.d("debug", "Not enabled. Requesting to start.");
				Intent enableBlueToothIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
				startActivityForResult(enableBlueToothIntent, 1);
			} else {
				Log.d("debug", "Bluetooth Enabled.");
			}
			Toast.makeText(this, "Starting Discovery...", Toast.LENGTH_LONG).show();
			blueToothAdapter.startDiscovery();
			BlueToothCoreActivity.this.setProgressBarIndeterminateVisibility(true);
		}
	}

	@Override
	public void onDestroy() {
		super.onDestroy();
		this.unregisterReceiver(mReceiver);
	}

	private void addDevice(String name, String address, int rssi) {
		BlueToothDevice device = new BlueToothDevice();
		device.Name = name;
		device.MacAddress = address;
		device.Date = Utils.GetDate();
		device.Rssi = rssi;

		if (devicesAdapter.getPosition(name + " ==> " + address) < 0) {
			devicesAdapter.add(name + " ==> " + address);
			devicesAdapter.notifyDataSetChanged();
		}

		scannedDevices.add(device);		

		if (enableTableDisplay) {
			TableLayout tl = (TableLayout) this.findViewById(R.id.bluetoothDevicesTable);

			TableRow tr = new TableRow(this);
			tr.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));

			//TextView timeTextView = new TextView(this);
			//timeTextView.setText(device.Date);
			//tr.addView(timeTextView);

			TextView deviceNameTextView = new TextView(this);
			deviceNameTextView.setText(device.Name);
			tr.addView(deviceNameTextView);

			TextView macAddressTextView = new TextView(this);
			macAddressTextView.setText(device.MacAddress);
			tr.addView(macAddressTextView);

			TextView rssiTextView = new TextView(this);
			rssiTextView.setText(device.Rssi + "");
			tr.addView(rssiTextView);

			tl.addView(tr, new TableLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		}
	}
	
	void processScannedResult(){
		
	}

	private void updateDeviceDetailsToRemoteServer() {
		try {
			StringBuffer buffer = new StringBuffer();
			SharedPreferences sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);

			buffer.append("[");

			for (BlueToothDevice device : scannedDevices) {
				JSONObject child = new JSONObject();
				child.accumulate("SensorId", sharedpreferences.getString("APN", ""));
				child.accumulate("DeviceId", device.MacAddress);
				child.accumulate("DeviceName", device.Name);
				child.accumulate("Rssi", device.Rssi);
				child.accumulate("TimeStamp", device.Date);
				child.accumulate("Lattitude", device.Lattitude);
				child.accumulate("Longtitude", device.Longtitude);
				child.accumulate("DistanceFromDevice", device.DistanceFromDevice);

				buffer.append(child.toString()).append(",");
			}

			buffer.deleteCharAt(buffer.length() - 1);
			buffer.append("]");

			String urlSetting = sharedpreferences.getString("URL", "");
			String portSetting = sharedpreferences.getString("Port", "");
			String url = urlSetting + ":" + portSetting + "/location";
			Toast.makeText(this, "Posting Scan Results to: " + url, Toast.LENGTH_LONG).show();

			new HttpPostTask().execute(url, buffer.toString());
			scannedDevices.clear();
			TableLayout tl = (TableLayout) this.findViewById(R.id.bluetoothDevicesTable);
			tl.removeAllViews();
		} catch (Exception ex) {
			Toast.makeText(this, "Error Posting Scan Results to: " + ex.getMessage(), Toast.LENGTH_LONG).show();
		}
	}

	private final BroadcastReceiver mReceiver = new BroadcastReceiver() {
		public void onReceive(Context context, Intent intent) {
			String action = intent.getAction();
			if (BluetoothDevice.ACTION_FOUND.equals(action)) {
				// Get the BluetoothDevice object from the Intent
				Log.d("debug", "Bluetooth Device Found.");
				BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);

				short rssi = intent.getShortExtra(BluetoothDevice.EXTRA_RSSI, Short.MIN_VALUE);

				Log.d("debug", device.getName() + ":" + device.getAddress() + ":" + rssi);

				addDevice(device.getName(), device.getAddress(), rssi);

			} else if (BluetoothAdapter.ACTION_DISCOVERY_FINISHED.equals(action)) {
				Log.d("debug", "Scan Finished");
				Toast.makeText(BlueToothCoreActivity.this, "Discovery Completed...", Toast.LENGTH_LONG).show();
				BlueToothCoreActivity.this.setProgressBarIndeterminateVisibility(false);
				if(enableTableDisplay){
					updateDeviceDetailsToRemoteServer();
				} else {
					processScannedResult();
				}
				
				if (autoScan) {		
					blueToothAdapter.startDiscovery();
					BlueToothCoreActivity.this.setProgressBarIndeterminateVisibility(true);
					Toast.makeText(BlueToothCoreActivity.this, "Starting Discovery...", Toast.LENGTH_LONG).show();
				} 
			} else {
				Log.d("Sp,e other intend recieved", "Scan Finished");
			}
		}
	};

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == 1) {
			Log.d("debug", "Response Received for BlueTooth start intent:" + resultCode);
			if (resultCode == android.app.Activity.RESULT_OK) {
				Log.d("debug", "Bluetooth Enabled");
			} else {
				Log.d("debug", "Bluetooth Not Enabled. Cancelled.");
			}
		}
	}

	private void queryPairedDevices() {
		BluetoothAdapter blueToothAdapter = BluetoothAdapter.getDefaultAdapter();
		Set<BluetoothDevice> pairedDevices = blueToothAdapter.getBondedDevices();
		// If there are paired devices
		if (pairedDevices.size() > 0) {
			// Loop through paired devices
			Log.d("debug", "No Paired Devices:" + pairedDevices.size());
			for (BluetoothDevice device : pairedDevices) {
				Log.d("debug", device.getName() + ":" + device.getAddress());
				// Add the name and address to an array adapter to show in a
				// ListView
				// mArrayAdapter.add(device.getName() + "\n" +
				// device.getAddress());
			}
		} else {
			Log.d("debug", "No Paired Devices");
		}
	}

	private class HttpPostTask extends AsyncTask<String, Void, String> {

		@Override
		protected String doInBackground(String... info) {
			String result = "";
			BufferedReader reader;
			try {

				HttpClient httpClient = new DefaultHttpClient();
				HttpPost request = new HttpPost();
				request.setURI(new URI(info[0]));

				StringEntity se = new StringEntity(info[1]);
				request.setEntity(se);

				request.setHeader("Content-type", "application/json");
				HttpResponse response = httpClient.execute(request);

				reader = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));

				StringBuffer buffer = new StringBuffer();
				String line = "";

				while ((line = reader.readLine()) != null) {
					buffer.append(line);
				}

				result = buffer.toString();

			} catch (Exception e) {
				result = e.getMessage() + "-" + e.getStackTrace();
				// Toast.makeText(BlueToothAPActivity.this, result,
				// Toast.LENGTH_LONG).show();
			}

			return result;
		}

		protected void onPreExecute() {
			BlueToothCoreActivity.this.setProgressBarIndeterminateVisibility(true);
		}

		protected void onPostExecute(String result) {
			BlueToothCoreActivity.this.setProgressBarIndeterminateVisibility(false);
			Toast.makeText(BlueToothCoreActivity.this, result, Toast.LENGTH_LONG).show();
		}
	}
}
