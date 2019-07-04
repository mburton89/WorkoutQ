using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NotchHeader : MonoBehaviour {

	public TextMeshProUGUI batteryText;
	public TextMeshProUGUI timeText;

	void Start()
	{
		InvokeRepeating ("ShowStats", 0f, 5f);
	}

	void ShowStats () 
	{
		DateTime dateTime = DateTime.Now;
		int hour = dateTime.Hour;
		if (hour > 12) {
			hour = hour - 12;
		}

		string minuteString;
		int minute = dateTime.Minute;

		if (minute < 10) {
			minuteString = "0" + minute;
		} else {
			minuteString = minute.ToString ();
		}

		if (hour == 0) {
			hour = 12;
		}

		//string time = dateTime.ToString ("HH:mm");
		string time = dateTime.ToString (hour + ":" + minuteString);
		timeText.text = time;

		int batteryPercentage = (int)(SystemInfo.batteryLevel * 100f);
		batteryText.text = batteryPercentage + "%";
	}
}
