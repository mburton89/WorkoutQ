using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExerciseData 
{
	public string name;
	public int secondsToCompleteSet;
	public int totalSets;
	public int repsPerSet;
	public int weight;

	public static ExerciseData Copy(string newName, int newSeconds, int newTotalSets, int newRepsPerSet, int newWeight){

		ExerciseData newExercise = new ExerciseData();

		newExercise.name = newName;
		newExercise.secondsToCompleteSet = newSeconds;
		newExercise.totalSets = newTotalSets;
		newExercise.repsPerSet = newRepsPerSet;
		newExercise.weight = newWeight;

		return newExercise;
	}
}
