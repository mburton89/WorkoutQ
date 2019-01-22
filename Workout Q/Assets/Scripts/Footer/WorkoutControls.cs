using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutControls : MonoBehaviour {
	
	[SerializeField]private Button playButton;
	[SerializeField]private Button pauseButton;
	[SerializeField]private Button previousSetButton;
	[SerializeField]private Button nextSetButton;
	[SerializeField]private Button previousExerciseButton;
	[SerializeField]private Button nextExerciseButton;
	public Button editButton;

	void OnEnable()
	{
		playButton.onClick.AddListener(HandlePlayPressed);
		pauseButton.onClick.AddListener(HandlePausePressed);
		previousSetButton.onClick.AddListener(HandlePreviousSetPressed);
		nextSetButton.onClick.AddListener(HandleNextSetPressed);
		previousExerciseButton.onClick.AddListener(HandlePreviousExercisePressed);
		nextExerciseButton.onClick.AddListener(HandleNextExercisePressed);
		editButton.onClick.AddListener (HandleEditPressed);
	}

	void OnDisable()
	{
		playButton.onClick.RemoveListener(HandlePlayPressed);
		pauseButton.onClick.RemoveListener(HandlePausePressed);
		previousSetButton.onClick.RemoveListener(HandlePreviousSetPressed);
		nextSetButton.onClick.RemoveListener(HandleNextSetPressed);
		previousExerciseButton.onClick.RemoveListener(HandlePreviousExercisePressed);
		nextExerciseButton.onClick.RemoveListener(HandleNextExercisePressed);
		editButton.onClick.RemoveListener (HandleEditPressed);
	}

	void HandlePlayPressed()
	{
		ShowCurrentlyPlayingMenu();

		if(PlayModeManager.Instance.isPaused){
			PlayModeManager.Instance.Resume();
		}else{
			//WorkoutHUD.Instance.PlayActiveWorkout((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise)));
			WorkoutHUD.Instance.PlayActiveWorkout((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise)));
		}

		SoundManager.Instance.PlayButtonPressSound ();
	}

	void HandlePausePressed()
	{
		ShowPausedMenu();

		playButton.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive(false);
		previousSetButton.gameObject.SetActive(false);
		nextSetButton.gameObject.SetActive(false);
		editButton.gameObject.SetActive(true);

		PlayModeManager.Instance.Pause();

		SoundManager.Instance.PlayButtonPressSound ();
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
		WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) - 1);

		SoundManager.Instance.PlayButtonPressSound ();
	}

	void HandleNextExercisePressed()
	{
		WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) + 1);

		SoundManager.Instance.PlayButtonPressSound ();
	}

	public void ShowPausedMenu(){
		playButton.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive(false);
		previousSetButton.gameObject.SetActive(false);
		nextSetButton.gameObject.SetActive(false);
		previousExerciseButton.gameObject.SetActive(false);
		nextExerciseButton.gameObject.SetActive(false);
	}

	public void ShowCurrentlyPlayingMenu(){
		playButton.gameObject.SetActive(false);
		pauseButton.gameObject.SetActive(true);
		previousSetButton.gameObject.SetActive(true);
		nextSetButton.gameObject.SetActive(true);
		previousExerciseButton.gameObject.SetActive(false);
		nextExerciseButton.gameObject.SetActive(false);
		editButton.gameObject.SetActive(false);
		Footer.Instance.UpdateTitle ("SEC: ");
	}

	public void ShowEditingExerciseMenu()
	{
		playButton.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive(false);
		previousSetButton.gameObject.SetActive(false);
		nextSetButton.gameObject.SetActive(false);
		previousExerciseButton.gameObject.SetActive(true);
		nextExerciseButton.gameObject.SetActive(true);
	}

	public void HandleEditPressed()
	{
		editButton.gameObject.SetActive(false);
		PlayModeManager.Instance.isPaused = false;
		WorkoutManager.Instance.workoutHUD.ShowEditStatsViewForExerciseAtIndex(PlayModeManager.Instance.activeExerciseIndex);
		previousExerciseButton.gameObject.SetActive(true);
		nextExerciseButton.gameObject.SetActive(true);
	}
}
