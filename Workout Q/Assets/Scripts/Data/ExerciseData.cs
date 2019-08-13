using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExerciseType //TODO add the exercises 2/19/2019
{
	_custom,
    abWheel,
	bandsExternal,
	bandsInternal,
    benchPress,
    bentOverRow,
	bodySquats,
    boxJumps,
    calfRaises,
	chairDips,
	chinUps,
    cleans,
	cleanPress,
	crunches,
    curls,
    dbFrontRaises,
    dbRows,
    db_shoulder_press,
    db_side_raises,
	dbToeTouches,
    deadlifts,
    dips,
	hammerCurls,
	hangingKneeRaises,
    inclineBench,
    jumpingJacks,
    lunges,
	militaryPress,
	modifiedPushups,
	obliqueSideRaises,
	overheadTricepExtensions,
	reverseCurls,
	reverseFlies,
	rowMachine,
	planksBack,
    planksFront,
	planksSide,
    pullUps,
    pushups,
    running,
    shrugs,
	skullCrushers,
    squats,
	squatJumps,
	straightLegDeadlift,
    tricepKickBack,
	uprightRows,
	windmills
}

[System.Serializable]
public class ExerciseData 
{
	public string name;
	public int secondsToCompleteSet;
	public int secondsRemainingInSet;
	public int totalInitialSets;
	public int totalSets;
	public int repsPerSet;
	public int weight;

	public ExerciseType exerciseType;

	public bool isInProgress;

	public static ExerciseData Copy(string newName, int newSeconds, int newTotalInitialSets, int newTotalSets, int newRepsPerSet, int newWeight, ExerciseType newExerciseType){

		ExerciseData newExercise = new ExerciseData();

		newExercise.name = newName;
		newExercise.secondsToCompleteSet = newSeconds;
		newExercise.secondsRemainingInSet = newSeconds;
		newExercise.totalInitialSets = newTotalInitialSets;
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
		this.secondsRemainingInSet = seconds;
		this.totalInitialSets = totalSets;
		this.totalSets = totalSets;
		this.repsPerSet = reps;
		this.weight = weight;
		this.exerciseType = exerciseType;
	}

	public void Reset()
	{
		secondsRemainingInSet = secondsToCompleteSet;
		totalSets = totalInitialSets;
		isInProgress = false;
	}
}

