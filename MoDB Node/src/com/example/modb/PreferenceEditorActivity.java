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
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

public class PreferenceEditorActivity extends Activity implements OnClickListener {
	Button savePreferencesButton;

	EditText urlEditView;
	EditText portEditView;
	EditText accessPointNameEditView;
	
	CheckBox isTestModeCheckBox;
	
	SharedPreferences sharedpreferences;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.preferences);

		savePreferencesButton = (Button) findViewById(R.id.callibrate);
		savePreferencesButton.setOnClickListener(this);

		urlEditView = (EditText) findViewById(R.id.url);
		portEditView = (EditText) findViewById(R.id.port);
		accessPointNameEditView = (EditText) findViewById(R.id.accessPointNameTextView);
		isTestModeCheckBox = (CheckBox) findViewById(R.id.isTestMode);

		sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);
		urlEditView.setText(sharedpreferences.getString("URL", ""));
		portEditView.setText(sharedpreferences.getString("Port", ""));
		accessPointNameEditView.setText(sharedpreferences.getString("APN", ""));
		isTestModeCheckBox.setChecked(sharedpreferences.getBoolean("TESTMODE", false));
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View view) {
		if (view == savePreferencesButton) {
			Editor editor = sharedpreferences.edit();
			editor.putString("URL", urlEditView.getText().toString());
			editor.putString("Port", portEditView.getText().toString());
			editor.putString("APN", accessPointNameEditView.getText().toString());
			editor.putBoolean("TESTMODE", isTestModeCheckBox.isChecked());

			editor.commit();
			
			Toast.makeText(this, "Settings Saved", Toast.LENGTH_LONG).show();
		}
	}
}
