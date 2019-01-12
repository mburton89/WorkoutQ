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

	void OnEnable()
	{
		playButton.onClick.AddListener(HandlePlayPressed);
		pauseButton.onClick.AddListener(HandlePausePressed);
		previousSetButton.onClick.AddListener(HandlePreviousSetPressed);
		nextSetButton.onClick.AddListener(HandleNextSetPressed);
		previousExerciseButton.onClick.AddListener(HandlePreviousExercisePressed);
		nextExerciseButton.onClick.AddListener(HandleNextExercisePressed);
	}

	void OnDisable()
	{
		playButton.onClick.RemoveListener(HandlePlayPressed);
		pauseButton.onClick.RemoveListener(HandlePausePressed);
		previousSetButton.onClick.RemoveListener(HandlePreviousSetPressed);
		nextSetButton.onClick.RemoveListener(HandleNextSetPressed);
		previousExerciseButton.onClick.RemoveListener(HandlePreviousExercisePressed);
		nextExerciseButton.onClick.RemoveListener(HandleNextExercisePressed);
	}

	void HandlePlayPressed()
	{
		ShowCurrentlyPlayingMenu();

		if(PlayModeManager.Instance.isPaused){
			PlayModeManager.Instance.Resume();
		}else{
			WorkoutHUD.Instance.PlayActiveWorkout();
		}
	}

	void HandlePausePressed()
	{
		ShowPausedMenu();

		playButton.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive(false);
		previousSetButton.gameObject.SetActive(false);
		nextSetButton.gameObject.SetActive(false);

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
		print ("Hey there");
		WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) - 1);
	}

	void HandleNextExercisePressed()
	{
		WorkoutHUD.Instance.ShowEditStatsViewForExerciseAtIndex (WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (WorkoutManager.Instance.ActiveExercise) + 1);
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
}
