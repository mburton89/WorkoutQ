using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutControls : MonoBehaviour {

	[SerializeField]private ShadowButton _completeWorkoutButton;
	//[SerializeField]private ShadowButton _playButton;
	[SerializeField]private ShadowButton _restartButton;
	[SerializeField]private ShadowButton _pauseButton;
	[SerializeField]private ShadowButton _previousSetButton;
	[SerializeField]private ShadowButton _nextSetButton;
	[SerializeField]private ShadowButton _previousExerciseButton;
	[SerializeField]private ShadowButton _nextExerciseButton;
	[SerializeField]private ShadowButton _peakNextButton;
	public ShadowButton editButton;

	[SerializeField] private List<ShadowButton> _allButtons;

//	void Awake()
//	{
//		_allButtons.Add (_startWorkoutButton);
//		_allButtons.Add (_completeWorkoutButton);
//		_allButtons.Add (_playButton);
//		_allButtons.Add (_restartButton);
//		_allButtons.Add (_pauseButton);
//		_allButtons.Add (_previousSetButton);
//		_allButtons.Add (_nextSetButton);
//		_allButtons.Add (_previousExerciseButton);
//		_allButtons.Add (_nextExerciseButton);
//		_allButtons.Add (_peakNextButton);
//	}

	void OnEnable()
	{
		_completeWorkoutButton.onShortClick.AddListener(HandleCompleteWorkoutPressed);
		//_playButton.onShortClick.AddListener(HandlePlayPressed);
		_restartButton.onShortClick.AddListener(HandleRestartPressed);
		_pauseButton.onShortClick.AddListener(HandlePausePressed);
		_previousSetButton.onShortClick.AddListener(HandlePreviousSetPressed);
		_nextSetButton.onShortClick.AddListener(HandleNextSetPressed);
		_previousExerciseButton.onShortClick.AddListener(HandlePreviousExercisePressed);
		_nextExerciseButton.onShortClick.AddListener(HandleNextExercisePressed);
		_peakNextButton.onPointerDown.AddListener(HandlePeakPressed);
		_peakNextButton.onPointerUp.AddListener(HandlePeakLetGo);
		editButton.onShortClick.AddListener (HandleEditPressed);
	}

	void OnDisable()
	{
		_completeWorkoutButton.onShortClick.RemoveListener(HandleCompleteWorkoutPressed);
		//_playButton.onShortClick.RemoveListener(HandlePlayPressed);
		_restartButton.onShortClick.AddListener(HandleRestartPressed);
		_previousSetButton.onShortClick.RemoveListener(HandlePreviousSetPressed);
		_nextSetButton.onShortClick.RemoveListener(HandleNextSetPressed);
		_previousExerciseButton.onShortClick.RemoveListener(HandlePreviousExercisePressed);
		_nextExerciseButton.onShortClick.RemoveListener(HandleNextExercisePressed);
		_peakNextButton.onPointerDown.RemoveListener(HandlePeakPressed);
		_peakNextButton.onPointerUp.RemoveListener(HandlePeakLetGo);
		editButton.onShortClick.RemoveListener (HandleEditPressed);
	}

//	void HandlePlayPressed()
//	{
//		//ShowCurrentlyPlayingMenu();
//
//		if (!PlayModeManager.Instance.isPaused) {
//			print ("WorkoutManager.Instance.ActiveExercise.name: " + WorkoutManager.Instance.ActiveExercise.name);
//			WorkoutHUD.Instance.SetupExerciseToPlay((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise)));
//			print ("WorkoutManager.Instance.ActiveExercise.name: " + WorkoutManager.Instance.ActiveExercise.name);
//		}
//
//		PlayModeManager.Instance.Play ();
//
//		ShowCurrentlyPlayingMenu ();
//	}

	void HandlePlayPressed()
	{
	
	}

	void HandleRestartPressed()
	{
		ShowCurrentlyPlayingMenu();

		if(PlayModeManager.Instance.isPaused){
			PlayModeManager.Instance.RestartExerciseAndPlay();
		}else{
			//WorkoutHUD.Instance.SetupExerciseToPlay((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise)));
			PlayModeManager.Instance.RestartExerciseAndPlay ();
		}

		ShowCurrentlyPlayingMenu ();
	}

	public void HandlePausePressed()
	{
		ShowPausedMenu();

		_pauseButton.gameObject.SetActive(false);
		_previousSetButton.gameObject.SetActive(false);
		_nextSetButton.gameObject.SetActive(false);
		//editButton.gameObject.SetActive(true);

		PlayModeManager.Instance.Pause();
	}

	void HandlePreviousSetPressed()
	{
		PlayModeManager.Instance.IncrementSetsRemaining();
	}

	void HandleNextSetPressed()
	{
		PlayModeManager.Instance.DecrementSetsRemaining();
	}

	public void HandlePreviousExercisePressed()
	{
		int index = WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) - 1;
		if (index > -1) {
			//WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (index);
			WorkoutHUD.Instance.SetupExerciseToPlay(index);
		}
	}

	public void HandleNextExercisePressed()
	{
		int index = WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) + 1;
		if (index < WorkoutManager.Instance.ActiveWorkout.exerciseData.Count) {
			//WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) + 1);
			WorkoutHUD.Instance.SetupExerciseToPlay(index);
		}
	}

	public void ShowPausedMenu(){
		HideAllButtons ();

//		if (!WorkoutManager.Instance.ActiveWorkout.inProgress) {
//			//_startWorkoutButton.gameObject.SetActive (true);
//		} else {
//			if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) {
//				_completeWorkoutButton.gameObject.SetActive (true);
//			} else {
//				//_playButton.gameObject.SetActive(true);
//				_previousExerciseButton.gameObject.SetActive(true);
//				_nextExerciseButton.gameObject.SetActive(true);
//			}
//		}
	}

	public void ShowCurrentlyPlayingMenu(){
		HideAllButtons ();
		_pauseButton.gameObject.SetActive(true);
		_previousSetButton.gameObject.SetActive(true);
		_nextSetButton.gameObject.SetActive(true);
		_peakNextButton.gameObject.SetActive (true);
		Footer.Instance.UpdateTitle ("SEC: ");
	}

	public void ShowEditingExerciseMenu(bool shouldRestartExercise)
	{
		HideAllButtons ();

		if (shouldRestartExercise) {
			_restartButton.gameObject.SetActive (true);
		} else {
			//_playButton.gameObject.SetActive (true);
		}

		_previousExerciseButton.gameObject.SetActive(true);
		_nextExerciseButton.gameObject.SetActive(true);
	}

