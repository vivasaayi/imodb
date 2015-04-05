package com.example.modb;

import java.util.HashMap;
import java.util.Map;

import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

public class CallibrationResultActivity extends Activity implements OnClickListener {
	SharedPreferences sharedpreferences;
	
	Map<String, Float> ns = new HashMap<String, Float>();
	Map<String, Float> as = new HashMap<String, Float>();

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.callibration_result);

		sharedpreferences = getSharedPreferences("MODB", Context.MODE_PRIVATE);
		
		for (String key : sharedpreferences.getAll().keySet()) {
			if(key.endsWith("-A")){
				String device = key.substring(0, key.length() - 2);
				as.put(device, sharedpreferences.getFloat(key, 0));
			} else if (key.endsWith("-N")){
				String device = key.substring(0, key.length() - 2);
				ns.put(device, sharedpreferences.getFloat(key, 0));
			}
		}
		
		LinearLayout linearLayout = (LinearLayout)this.findViewById(R.id.mainLayout);
		
		for (String device : as.keySet()) {
			
			String name = device + "    A:" + as.get(device).toString() + "     N:" + ns.get(device).toString(); 
			
			TextView deviceTextView = new TextView(this);
			deviceTextView.setText(name);
			linearLayout.addView(deviceTextView);
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
		
	}
}
