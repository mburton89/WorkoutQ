using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WorkoutStatsController : MonoBehaviour {

	private WorkoutPlayerController _controller;

	[SerializeField] private TextMeshProUGUI _completionValue;
	[SerializeField] private TextMeshProUGUI _etaValue;
	[SerializeField] private TextMeshProUGUI _timeLeftValue;
	[SerializeField] private TextMeshProUGUI _completionLabel;
	[SerializeField] private TextMeshProUGUI _etaLabel;
	[SerializeField] private TextMeshProUGUI _timeLeftLabel;

	public void Init(WorkoutPlayerController controller, WorkoutData workout)
	{
		_controller = controller;
		DetermineCompletionValue (workout);
		DetermineMinutesRemaining (workout);
		DetermineETA (workout);
		_completionValue.color = ColorManager.Instance.ActiveColorLight;
		_etaValue.color = ColorManager.Instance.ActiveColorLight;
		_timeLeftValue.color = ColorManager.Instance.ActiveColorLight;
		_completionLabel.color = ColorManager.Instance.ActiveColorLight;
		_etaLabel.color = ColorManager.Instance.ActiveColorLight;
		_timeLeftLabel.color = ColorManager.Instance.ActiveColorLight;
	}

	public void Refresh(WorkoutData workout)
	{
		DetermineCompletionValue (workout);
		DetermineMinutesRemaining (workout);
		DetermineETA (workout);
	}

	public void DetermineCompletionValue(WorkoutData workout)
	{
		int totalSets = 0;
		int setsComplete = 0;
		int percentComplete;
		float amountComplete = 0f;

		foreach (ExerciseData exercise in workout.exerciseData) 
		{
			totalSets = totalSets + exercise.totalInitialSets;
			setsComplete = setsComplete + (exercise.totalInitialSets - exercise.totalSets);
		}

		amountComplete = (float)setsComplete / (float)totalSets;
		percentComplete = (int)(amountComplete * 100);

		print ("amountComplete: " + amountComplete);

		_completionValue.text = percentComplete + "%";
	}

	public int DetermineMinutesRemaining(WorkoutData workout)
	{
		int secondsRemainingInWorkout = 0;
		int minutesRemainingInWorkout = 0;

		foreach (ExerciseData exercise in workout.exerciseData) 
		{
			int secondsRemainingInExercise = exercise.totalSets * exercise.secondsToCompleteSet;
			secondsRemainingInWorkout = secondsRemainingInWorkout + secondsRemainingInExercise;
		}

		print ("secondsRemainingInWorkout: " + secondsRemainingInWorkout);

		minutesRemainingInWorkout = secondsRemainingInWorkout / 60;
		print ("minutesRemainingInWorkout: " + minutesRemainingInWorkout);

		return minutesRemainingInWorkout;

		_timeLeftValue.text = minutesRemainingInWorkout + "m";
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

		_etaValue.text = "ETA: " + time;
	}
}
