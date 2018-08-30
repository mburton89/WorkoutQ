using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExerciseData 
{
	public WorkoutData parentWorkoutData;
	public string name;
	public int secondsToCompleteSet;
	public int totalSets;
	public int repsPerSet;
	public int weight;
}
