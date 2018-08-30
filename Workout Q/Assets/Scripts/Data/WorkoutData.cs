using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkoutData {

	public string name;
	public List<ExerciseData> exerciseData;

	public int seconds;
	public int minutes;

	public void EstablishMinutes()
	{
		minutes = 0;
		foreach(ExerciseData exercise in exerciseData){
			minutes = minutes + ((exercise.totalSets * exercise.secondsToCompleteSet) / 60);
		}
	}
}
