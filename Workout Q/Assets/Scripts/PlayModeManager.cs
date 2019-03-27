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

//	public Image timerLine;
	public TimeSlider timeSlider;

	[HideInInspector] public float secondsRemaining;
	private bool _isInPlayMode;

	public bool isPaused;

	[SerializeField] private TextMeshProUGUI _secondsLabel;

	[SerializeField] private NextUpTextController _nextUpTextController;
    
	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void Start()
	{
		timeSlider = Footer.Instance.timeSlider;
	}

	void Update(){

		if(_isInPlayMode){
			
			//ActiveExercisePanel.timeNumberCircle.UpdateValue((int)_secondsRemaining);

			if (!timeSlider.selectHandler.pointerIsDown) {
				secondsRemaining -= Time.deltaTime;
				timeSlider.slider.value = 1 - secondsRemaining/ActiveExercise.secondsToCompleteSet;
			}

			_secondsLabel.SetText (secondsRemaining.ToString ("F0") + "s");

			if(secondsRemaining < 0){
				HandleTimerHittingZero();
			}

			if(Input.GetKeyDown(KeyCode.RightArrow)){
				DecrementSetsRemaining();
			}

			//timerLine.fillAmount = _secondsRemaining/ActiveWorkout.exerciseData[_activeExerciseIndex];
			//Footer.Instance.UpdateTimerSlider(1 - _secondsRemaining/ActiveExercise.secondsToCompleteSet);
		}
	}

	public void IncrementSetsRemaining(){
		if (activeExerciseIndex == 0 && ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
			secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
			return;
		}
			
		if (secondsRemaining >= ActiveExercise.secondsToCompleteSet - 1) 
		{
			if (ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
				activeExerciseIndex--;
				EstablishPreviousExercise ();
				EstablishActiveExercise ();
				EstablishNextExercise ();
			} else {
				ActiveExercise.totalSets++;
				//ActiveExercisePanel.setsNumberCircle.UpdateValue (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));

				int activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
				string totalSets = ActiveExercise.totalInitialSets.ToString ();	

				ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);
				ViewExerciseView.Instance.UpdateSetsView (activeSet, ActiveExercise.totalInitialSets);
			}
		}
			
		secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
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

			int activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
			string totalSets = ActiveExercise.totalInitialSets.ToString ();
			ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);
			ViewExerciseView.Instance.UpdateSetsView (activeSet, ActiveExercise.totalInitialSets);

			SoundManager.Instance.PlayNewSetSound ();
		}

		secondsRemaining = ActiveExercise.secondsToCompleteSet;
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

		Header.Instance.UpdateMiddleLabel ("XRC " + (activeExerciseIndex + 1) + " of " + ActiveWorkout.exerciseData.Count);

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

		ViewExerciseView.Instance.UpdateExerciseName (ActiveExercise.name);
		//TODO Init exerciseViewRow.lineSegmenter if not already
		ViewExerciseView.Instance.exerciseViewRow.lineSegmenter.ShowSegmentCummulativelyLit (ActiveWorkout.exerciseData.IndexOf(ActiveExercise));

		ViewExerciseView.Instance.setsViewRow.lineSegmenter.Init (ActiveExercise.totalInitialSets);
		ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);

		int activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));

		ViewExerciseView.Instance.UpdateSetsView (activeSet, ActiveExercise.totalInitialSets);
		ViewExerciseView.Instance.UpdateRepsView (ActiveExercise.repsPerSet);
		ViewExerciseView.Instance.UpdateWeightView (ActiveExercise.weight);

		ViewExerciseView.Instance.fitBoyAnimator.Init(ActiveExercise.exerciseType);
	}

	void EstablishNextExercise(){
		if(activeExerciseIndex < ActiveWorkout.exerciseData.Count - 1){
			NextExercise = ActiveWorkout.exerciseData[activeExerciseIndex + 1];
			Footer.Instance.WorkoutControlsContatiner.ShowPeakButton ();
			_nextUpTextController.ShowNextExerciseText (NextExercise);
		}else{
			NextExercise = null;
			Footer.Instance.WorkoutControlsContatiner.HidePeakButton ();
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
				exercise.weight,
				exercise.exerciseType
			);

			ActiveWorkout.exerciseData.Add(newExercise);
		}

		timeSlider.gameObject.SetActive (true);

		activeExerciseIndex = exerciseIndex;
		EstablishPreviousExercise ();
		EstablishActiveExercise();
		EstablishNextExercise();
		secondsRemaining = ActiveExercise.secondsToCompleteSet;
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
