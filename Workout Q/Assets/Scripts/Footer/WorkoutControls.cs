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
		playButton.gameObject.SetActive(false);
		pauseButton.gameObject.SetActive(true);
		previousButton.gameObject.SetActive(true);
		nextButton.gameObject.SetActive(true);
	}

	void HandlePausePressed()
	{
		playButton.gameObject.SetActive(true);
		pauseButton.gameObject.SetActive(false);
		previousButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive(false);
	}

	void HandlePreviousPressed()
	{

	}

	void HandleNextPressed()
	{

	}
}
