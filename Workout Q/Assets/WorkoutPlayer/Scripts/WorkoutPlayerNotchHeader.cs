using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WorkoutPlayerNotchHeader : MonoBehaviour {

	private WorkoutPlayerController _controller;

	[SerializeField] private TextMeshProUGUI _etaText;
	[SerializeField] private TextMeshProUGUI _batteryText;
	[SerializeField] private TextMeshProUGUI _timeText;

	public void Init(WorkoutPlayerController controller, WorkoutData workout)
	{
		_controller = controller;
		DetermineETA (workout);
		_etaText.color = ColorManager.Instance.ActiveColorLight;
		_batteryText.color = ColorManager.Instance.ActiveColorLight;
		_timeText.color = ColorManager.Instance.ActiveColorLight;
	}

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

		//string time = dateTime.ToString ("HH:mm");
		string time = dateTime.ToString (hour + ":" + minuteString);
		_timeText.text = time;

		int batteryPercentage = (int)(SystemInfo.batteryLevel * 100f);
		_batteryText.text = batteryPercentage + "%";

		DetermineETA (_controller.GetActiveWorkout());
	}

	public int DetermineMinutesRemaining(WorkoutData workout)
	{
		int secondsRemainingInWorkout = 0;
		int minutesRemainingInWorkout = 0;

		foreach (ExerciseData exercise in workout.exerciseData) 
		{
			int secondsRemainingInExercise = exercise.totalSets * exercise.secondsToCompleteSet;

			if (secondsRemainingInExercise > 0)
			{
				secondsRemainingInExercise = secondsRemainingInExercise + workout.secondsBetweenExercises;
			}

			secondsRemainingInWorkout = secondsRemainingInWorkout + secondsRemainingInExercise;
		}
			
		secondsRemainingInWorkout = secondsRemainingInWorkout - workout.secondsBetweenExercises; //To compensate for the last exercise which has not secondsBetweenExercises
		minutesRemainingInWorkout = secondsRemainingInWorkout / 60;
		return minutesRemainingInWorkout;
	}

	public void DetermineETA(WorkoutData workout)
	{
		DateTime dateTime = DateTime.Now;

		string minuteString;
		int minute = dateTime.Minute + DetermineMinutesRemaining(workout);

		int hoursToAdd = minute/60;

		if (hoursToAdd > 0) 
		{
			minute = minute - (60 * hoursToAdd);
		}

		if (minute < 10) 
		{
			minuteString = "0" + minute;
		}
		else 
		{
			minuteString = minute.ToString ();
		}

		int hour = dateTime.Hour + hoursToAdd;

		if (hour > 12 && hour < 24)
		{
			hour = hour - 12;
		}
		else if (hour > 24)
		{
			hour = hour - 24;
		}

		string time = dateTime.ToString (hour + ":" + minuteString);

		_etaText.text = "ETA " + time;
	}
}
