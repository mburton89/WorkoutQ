using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExerciseType
{
	_custom,
    abWheel,
    benchPress,
    bentOverRow,
    boxJumps,
    calfRaises,
    cleans,
    curls,
    dbFrontRaises,
    dbRows,
    db_shoulder_press,
    db_side_raises,
    deadlifts,
    dips,
    inclineBench,
    jumpingJacks,
    lunges,
    planks,
    pullUps,
    pushups,
    running,
    shrugs,
    squats,
    tricepKickBack
}

[System.Serializable]
public class ExerciseData 
{
	public string name;
	public int secondsToCompleteSet;
	public int totalInitialSets;
	public int totalSets;
	public int repsPerSet;
	public int weight;

	public ExerciseType exerciseType;

	public static ExerciseData Copy(string newName, int newSeconds, int newTotalSets, int newRepsPerSet, int newWeight, ExerciseType newExerciseType){

		ExerciseData newExercise = new ExerciseData();

		newExercise.name = newName;
		newExercise.secondsToCompleteSet = newSeconds;
		newExercise.totalInitialSets = newTotalSets;
		newExercise.totalSets = newTotalSets;
		newExercise.repsPerSet = newRepsPerSet;
		newExercise.weight = newWeight;
		newExercise.exerciseType = newExerciseType;

		return newExercise;
	}

	public void Init(string name, int seconds, int totalSets, int reps, int weight, ExerciseType exerciseType)
	{
		this.name = name;
		this.secondsToCompleteSet = seconds;
		this.totalInitialSets = totalSets;
		this.totalSets = totalSets;
		this.repsPerSet = reps;
		this.weight = weight;
		this.exerciseType = exerciseType;
	}
}

