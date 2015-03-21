package com.example.modb;

import java.util.Set;

import android.app.ActionBar;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.widget.CheckBox;
import android.widget.ImageButton;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

public class BlueToothDevicesListFragment extends Fragment {
	BluetoothAdapter blueToothAdapter;
	View view;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		view = inflater.inflate(R.layout.bluetooth_devices, container,
				false);	
		

		// Register the BroadcastReceiver
		IntentFilter filter = new IntentFilter(BluetoothDevice.ACTION_FOUND);
		getActivity().registerReceiver(mReceiver, filter);
		// Don't forget to unregister during onDestroy

		IntentFilter filter2 = new IntentFilter(
				BluetoothAdapter.ACTION_DISCOVERY_FINISHED);
		getActivity().registerReceiver(mReceiver, filter2); // Don't forget to
															// unregister during
															// onDestroy
		queryPairedDevices();
		blueToothAdapter = BluetoothAdapter.getDefaultAdapter();

		if (blueToothAdapter == null) {
			Log.d("debug", "No bluetooth available.");
		} else {
			Log.d("debug", "Bluetooth available. Success!");

			if (!blueToothAdapter.isEnabled()) {
				Log.d("debug", "Not enabled. Requesting to start.");
				Intent enableBlueToothIntent = new Intent(
						BluetoothAdapter.ACTION_REQUEST_ENABLE);
				startActivityForResult(enableBlueToothIntent, 1);
				blueToothAdapter.startDiscovery();
			} else {
				Log.d("debug", "Bluetooth Enabled.");
			}
			blueToothAdapter.startDiscovery();
		}

		

		return view;
	}
	
	public void addDevice(String name, String address, String rssi){
		TableLayout tl = (TableLayout) view.getRootView().findViewById(R.id.bluetoothDevicesTable);

        
            // Make TR
            TableRow tr = new TableRow(getActivity());
            tr.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));

            // Make TV to hold the details
            TextView detailstv = new TextView(getActivity());
            detailstv.setText(name);
            tr.addView(detailstv);

            // Make TV to hold the detailvals
            TextView valstv = new TextView(getActivity());
            valstv.setText(address);
            tr.addView(valstv);
            
         // Make TV to hold the details
            TextView rssiView = new TextView(getActivity());
            rssiView.setText(rssi);
            tr.addView(rssiView);

            tl.addView(tr, new TableLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
       
	}
	
	private final BroadcastReceiver mReceiver = new BroadcastReceiver() {
		public void onReceive(Context context, Intent intent) {
			String action = intent.getAction();
			// When discovery finds a device
			if (BluetoothDevice.ACTION_FOUND.equals(action)) {
				// Get the BluetoothDevice object from the Intent
				Log.d("debug", "Bluetooth Device Found.");
				BluetoothDevice device = intent
						.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
				// Add the name and address to an array adapter to show in a
				// ListView
				// mArrayAdapter.add(device.getName() + "\n" +
				// device.getAddress());
				short rssi = intent.getShortExtra(BluetoothDevice.EXTRA_RSSI,
						Short.MIN_VALUE);

				Log.d("debug", device.getName() + ":" + device.getAddress()
						+ ":" + rssi);

				// TextView t=(TextView)findViewById(R.id.editText1);
				// t.setText(rssi + "");
				
				addDevice(device.getName(), device.getAddress(), rssi + "");
				

			} else if (BluetoothAdapter.ACTION_DISCOVERY_FINISHED
					.equals(action)) {
				Log.d("debug", "Scan Finished");
				blueToothAdapter.startDiscovery();
			} else {
				Log.d("Sp,e other intend recieved", "Scan Finished");
			}
		}
	};

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == 1) {
			Log.d("debug", "Response Received for BlueTooth start intent:"
					+ resultCode);
			if (resultCode == android.app.Activity.RESULT_OK) {
				Log.d("debug", "Bluetooth Enabled");
			} else {
				Log.d("debug", "Bluetooth Not Enabled. Cancelled.");
			}
		}
	}

	private void queryPairedDevices() {
		BluetoothAdapter blueToothAdapter = BluetoothAdapter
				.getDefaultAdapter();
		Set<BluetoothDevice> pairedDevices = blueToothAdapter
				.getBondedDevices();
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
}
