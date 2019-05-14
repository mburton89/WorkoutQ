﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorkoutType
{
	_singleDumbell,
	doubleDumbell,
	dumbellsOnBench,
	benchRack,
	squatRack,
	pullupBar,
	barbell,
	kettleBell,
	noWeights,
	stopWatch,
	heartRate,
	mon,
	tue,
	wed,
	thu,
	fri,
	sat,
	sun,
	day1,
	day2,
	day3,
	day4,
	day5,
	day6,
	day7
}

[System.Serializable]
public class WorkoutData 
{
	public string name;
	public List<ExerciseData> exerciseData;

	public int seconds;
	public int minutes;
	public int secondsBetweenExercises;

	public WorkoutType workoutType;

	public bool inProgress;

	public void EstablishMinutes()
	{
		minutes = 0;
		foreach(ExerciseData exercise in exerciseData){
			minutes = minutes + ((exercise.totalInitialSets * exercise.secondsToCompleteSet) / 60);
		}
	}

	public static WorkoutData Copy(WorkoutData workoutDataToCopy){

		WorkoutData copiedWorkout = new WorkoutData();
		copiedWorkout.name = workoutDataToCopy.name;
		copiedWorkout.workoutType = workoutDataToCopy.workoutType;
		copiedWorkout.exerciseData = new List<ExerciseData> ();

		foreach(ExerciseData exercise in workoutDataToCopy.exerciseData){

			ExerciseData copiedExercise = ExerciseData.Copy(
				exercise.name,
				exercise.secondsToCompleteSet,
				exercise.totalSets,
				exercise.repsPerSet,
				exercise.weight,
				exercise.exerciseType
			);

			copiedWorkout.exerciseData.Add(copiedExercise);
		}

		return copiedWorkout;
	}

	public void Reset()
	{
		inProgress = false;

		foreach (ExerciseData exercise in exerciseData) {
			exercise.Reset ();
		}
	}
}
