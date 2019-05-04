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

	void HandleBackPressed()
	{
		_controller.HandleBackPressed ();
	}

	void HandlePlayPressed()
	{
		_controller.Play ();
	}

	void HandlePausePressed()
	{
		_controller.Pause ();
	}

	void HandleNextPressed()
	{
		_controller.GoToNextSet ();
	}
}