//	public void HandleEditPressed()
//	{
//		HideAllButtons ();
//
//		PlayModeManager.Instance.isPaused = false;
//		WorkoutManager.Instance.workoutHUD.ShowEditStatsViewForExerciseAtIndex(PlayModeManager.Instance.activeExerciseIndex);
//		_previousExerciseButton.gameObject.SetActive(true);
//		_nextExerciseButton.gameObject.SetActive(true);
//	}

	public void HandleEditPressed()
	{
		EditExercisePanel.Instance.Init (WorkoutManager.Instance.ActiveExercise, false, false);
	}

	public void ShowForWorkoutPreStarted()
	{
		HideAllButtons ();
		//_startWorkoutButton.gameObject.SetActive (true);
	}

	public void ShowForWorkoutPostStarted()
	{
		HideAllButtons ();
		_completeWorkoutButton.gameObject.SetActive (true);
	}

	void HandlePeakPressed()
	{
		PeakView.Instance.PeakAtExercise (PlayModeManager.Instance.NextExercise);
	}

	void HandlePeakLetGo()
    {
		PeakView.Instance.FinishPeaking ();
    }

	public void ShowPeakButton()
	{
		_peakNextButton.gameObject.SetActive(true);	
	}

	public void HidePeakButton()
	{
		_peakNextButton.gameObject.SetActive(false);	
	}

	void HideAllButtons()
	{
		foreach (ShadowButton button in _allButtons) {
			button.gameObject.SetActive (false);
		}
	}

	void HandleCompleteWorkoutPressed()
	{
		WorkoutManager.Instance.ActiveWorkout.Reset ();
		WorkoutHUD.Instance.ShowExercisesForWorkout (WorkoutManager.Instance.ActiveWorkout);
		WorkoutManager.Instance.Save ();
	}
}
