using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workout : MonoBehaviour {

	public string workoutName;
	public List<Exercise> Exercises;

	public int seconds;
	public int minutes;

	void Awake(){
		foreach(Exercise exercise in GetComponentsInChildren<Exercise>()){
			Exercises.Add(exercise);
			seconds = seconds + (exercise.secondsToCompleteSet * exercise.totalSets);
		}

		minutes = seconds/60;
	}
}
