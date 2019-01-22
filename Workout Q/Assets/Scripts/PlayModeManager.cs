using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayModeManager : MonoBehaviour {

	public static PlayModeManager Instance;

	[HideInInspector] public int activeExerciseIndex;
	public WorkoutData ActiveWorkout;
	[HideInInspector]public ExerciseData PreviousExercise;
	[HideInInspector]public ExerciseData ActiveExercise;
	[HideInInspector]public ExerciseData NextExercise;
//	public ExercisePanel PreviousExercisePanel;
//	public ExercisePanel ActiveExercisePanel;
//	public ExercisePanel NextExercisePanel;

	public Image timerLine;

	private float _secondsRemaining;
	private bool _isInPlayMode;

	public bool isPaused;

	private TextMeshProUGUI _secondsLabel;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}

		_secondsLabel = Footer.Instance.seconds;
	}

	void Update(){

		if(_isInPlayMode){
			_secondsRemaining -= Time.deltaTime;
			//ActiveExercisePanel.timeNumberCircle.UpdateValue((int)_secondsRemaining);
			_secondsLabel.SetText (_secondsRemaining.ToString ("F0"));

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
		if (activeExerciseIndex == 0 && ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
			_secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
			return;
		}
			
		if (_secondsRemaining >= ActiveExercise.secondsToCompleteSet - 1) 
		{
			if (ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
				activeExerciseIndex--;
				EstablishPreviousExercise ();
				EstablishActiveExercise ();
				EstablishNextExercise ();
			} else {
				ActiveExercise.totalSets++;
				//ActiveExercisePanel.setsNumberCircle.UpdateValue (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));

				string activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1)).ToString();
				string totalSets = ActiveExercise.totalInitialSets.ToString ();	

				ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);
			}
		}
			
		_secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
		ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);

		SoundManager.Instance.PlayGoBackSound ();
	}

	public void DecrementSetsRemaining(){
		if(ActiveExercise.totalSets == 1){

			activeExerciseIndex ++;

			if (activeExerciseIndex == ActiveWorkout.exerciseData.Count) {
				HandleWorkoutFinished ();
				return;
			}

			//EstablishPreviousExercise ();
			EstablishActiveExercise();
			EstablishNextExercise();
			SoundManager.Instance.PlayNewExerciseSound ();
		}else{
			ActiveExercise.totalSets --;
			//ActiveExercisePanel.setsNumberCircle.UpdateValue(ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));

			string activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1)).ToString();
			string totalSets = ActiveExercise.totalInitialSets.ToString ();
			ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);

			SoundManager.Instance.PlayNewSetSound ();
		}

		_secondsRemaining = ActiveExercise.secondsToCompleteSet;
		ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
	}

	void EstablishPreviousExercise(){
//		if(_activeExerciseIndex < ActiveWorkout.exerciseData.Count && _activeExerciseIndex > 0){
//			PreviousExercise = ActiveWorkout.exerciseData[_activeExerciseIndex - 1];
//			PreviousExercisePanel.PopulateFields(
//				PreviousExercise.name,
//				PreviousExercise.secondsToCompleteSet,
//				PreviousExercise.totalSets,
//				PreviousExercise.repsPerSet,
//				PreviousExercise.weight
//			);
//			PreviousExercisePanel.transform.localScale = Vector3.one;
//		}else{
//			PreviousExercisePanel.transform.localScale = Vector3.zero;
//		}
	}

	void EstablishActiveExercise(){
		if(activeExerciseIndex < ActiveWorkout.exerciseData.Count){
			ActiveExercise = ActiveWorkout.exerciseData[activeExerciseIndex];
//			ActiveExercisePanel.PopulateFields(
//				ActiveExercise.name,
//				ActiveExercise.secondsToCompleteSet,
//				ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1),
//				ActiveExercise.repsPerSet,
//				ActiveExercise.weight
//			);
		}
		//		else{
		//			ActiveExercisePanel.transform.localScale = Vector3.zero;
		//		}

		Header.Instance.UpdateMiddleLabel(ActiveExercise.name);
		//ViewExerciseView.Instance.exerciseViewRow.UpdateLabel (ActiveExercise.name);
		ViewExerciseView.Instance.exerciseViewRow.lineSegmenter.ShowSegmentCummulativelyLit (ActiveWorkout.exerciseData.IndexOf(ActiveExercise));

		ViewExerciseView.Instance.setsViewRow.lineSegmenter.Init (ActiveExercise.totalInitialSets);
		ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
		string activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1)).ToString();
		string totalSets = ActiveExercise.totalInitialSets.ToString ();
		ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);

		ViewExerciseView.Instance.UpdateRepsAndWeightView (ActiveExercise.repsPerSet, ActiveExercise.weight);
	}

	void EstablishNextExercise(){
		if(activeExerciseIndex < ActiveWorkout.exerciseData.Count - 1){
			NextExercise = ActiveWorkout.exerciseData[activeExerciseIndex + 1];
			Header.Instance.UpdateTopLabel ("Next: " + NextExercise.name);
		}else{
			Header.Instance.UpdateTopLabel ("");
		}
	}

	void HandleTimerHittingZero(){
		DecrementSetsRemaining();
	}

	public void PlayWorkout(WorkoutData workout, int exerciseIndex){

		if (ActiveWorkout != null) {
			ActiveWorkout.exerciseData.Clear ();
		}

		foreach(ExerciseData exercise in workout.exerciseData){

			ExerciseData newExercise = ExerciseData.Copy(
				exercise.name,
				exercise.secondsToCompleteSet,
				exercise.totalSets,
				exercise.repsPerSet,
				exercise.weight);

			ActiveWorkout.exerciseData.Add(newExercise);
		}

		activeExerciseIndex = exerciseIndex;
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
//		ActiveExercisePanel.transform.localScale = Vector3.one;
//		NextExercisePanel.transform.localScale = Vector3.one;
	}

	public void Pause(){
		_isInPlayMode = false;
		isPaused = true;
	}

	public void Resume(){
		_isInPlayMode = true;
		isPaused = false;
	}

	void HandleWorkoutFinished()
	{
		Header.Instance.HandleBackPressed ();
	}
}
