package com.example.modb;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

public class BlueToothTrackerActivity extends BlueToothCoreActivity {
	SharedPreferences sharedpreferences;

	Map<String, Float> ns = new HashMap<String, Float>();
	Map<String, Float> as = new HashMap<String, Float>();

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tracker);

		initializeView();
		enableTableDisplay(false);

		sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);

		for (String key : sharedpreferences.getAll().keySet()) {
			if (key.endsWith("-A")) {
				String device = key.substring(0, key.length() - 2);
				as.put(device, sharedpreferences.getFloat(key, 0));
			} else if (key.endsWith("-N")) {
				String device = key.substring(0, key.length() - 2);
				ns.put(device, sharedpreferences.getFloat(key, 0));
			}
		}

		startBluetoothDeviceDiscovery();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	void processScannedResult(){
		float a, n;
		LinearLayout linearLayout = (LinearLayout)this.findViewById(R.id.trackerMainLayout);
		linearLayout.removeAllViews();
		
		TextView header = (TextView) findViewById(R.id.textView1);
		header.setText("Distance from Devices: " + Utils.GetDate());
		
		for (BlueToothDevice device : scannedDevices) {
			String deviceName = (device.Name + " ==> " + device.MacAddress);
			if(as.containsKey(deviceName)){
				a = as.get(deviceName);
				n = ns.get(deviceName);
				float distance = CalculateDistance(a,n, Math.abs(device.Rssi), deviceName);
				
				String name = deviceName + " :::" + distance; 
				
				TextView deviceTextView = new TextView(this);
				deviceTextView.setText(name);
				linearLayout.addView(deviceTextView);
			}
		}
		
		scannedDevices.clear();
	}

	private float CalculateDistance(float a, float n, int rssi, String device) {
		float result = ((float) rssi - a) / (10 * n);
		double distance = Math.pow(10, result);
		return (float) distance;
	}
}
