using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayModeManager : MonoBehaviour {

	public static PlayModeManager Instance;

	private int _activeExerciseIndex;
	public WorkoutData ActiveWorkout;
	[HideInInspector]public ExerciseData PreviousExercise;
	[HideInInspector]public ExerciseData ActiveExercise;
	[HideInInspector]public ExerciseData NextExercise;
	public ExercisePanel PreviousExercisePanel;
	public ExercisePanel ActiveExercisePanel;
	public ExercisePanel NextExercisePanel;

	public Image timerLine;

	private float _secondsRemaining;
	private bool _isInPlayMode;

	public bool isPaused;

	[SerializeField] private LineSegmenter _lineSegmenter;

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

			timerLine.fillAmount = 1 - 	_secondsRemaining/ActiveExercise.secondsToCompleteSet;
			//timerLine.fillAmount = _secondsRemaining/ActiveWorkout.exerciseData[_activeExerciseIndex];
		}
	}

	public void IncrementSetsRemaining(){

		print ("YOYOYOYOYO");

		if (_activeExerciseIndex == 0 && ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
			_secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
			return;
		}
			
		if (_secondsRemaining >= ActiveExercise.secondsToCompleteSet - 1) 
		{
			if (ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
				_activeExerciseIndex--;
				EstablishPreviousExercise ();
				EstablishActiveExercise ();
				EstablishNextExercise ();
			} else {
				ActiveExercise.totalSets++;
				ActiveExercisePanel.setsNumberCircle.UpdateValue (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
			}
		}
			
		_secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;

		_lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
	}

	public void DecrementSetsRemaining(){
		if(ActiveExercise.totalSets == 1){
			_activeExerciseIndex ++;
			EstablishPreviousExercise ();
			EstablishActiveExercise();
			EstablishNextExercise();
			SoundManager.Instance.PlayNewExerciseSound ();
		}else{
			ActiveExercise.totalSets --;
			ActiveExercisePanel.setsNumberCircle.UpdateValue(ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
			SoundManager.Instance.PlayNewSetSound ();
		}

		_secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;

		_lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
	}

	void EstablishPreviousExercise(){
		if(_activeExerciseIndex < ActiveWorkout.exerciseData.Count && _activeExerciseIndex > 0){
			PreviousExercise = ActiveWorkout.exerciseData[_activeExerciseIndex - 1];
			PreviousExercisePanel.PopulateFields(
				PreviousExercise.name,
				PreviousExercise.secondsToCompleteSet,
				PreviousExercise.totalSets,
				PreviousExercise.repsPerSet,
				PreviousExercise.weight
			);
			PreviousExercisePanel.transform.localScale = Vector3.one;
		}else{
			PreviousExercisePanel.transform.localScale = Vector3.zero;
		}
	}

	void EstablishActiveExercise(){
		if(_activeExerciseIndex < ActiveWorkout.exerciseData.Count){
			ActiveExercise = ActiveWorkout.exerciseData[_activeExerciseIndex];
			ActiveExercisePanel.PopulateFields(
				ActiveExercise.name,
				ActiveExercise.secondsToCompleteSet,
				ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1),
				ActiveExercise.repsPerSet,
				ActiveExercise.weight
			);
		}else{
			ActiveExercisePanel.transform.localScale = Vector3.zero;
		}

		_lineSegmenter.Init (ActiveExercise.totalInitialSets);
		_lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
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
		EstablishPreviousExercise ();
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
