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
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

public class BlueToothAPActivity extends BlueToothCoreActivity {
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.bluetooth_ap);
		
		initializeView();
		
		startScanButton = (Button) findViewById(R.id.startScanButton);
		addDeviceButton = (Button) findViewById(R.id.addDeviceButton);
		postResultsButton = (Button) findViewById(R.id.postScanResultsToServer);

		startScanButton.setOnClickListener(this);
		addDeviceButton.setOnClickListener(this);
		postResultsButton.setOnClickListener(this);
		
		SharedPreferences sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);
		
		if(!sharedpreferences.getBoolean("TESTMODE", false)){
			LinearLayout testLayout = (LinearLayout) findViewById(R.id.testModeLayout);
			testLayout.setVisibility(View.GONE);
		}
	}
}
