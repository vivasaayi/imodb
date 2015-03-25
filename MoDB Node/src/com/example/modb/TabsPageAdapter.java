package com.example.modb;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class TabsPageAdapter extends FragmentPagerAdapter {

	public TabsPageAdapter(FragmentManager fm) {
		super(fm);
	}

	@Override
	public Fragment getItem(int index) {
		switch (index) {
        case 0:
            return new BlueToothDevicesListFragment();
        case 1:
            return new WifiDevicesListFragment();
        case 2:
            return new BlueToothGraphFragment();
        }
 
        return null;
	}

	@Override
	public int getCount() {		
		return 3;
	}

}
