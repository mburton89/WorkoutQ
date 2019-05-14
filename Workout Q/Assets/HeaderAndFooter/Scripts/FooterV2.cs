﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FooterV2 : MonoBehaviour 
{
	public static FooterV2 Instance;

	[SerializeField] private GameObject _viewingPlanButtonGroup;
	[SerializeField] private GameObject _viewingWorkoutButtonGroup;
	[SerializeField] private GameObject _viewingExerciseButtonGroup;
	[SerializeField] private GameObject _panelMovingButtonGroup;

	//Viewing PLAN Buttons
	[SerializeField] private HighlightButton _settingsButton;
	[SerializeField] private HighlightButton _addWorkoutButton;

	//Viewing WORKOUT Buttons
	[SerializeField] private HighlightButton _backToPlanButton;
	[SerializeField] private HighlightButton _startWorkoutButton;
	[SerializeField] private HighlightButton _addExerciseButton;
	[SerializeField] private HighlightButton _editWorkoutButton;

	//Viewing EXERCISE Buttons
	[SerializeField] private HighlightButton _backToWorkoutButton;
	[SerializeField] private HighlightButton _editExerciseButton;

	void Awake()
	{
		Instance = this;
	}

	void OnEnable()
	{
		_settingsButton.onClick.AddListener (HandleSETTINGSButtonPressed);
		_addWorkoutButton.onClick.AddListener (HandleADDWORKOUTButtonPressed);
		_backToPlanButton.onClick.AddListener (HandleBACKTOPLANButtonPressed);
		_startWorkoutButton.onClick.AddListener (HandleSTARTWORKOUTButtonPressed);
		_addExerciseButton.onClick.AddListener (HandleADDEXERCISEButtonPressed);
		_editWorkoutButton.onClick.AddListener (HandleEDITWORKOUTButtonPressed);
		_backToWorkoutButton.onClick.AddListener (HandleBACKTOWORKOUTButtonPressed);
		_editExerciseButton.onClick.AddListener (HandleEDITEXERCISEButtonPressed);
	}

	void OnDisable()
	{
		_settingsButton.onClick.RemoveListener (HandleSETTINGSButtonPressed);
		_addWorkoutButton.onClick.RemoveListener (HandleADDWORKOUTButtonPressed);
		_backToPlanButton.onClick.RemoveListener (HandleBACKTOPLANButtonPressed);
		_startWorkoutButton.onClick.RemoveListener (HandleSTARTWORKOUTButtonPressed);
		_addExerciseButton.onClick.RemoveListener (HandleADDEXERCISEButtonPressed);
		_editWorkoutButton.onClick.RemoveListener (HandleEDITWORKOUTButtonPressed);
		_backToWorkoutButton.onClick.RemoveListener (HandleBACKTOWORKOUTButtonPressed);
		_editExerciseButton.onClick.RemoveListener (HandleEDITEXERCISEButtonPressed);
	}

	public void ShowViewingPlanButtonGroup()
	{
		_viewingPlanButtonGroup.SetActive (true);
		_viewingWorkoutButtonGroup.SetActive (false);
		_viewingExerciseButtonGroup.SetActive (false);
	}

	public void ShowViewingWorkoutButtonGroup()
	{
		_viewingPlanButtonGroup.SetActive (false);
		_viewingWorkoutButtonGroup.SetActive (true);
		_viewingExerciseButtonGroup.SetActive (false);
	}

	public void ShowViewingExerciseButtonGroup()
	{
		_viewingPlanButtonGroup.SetActive (false);
		_viewingWorkoutButtonGroup.SetActive (false);
		_viewingExerciseButtonGroup.SetActive (true);
	}

	public void ShowPanelMoverButtonGroup()
	{
		_panelMovingButtonGroup.SetActive (true);
	}

	void HandleSETTINGSButtonPressed()
	{
		SetupPanel.Instance.Show ();
	}

	void HandleADDWORKOUTButtonPressed()
	{
		AddPanel.Instance.ShowForAddWorkouts();
	}

	void HandleBACKTOPLANButtonPressed()
	{
		WorkoutManager.Instance.workoutHUD.ShowWorkoutsMenu();
		Header.Instance.UpdateMiddleLabel (PlayerPrefs.GetString("userTitle"));
		WorkoutManager.Instance.ActiveWorkout.Reset ();
		ShowViewingPlanButtonGroup ();
	}

	void HandleSTARTWORKOUTButtonPressed()
	{
		WorkoutHUD.Instance.SetupExerciseToPlay (0);
		WorkoutPlayerController.Instance.Play ();
	}

	void HandleADDEXERCISEButtonPressed()
	{
		AddPanel.Instance.ShowForAddExercises();
	}

	void HandleEDITWORKOUTButtonPressed()
	{
		EditWorkoutPanel.Instance.Init (WorkoutManager.Instance.ActiveWorkout, false, false);
	}

	void HandleBACKTOWORKOUTButtonPressed()
	{
		WorkoutPlayerController.Instance.Exit ();
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout (WorkoutManager.Instance.ActiveWorkout);
		Header.Instance.UpdateMiddleLabel (WorkoutManager.Instance.ActiveWorkout.name);
		ShowViewingWorkoutButtonGroup ();
	}

	void HandleEDITEXERCISEButtonPressed()
	{
		EditExercisePanel.Instance.Init (WorkoutManager.Instance.ActiveExercise, false, false);
		EditExercisePanel.Instance.StoreCurrentExerciseSetsAndTime ((int)WorkoutPlayerController.Instance.secondsRemaining, WorkoutPlayerController.Instance.GetAmountOfCompleteSets ());
	}
}
