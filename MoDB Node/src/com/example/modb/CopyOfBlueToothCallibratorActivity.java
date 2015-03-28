package com.example.modb;

import java.util.List;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.net.wifi.ScanResult;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

public class CopyOfBlueToothCallibratorActivity extends Fragment {
	WifiManager wifi; 
	
	@Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
 
        View rootView = inflater.inflate(R.layout.callibrator, container, false);
        
        wifi = (WifiManager) getActivity().getSystemService(Context.WIFI_SERVICE);
        
        if(wifi.isWifiEnabled() == false) {
        	Toast.makeText(getActivity().getApplicationContext(), "Wifi is disabled. Enablimg", 
        			Toast.LENGTH_LONG).show();
        	wifi.setWifiEnabled(true);
        }
        
        IntentFilter filter = new IntentFilter(WifiManager.SCAN_RESULTS_AVAILABLE_ACTION);
        getActivity().registerReceiver(mReceiver, filter);
        
        IntentFilter filter1 = new IntentFilter(WifiManager.RSSI_CHANGED_ACTION);
        getActivity().registerReceiver(mReceiver, filter1);
        
        wifi.startScan();
        
        return rootView;
    }
	
	List<ScanResult> results;
	
	private final BroadcastReceiver mReceiver = new BroadcastReceiver() {
		public void onReceive(Context context, Intent intent) {
			String action = intent.getAction();
			
			// When discovery finds a device
			if (WifiManager.SCAN_RESULTS_AVAILABLE_ACTION.equals(action)) {
				results = wifi.getScanResults();
				for(int i=0;i< results.size(); i ++){
					ScanResult sr = results.get(i);
					//int rssi = intent.getIntExtra(WifiManager.EXTRA_NEW_RSSI, 0);
					
					Log.d("debug", sr.SSID + ":" + this.CalculateDistance((double)sr.level, sr.frequency));
				}
			} 
		}
		
		public double CalculateDistance(double level, double frequency){
			double exp = (27.55 - (20*Math.log10(frequency)) + Math.abs(level)) / 20.0;
			return Math.pow(10.0, exp);
			
		}
	};

}
