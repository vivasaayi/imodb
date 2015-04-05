package com.example.modb;

import android.app.Activity;
import android.content.Context;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class BlueToothCallibratorActivity extends BlueToothCoreActivity {
	LocationManager locationManager;
	LocationListener locationListener;

	EditText lattitudeEditText;
	EditText longtitudeEditText;
	EditText bearingEditText;
	Button markAsDeviceLocationButton;
	TextView deviceLattitudeTextView, deviceLongtitudeTextView, distanceFromDeviceTextView;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.callibrator);
		
		initializeView();

		lattitudeEditText = (EditText) findViewById(R.id.lattitudeEditText);
		longtitudeEditText = (EditText) findViewById(R.id.longtitudeEditText);
		bearingEditText = (EditText) findViewById(R.id.bearingEditText);
		
		startScanButton = (Button) findViewById(R.id.startCallibratingButton);
		markAsDeviceLocationButton = (Button) findViewById(R.id.markAsDeviceLocation);
		deviceLattitudeTextView = (TextView) findViewById(R.id.deviceLatttudeTextView);
		deviceLongtitudeTextView = (TextView) findViewById(R.id.deviceLongitudeTextView);
		distanceFromDeviceTextView = (TextView) findViewById(R.id.distanceFromDeviceTextView);
		
		markAsDeviceLocationButton.setOnClickListener(this);
		startScanButton.setOnClickListener(this);

		// Acquire a reference to the system Location Manager
		locationManager = (LocationManager) this.getSystemService(Context.LOCATION_SERVICE);

		// Define a listener that responds to location updates
		locationListener = new LocationListener() {
			public void onLocationChanged(Location location) {
				// Called when a new location is found by the network location
				// provider.
				lattitudeEditText.setText(location.getLatitude() + "");
				longtitudeEditText.setText(location.getLongitude() + "");
				previousLocation = location;
				
				if(deviceLocation !=null ){
					previousDistanceToDevice = location.distanceTo(deviceLocation);
					distanceFromDeviceTextView.setText(previousDistanceToDevice + "");
					bearingEditText.setText(location.bearingTo(deviceLocation) + "");
				}
			}

			public void onStatusChanged(String provider, int status, Bundle extras) {
			}

			public void onProviderEnabled(String provider) {
			}

			public void onProviderDisabled(String provider) {
			}
		};
		
		if (locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER)) {
			locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 10, 0, locationListener);
		} 
		
		if (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
			locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 10, 0, locationListener);
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View view) {
		if (view == markAsDeviceLocationButton) {
			deviceLocation = previousLocation;
			
			deviceLattitudeTextView.setText("Device Lattitude:" +  deviceLocation.getLatitude() + "");
			deviceLongtitudeTextView.setText("Device Longtitude:" + deviceLocation.getLongitude() + "");
		}
	}

}
