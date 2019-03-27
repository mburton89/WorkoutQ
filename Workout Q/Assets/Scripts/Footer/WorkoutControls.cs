using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutControls : MonoBehaviour {
	
	[SerializeField]private ShadowButton _playButton;
	[SerializeField]private ShadowButton _pauseButton;
	[SerializeField]private ShadowButton _previousSetButton;
	[SerializeField]private ShadowButton _nextSetButton;
	[SerializeField]private ShadowButton _previousExerciseButton;
	[SerializeField]private ShadowButton _nextExerciseButton;
	[SerializeField]private ShadowButton _peakNextButton;
	public ShadowButton editButton;

	void OnEnable()
	{
		_playButton.onShortClick.AddListener(HandlePlayPressed);
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
		_playButton.onShortClick.RemoveListener(HandlePlayPressed);
		_pauseButton.onShortClick.RemoveListener(HandlePausePressed);
		_previousSetButton.onShortClick.RemoveListener(HandlePreviousSetPressed);
		_nextSetButton.onShortClick.RemoveListener(HandleNextSetPressed);
		_previousExerciseButton.onShortClick.RemoveListener(HandlePreviousExercisePressed);
		_nextExerciseButton.onShortClick.RemoveListener(HandleNextExercisePressed);
		_peakNextButton.onPointerDown.RemoveListener(HandlePeakPressed);
		_peakNextButton.onPointerUp.RemoveListener(HandlePeakLetGo);
		editButton.onShortClick.RemoveListener (HandleEditPressed);
	}

	void HandlePlayPressed()
	{
		ShowCurrentlyPlayingMenu();

		if(PlayModeManager.Instance.isPaused){
			PlayModeManager.Instance.Resume();
		}else{
			//WorkoutHUD.Instance.PlayActiveWorkout((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise)));

			Header.Instance.lineSegmenter.gameObject.SetActive (true);
			WorkoutHUD.Instance.PlayActiveWorkout((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise)));
		}
	}

	void HandlePausePressed()
	{
		ShowPausedMenu();

		_playButton.gameObject.SetActive(true);
		_pauseButton.gameObject.SetActive(false);
		_previousSetButton.gameObject.SetActive(false);
		_nextSetButton.gameObject.SetActive(false);
		editButton.gameObject.SetActive(true);

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

	void HandlePreviousExercisePressed()
	{
		int index = WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) - 1;
		if (index > -1) {
			WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (index);
		}
	}

	void HandleNextExercisePressed()
	{
		int index = WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) + 1;
		if (index < WorkoutManager.Instance.ActiveWorkout.exerciseData.Count) {
			WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) + 1);
		}
	}

	public void ShowPausedMenu(){
		_playButton.gameObject.SetActive(true);
		_pauseButton.gameObject.SetActive(false);
		_previousSetButton.gameObject.SetActive(false);
		_nextSetButton.gameObject.SetActive(false);
		_previousExerciseButton.gameObject.SetActive(false);
		_nextExerciseButton.gameObject.SetActive(false);
		_peakNextButton.gameObject.SetActive (false);
	}

	public void ShowCurrentlyPlayingMenu(){
		_playButton.gameObject.SetActive(false);
		_pauseButton.gameObject.SetActive(true);
		_previousSetButton.gameObject.SetActive(true);
		_nextSetButton.gameObject.SetActive(true);
		_previousExerciseButton.gameObject.SetActive(false);
		_nextExerciseButton.gameObject.SetActive(false);
		_peakNextButton.gameObject.SetActive (true);
		editButton.gameObject.SetActive(false);
		Footer.Instance.UpdateTitle ("SEC: ");
	}

	public void ShowEditingExerciseMenu()
	{
		_playButton.gameObject.SetActive(true);
		_pauseButton.gameObject.SetActive(false);
		_previousSetButton.gameObject.SetActive(false);
		_nextSetButton.gameObject.SetActive(false);
		_previousExerciseButton.gameObject.SetActive(true);
		_nextExerciseButton.gameObject.SetActive(true);
		_peakNextButton.gameObject.SetActive (false);
	}

	public void HandleEditPressed()
	{
		editButton.gameObject.SetActive(false);
		PlayModeManager.Instance.isPaused = false;
		WorkoutManager.Instance.workoutHUD.ShowEditStatsViewForExerciseAtIndex(PlayModeManager.Instance.activeExerciseIndex);
		_previousExerciseButton.gameObject.SetActive(true);
		_nextExerciseButton.gameObject.SetActive(true);
		_peakNextButton.gameObject.SetActive (false);
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
}
