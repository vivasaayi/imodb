package com.example.modb;

import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener {

	Button startAPButton;
	Button callibrateButton;
	Button trackMeButton;
	Button settingsButton;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		startAPButton = (Button) findViewById(R.id.startAP);
		callibrateButton = (Button) findViewById(R.id.callibrate);
		trackMeButton = (Button) findViewById(R.id.trackMe);
		settingsButton = (Button) findViewById(R.id.settingsButton);

		startAPButton.setOnClickListener(this);
		callibrateButton.setOnClickListener(this);
		trackMeButton.setOnClickListener(this);
		settingsButton.setOnClickListener(this);

		SharedPreferences sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);

		//First Time 
		if (sharedpreferences.getAll().size() <= 0) {
			Editor editor = sharedpreferences.edit();
			editor.putString("URL", "http://127.0.0.1");
			editor.putString("Port", "4040");
			editor.putString("APN", "Please set the APN");

			editor.commit();
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
		if (view == startAPButton) {
			Intent intent = new Intent(MainActivity.this, BlueToothAPActivity.class);
			startActivity(intent);
		} else if (view == callibrateButton) {
			Intent intent = new Intent(MainActivity.this, BlueToothCallibratorActivity.class);
			startActivity(intent);
		} else if (view == trackMeButton) {
			Intent intent = new Intent(MainActivity.this, BlueToothTrackerActivity.class);
			startActivity(intent);
		} else if (view == settingsButton) {
			Intent intent = new Intent(MainActivity.this, PreferenceEditorActivity.class);
			startActivity(intent);
		}
	}
}
