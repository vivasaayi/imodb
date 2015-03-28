package com.example.modb;

import android.text.format.DateFormat;

public class Utils {
	public static String GetDate() {
		DateFormat df = new DateFormat();
		return (String) DateFormat.format("yyyy-MM-dd hh:mm:ss", new java.util.Date());
	}
}
