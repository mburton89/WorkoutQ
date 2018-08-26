using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutManager : MonoBehaviour {

	public static WorkoutManager Instance;

	public List<Workout> Workouts;
	public Workout ActiveWorkout;
	private int _activeExerciseIndex;
	public Exercise ActiveExercise;
	public WorkoutHUD workoutHUD;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}

		foreach(Workout workout in GetComponentsInChildren<Workout>()){
			Workouts.Add(workout);
		}
	}

	void Start(){
		workoutHUD.ActiveWorkoutText.text = ActiveWorkout.name;
		workoutHUD.UpdateText(ActiveExercise); 
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			DecrementSetsRemaining();
		}
	}

	public void DecrementSetsRemaining(){
		ActiveExercise.totalSets --;

		if(ActiveExercise.totalSets == 0 && ActiveWorkout.Exercises.Count > (_activeExerciseIndex + 1)){
			//Handle Index Out of Range. End Workout
			_activeExerciseIndex ++;
			ActiveExercise = ActiveWorkout.Exercises[_activeExerciseIndex];
		}

		workoutHUD.UpdateText(ActiveExercise); 
	}
}
