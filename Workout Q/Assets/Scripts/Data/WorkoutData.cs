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

	public static WorkoutData Copy(WorkoutData workoutDataToCopy){

		WorkoutData copiedWorkout = new WorkoutData();

		copiedWorkout.name = workoutDataToCopy.name;

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
}
