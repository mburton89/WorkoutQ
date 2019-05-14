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
		
	void Update(){

		if(_isInPlayMode){
			
			//ActiveExercisePanel.timeNumberCircle.UpdateValue((int)_secondsRemaining);

//			if (!timeSlider.selectHandler.pointerIsDown) {
//				secondsRemaining -= Time.deltaTime;
//				timeSlider.slider.value = 1 - secondsRemaining/ActiveExercise.secondsToCompleteSet;
//			}

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

		//UNCOMMENT IF YOU WANT ABILITY TO DEDUCT COMPLETION OF A SET
//		if (secondsRemaining >= ActiveExercise.secondsToCompleteSet - 1) 
//		{
//			if (ActiveExercise.totalSets == ActiveExercise.totalInitialSets) {
//				activeExerciseIndex--;
//				EstablishPreviousExercise ();
//				EstablishActiveExercise ();
//				EstablishNextExercise ();
//			} else {
//				ActiveExercise.totalSets++;
//				//ActiveExercisePanel.setsNumberCircle.UpdateValue (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
//
//				int activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
//				string totalSets = ActiveExercise.totalInitialSets.ToString ();	
//
//				ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);
//				ViewExerciseView.Instance.UpdateSetsView (activeSet, ActiveExercise.totalInitialSets);
//			}
//		}
			
		secondsRemaining = ActiveExercise.secondsToCompleteSet + 1;
		ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);

		SoundManager.Instance.PlayGoBackSound ();
	}

	public void DecrementSetsRemaining(){
		if(ActiveExercise.totalSets == 1)
		{
			ActiveExercise.totalSets--;
			activeExerciseIndex ++;

			if (activeExerciseIndex == ActiveWorkout.exerciseData.Count) 
			{
				HandleWorkoutFinished ();
				return;
			}

			EstablishPreviousExercise ();
			EstablishActiveExercise();
			EstablishNextExercise();
			SoundManager.Instance.PlayNewExerciseSound ();
		}
		else
		{
			ActiveExercise.totalSets --;
			int activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));
			string totalSets = ActiveExercise.totalInitialSets.ToString ();
			ViewExerciseView.Instance.setsViewRow.UpdateLabel("SET: " + activeSet + " / " + totalSets);
			ViewExerciseView.Instance.UpdateSetsView (activeSet, ActiveExercise.totalInitialSets);
			SoundManager.Instance.PlayNewSetSound ();
			ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
		}

		secondsRemaining = ActiveExercise.secondsToCompleteSet;
	}

	void EstablishPreviousExercise(){
		if(activeExerciseIndex < ActiveWorkout.exerciseData.Count && activeExerciseIndex > 0){
			PreviousExercise = ActiveWorkout.exerciseData[activeExerciseIndex - 1];
			ViewExerciseView.Instance.SetupPreviousFitBoy (WorkoutGenerator.Instance.GetSpritesForExercise (PreviousExercise.exerciseType) [0]);
		}else{
			ViewExerciseView.Instance.HidePreviousFitBoy (); 
		}
	}

	public void EstablishActiveExercise()
	{
		if(activeExerciseIndex < ActiveWorkout.exerciseData.Count){
			ActiveExercise = ActiveWorkout.exerciseData[activeExerciseIndex];
			WorkoutManager.Instance.ActiveExercise = ActiveExercise;
		}

		Header.Instance.UpdateMiddleLabel ("XRC " + (activeExerciseIndex + 1) + " of " + ActiveWorkout.exerciseData.Count);

		ViewExerciseView.Instance.UpdateExerciseName (ActiveExercise.name);
		//TODO Init exerciseViewRow.lineSegmenter if not already
		print("ActiveWorkout.exerciseData.IndexOf(ActiveExercise): " + ActiveWorkout.exerciseData.IndexOf(ActiveExercise));

		int index = ActiveWorkout.exerciseData.IndexOf (ActiveExercise);
		ViewExerciseView.Instance.exerciseViewRow.lineSegmenter.ShowSegmentCummulativelyLit (index);
		ExerciseSlider.Instance.slider.value = index;

		ViewExerciseView.Instance.setsViewRow.lineSegmenter.Init (ActiveExercise.totalInitialSets);

//		print ("ActiveExercise.totalInitialSets: " + ActiveExercise.totalInitialSets);
//		print ("ActiveExercise.totalSets: " + ActiveExercise.totalSets);
//		print ("ActiveExercise.name: " + ActiveExercise.name);

		Pause ();

		if (ActiveExercise.totalSets <= 0) {
			ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentCummulativelyLit  (ActiveExercise.totalInitialSets - 1);
			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (true);
		} else {
			ViewExerciseView.Instance.setsViewRow.lineSegmenter.ShowSegmentBlinking (ActiveExercise.totalInitialSets - ActiveExercise.totalSets);
			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (false);
		}

		int activeSet = (ActiveExercise.totalInitialSets - (ActiveExercise.totalSets - 1));

		ViewExerciseView.Instance.UpdateSetsView (activeSet, ActiveExercise.totalInitialSets);
		ViewExerciseView.Instance.UpdateRepsView (ActiveExercise.repsPerSet);
		ViewExerciseView.Instance.UpdateWeightView (ActiveExercise.weight);
		_secondsLabel.SetText(ActiveExercise.secondsToCompleteSet.ToString());
		ViewExerciseView.Instance.fitBoyAnimator.Init(ActiveExercise.exerciseType);

		ViewExerciseView.Instance.fitBoyAnimator.Init(ActiveExercise.exerciseType);
	}

	void EstablishNextExercise(){
		if(activeExerciseIndex < ActiveWorkout.exerciseData.Count - 1){
			NextExercise = ActiveWorkout.exerciseData[activeExerciseIndex + 1];
			Footer.Instance.WorkoutControlsContatiner.ShowPeakButton ();
			_nextUpTextController.ShowNextExerciseText (NextExercise);
			ViewExerciseView.Instance.SetupNextFitBoy (WorkoutGenerator.Instance.GetSpritesForExercise(NextExercise.exerciseType)[0]);
		}else{
			NextExercise = null;
			_nextUpTextController.ShowNothing ();
			Footer.Instance.WorkoutControlsContatiner.HidePeakButton ();
			ViewExerciseView.Instance.HideNextFitBoy ();
		}
	}

	void HandleTimerHittingZero(){
		DecrementSetsRemaining();
	}

	public void SetUpExercise(WorkoutData workout, int exerciseIndex){

//		if (ActiveWorkout != null) {
//			ActiveWorkout.exerciseData.Clear ();
//		}

//		foreach(ExerciseData exercise in workout.exerciseData){
//
//			ExerciseData newExercise = ExerciseData.Copy(
//				exercise.name,
//				exercise.secondsToCompleteSet,
//				exercise.remainingSets,
//				exercise.repsPerSet,
//				exercise.weight,
//				exercise.exerciseType
//			);
//
//			ActiveWorkout.exerciseData.Add(newExercise);
//		}


		ActiveWorkout = workout;

		//timeSlider.gameObject.SetActive (true);

		activeExerciseIndex = exerciseIndex;
		EstablishPreviousExercise ();
		EstablishActiveExercise();
		EstablishNextExercise();
		secondsRemaining = ActiveExercise.secondsToCompleteSet;
		_isInPlayMode = false;

		Footer.Instance.ShowWorkoutControls();
		if (ActiveExercise.totalSets <= 0) {
			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (true);
		} else {
			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (false);
		}
	}

	public void Reset(){
		//ActiveWorkout.exerciseData.Clear();
		_isInPlayMode = false;
		isPaused = false;
//		ActiveExercisePanel.transform.localScale = Vector3.one;
//		NextExercisePanel.transform.localScale = Vector3.one;
	}

	public void Pause(){
		_isInPlayMode = false;
		isPaused = true;
	}

	public void Play(){
		_isInPlayMode = true;
		isPaused = false;

		ActiveWorkout.inProgress = true;
	}

	public void RestartExerciseAndPlay(){

		ActiveExercise.totalSets = ActiveExercise.totalInitialSets;
		ViewExerciseView.Instance.UpdateSetsView (1, ActiveExercise.totalInitialSets);
		_isInPlayMode = true;
		isPaused = false;
	}

	void HandleWorkoutFinished()
	{

	}
}
