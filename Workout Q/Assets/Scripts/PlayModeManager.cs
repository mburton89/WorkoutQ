using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeManager : MonoBehaviour {
	
	private int _activeExerciseIndex;
	public WorkoutData ActiveWorkout;
	[HideInInspector]public ExerciseData ActiveExercise;
	[HideInInspector]public ExerciseData NextExercise;
	public ExercisePanel ActiveExercisePanel;
	public ExercisePanel NextExercisePanel;

	private float _secondsRemaining;

	void Start(){
		_activeExerciseIndex = 0;
		EstablishActiveExercise();
		EstablishNextExercise();
		_secondsRemaining = ActiveExercise.secondsToCompleteSet;
	}

	void Update(){

		_secondsRemaining -= Time.deltaTime;
		ActiveExercisePanel.timeNumberCircle.UpdateValue((int)_secondsRemaining);

		if(_secondsRemaining < 0){
			HandleTimerHittingZero();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			DecrementSetsRemaining();
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
}
