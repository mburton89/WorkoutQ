using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeManager : MonoBehaviour {

	public static PlayModeManager Instance;

	private int _activeExerciseIndex;
	public WorkoutData ActiveWorkout;
	[HideInInspector]public ExerciseData ActiveExercise;
	[HideInInspector]public ExerciseData NextExercise;
	public ExercisePanel ActiveExercisePanel;
	public ExercisePanel NextExercisePanel;

	private float _secondsRemaining;
	private bool _isInPlayMode;

	public bool isPaused;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void Update(){

		if(_isInPlayMode){
			_secondsRemaining -= Time.deltaTime;
			ActiveExercisePanel.timeNumberCircle.UpdateValue((int)_secondsRemaining);

			if(_secondsRemaining < 0){
				HandleTimerHittingZero();
			}

			if(Input.GetKeyDown(KeyCode.RightArrow)){
				DecrementSetsRemaining();
			}
		}
	}

	public void DecrementSetsRemaining(){
		ActiveExercise.totalSets --;
		if(ActiveExercise.totalSets == 0){
			_activeExerciseIndex ++;
			EstablishActiveExercise();
			EstablishNextExercise();
		}else{
			ActiveExercisePanel.setsNumberCircle.UpdateValue(ActiveExercise.totalSets);
		}

		_secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
	}

	void EstablishActiveExercise(){
		if(_activeExerciseIndex < ActiveWorkout.exerciseData.Count){
			ActiveExercise = ActiveWorkout.exerciseData[_activeExerciseIndex];
			ActiveExercisePanel.PopulateFields(
				ActiveExercise.name,
				ActiveExercise.secondsToCompleteSet,
				ActiveExercise.totalSets,
				ActiveExercise.repsPerSet,
				ActiveExercise.weight
			);
		}else{
			ActiveExercisePanel.transform.localScale = Vector3.zero;
		}
	}

	void EstablishNextExercise(){
		if(_activeExerciseIndex < ActiveWorkout.exerciseData.Count - 1){
			NextExercise = ActiveWorkout.exerciseData[_activeExerciseIndex + 1];
			NextExercisePanel.PopulateFields(
				NextExercise.name,
				NextExercise.secondsToCompleteSet,
				NextExercise.totalSets,
				NextExercise.repsPerSet,
				NextExercise.weight
			);
		}else{
			NextExercisePanel.transform.localScale = Vector3.zero;
		}
	}

	void HandleTimerHittingZero(){
		DecrementSetsRemaining();
	}

	public void PlayWorkout(WorkoutData workout){

		foreach(ExerciseData exercise in workout.exerciseData){

			ExerciseData newExercise = ExerciseData.Copy(
				exercise.name,
				exercise.secondsToCompleteSet,
				exercise.totalSets,
				exercise.repsPerSet,
				exercise.weight);

			ActiveWorkout.exerciseData.Add(newExercise);
		}

		_activeExerciseIndex = 0;
		EstablishActiveExercise();
		EstablishNextExercise();
		_secondsRemaining = ActiveExercise.secondsToCompleteSet;
		_isInPlayMode = true;
	}

	public void Reset(){
		ActiveWorkout.exerciseData.Clear();
		_isInPlayMode = false;
		isPaused = false;
		ActiveExercisePanel.transform.localScale = Vector3.one;
		NextExercisePanel.transform.localScale = Vector3.one;
	}

	public void Pause(){
		_isInPlayMode = false;
		isPaused = true;
	}

	public void Resume(){
		_isInPlayMode = true;
		isPaused = false;
	}
}
