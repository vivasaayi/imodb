package com.example.modb;

import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class BlueToothCallibratorActivity extends BlueToothCoreActivity {
	Button scanDevicesButton, startNearByCallibrationButton, startFartherCallbrationButton, finalizeCallibrationButton;
	Spinner devicesSpinner;

	String selectedDevice;
	int totalResults = 0;
	
	TextView textViewToUpdate;
	float[] nearByRssi = new float[5];
	float[] distanceRssi = new float[5];
	boolean isCallibratingNearbyRssi;
	
	ProgressBar nearByCallibrationProgressBar;
	ProgressBar distanCallibrationProgressBar;
	
	TextView calculatedAAndNForDeviceTextView;
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.callibrator);
		
		scanDevicesButton = (Button) findViewById(R.id.scanDevicesButton);
		startNearByCallibrationButton = (Button) findViewById(R.id.startCallibrationNearbyButton);
		startFartherCallbrationButton = (Button) findViewById(R.id.startDistanceCallibration);
		finalizeCallibrationButton = (Button) findViewById(R.id.viewCallibrationResults);
		
		calculatedAAndNForDeviceTextView = (TextView) findViewById(R.id.calculatedNAndAForDevice);
		
		devicesSpinner = (Spinner) findViewById(R.id.devicesSpinner);
		
		nearByCallibrationProgressBar = (ProgressBar) findViewById(R.id.progressBar1);
		distanCallibrationProgressBar = (ProgressBar) findViewById(R.id.progressBar2);
		
		initializeView();	
		
		setAutoScan(false);
		enableTableDisplay(false);
		
		scanDevicesButton.setOnClickListener(this);
		startNearByCallibrationButton.setOnClickListener(this);
		startFartherCallbrationButton.setOnClickListener(this);
		finalizeCallibrationButton.setOnClickListener(this);
		
		devicesSpinner.setAdapter(devicesAdapter);
	}
	
	void processScannedResult(){
		for (BlueToothDevice device : scannedDevices) {
			String deviceName = (device.Name + " ==> " + device.MacAddress);
			if(deviceName.equalsIgnoreCase(selectedDevice)){
				TextView textView;
				if(isCallibratingNearbyRssi){
					textView = (TextView) findViewById(R.id.nearByRssi);		
					nearByRssi[totalResults] = device.Rssi;
					nearByCallibrationProgressBar.setProgress((totalResults +1) * 20);
				} else {
					textView = (TextView) findViewById(R.id.fartherRssi);	
					distanceRssi[totalResults] = device.Rssi;
					distanCallibrationProgressBar.setProgress((totalResults +1) * 20);
				}
				String text = textView.getText().toString() + "," + device.Rssi;
				textView.setText(text);
				totalResults += 1;				
			}
		}
		
		if(totalResults == 5){
			setAutoScan(false);
			totalResults = 0;
		}
		
		scannedDevices.clear();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View view) {
		isCallibratingNearbyRssi = false;
		if(view == scanDevicesButton){
			startBluetoothDeviceDiscovery();
		} else if (view == startNearByCallibrationButton){
			nearByCallibrationProgressBar.setProgress(0);
			scannedDevices.clear();
			isCallibratingNearbyRssi = true;
			selectedDevice = devicesSpinner.getSelectedItem().toString();
			setAutoScan(true);
			startBluetoothDeviceDiscovery();
		} else if(view == startFartherCallbrationButton){
			distanCallibrationProgressBar.setProgress(0);
			scannedDevices.clear();
			isCallibratingNearbyRssi =false;
			selectedDevice = devicesSpinner.getSelectedItem().toString();
			setAutoScan(true);
			startBluetoothDeviceDiscovery();
		} else if(view == finalizeCallibrationButton){
			EditText callibrationDistanceEditText = (EditText) findViewById(R.id.callibrationDistanceInMeters);
			
			if(callibrationDistanceEditText.getText().toString().length() <=0 ){
				Toast.makeText(this, "Please enter the distance.", Toast.LENGTH_LONG).show();
				return;
			}
			
			float nearBySum =0;
			float farthestSum =0;
			
			for(int i=0;i<5;i++){
				nearBySum += nearByRssi[i];
				farthestSum += distanceRssi[i];
			}
			
			double nearbyAvg = Math.abs(nearBySum/5);
			double farthestAvg = Math.abs(farthestSum/5);
			
			
			double callibrationDistance  = Float.parseFloat(callibrationDistanceEditText.getText().toString());
			
			double n = (farthestAvg - nearbyAvg)/(10 * Math.log10(callibrationDistance));
			
			calculatedAAndNForDeviceTextView.setText("A:" + nearbyAvg + "    N:" + n);
			
			SharedPreferences sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);
			
			Editor editor = sharedpreferences.edit();
			editor.putFloat(selectedDevice + "-A", (float)nearbyAvg);
			editor.putFloat(selectedDevice + "-N", (float)n);
			editor.commit();
			
			Toast.makeText(this, "Device Callibrated Successfully", Toast.LENGTH_LONG).show();
		}
	}

}
