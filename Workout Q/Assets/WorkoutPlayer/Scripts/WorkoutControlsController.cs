using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutControlsController : MonoBehaviour 
{
	private WorkoutPlayerController _controller;

	[SerializeField] private HighlightButton _backButton;
	[SerializeField] private HighlightButton _playButton;
	[SerializeField] private HighlightButton _pauseButton;
	[SerializeField] private HighlightButton _nextButton;

	public void Init(WorkoutPlayerController workoutPlayerController)
	{
		_controller = workoutPlayerController;
	}

	void OnEnable()
	{
		_backButton.onClick.AddListener (HandleBackPressed);
		_playButton.onClick.AddListener (HandlePlayPressed);
		_pauseButton.onClick.AddListener (HandlePausePressed);
		_nextButton.onClick.AddListener (HandleNextPressed);
	}

	void OnDisable()
	{
		_backButton.onClick.RemoveListener (HandleBackPressed);
		_playButton.onClick.RemoveListener (HandlePlayPressed);
		_pauseButton.onClick.RemoveListener (HandlePausePressed);
		_nextButton.onClick.RemoveListener (HandleNextPressed);
	}

	void HandleBackPressed()
	{
		SoundManager.Instance.PlayButtonPressSound ();
		_controller.HandleBackPressed ();
	}

	void HandlePlayPressed()
	{
		SoundManager.Instance.PlayButtonPressSound ();
		_controller.Play ();
	}

	void HandlePausePressed()
	{
		SoundManager.Instance.PlayButtonPressSound ();
		_controller.Pause ();
	}

	void HandleNextPressed()
	{
		SoundManager.Instance.PlayButtonPressSound ();
		_controller.GoToNextSet ();
	}

	public void ShowPausedButtons()
	{
		_playButton.gameObject.SetActive (true);
		_pauseButton.gameObject.SetActive (false);
	}

	public void ShowPlayingButtons()
	{
		_playButton.gameObject.SetActive (false);
		_pauseButton.gameObject.SetActive (true);
	}
}
