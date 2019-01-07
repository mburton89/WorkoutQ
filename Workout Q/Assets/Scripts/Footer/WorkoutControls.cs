using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutControls : MonoBehaviour {
	
	[SerializeField]private Button playButton;
	[SerializeField]private Button pauseButton;
	[SerializeField]private Button previousButton;
	[SerializeField]private Button nextButton;

	void OnEnable()
	{
		playButton.onClick.AddListener(HandlePlayPressed);
		pauseButton.onClick.AddListener(HandlePausePressed);
		previousButton.onClick.AddListener(HandlePreviousPressed);
		nextButton.onClick.AddListener(HandleNextPressed);
	}

	void OnDisable()
	{
		playButton.onClick.RemoveListener(HandlePlayPressed);
		pauseButton.onClick.RemoveListener(HandlePausePressed);
		previousButton.onClick.RemoveListener(HandlePreviousPressed);
		nextButton.onClick.RemoveListener(HandleNextPressed);
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
		previousButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive(false);

		PlayModeManager.Instance.Pause();
	}

	void HandlePreviousPressed()
	{
		PlayModeManager.Instance.IncrementSetsRemaining();
	}

	void HandleNextPressed()
	{
		PlayModeManager.Instance.DecrementSetsRemaining();
	}

	public void ShowPausedMenu(){
		playButton.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive(false);
		previousButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive(false);
	}

	public void ShowCurrentlyPlayingMenu(){
		playButton.gameObject.SetActive(false);
		pauseButton.gameObject.SetActive(true);
		previousButton.gameObject.SetActive(true);
		nextButton.gameObject.SetActive(true);
	}
}
