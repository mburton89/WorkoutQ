﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutPanel : UIPanel {

	public WorkoutData workoutData;
	[SerializeField]private TMP_InputField _workoutName;
	[SerializeField]private TextMeshProUGUI _minutesLabel;
	public Button selfButton;
	public FitBoyIlluminator fitBoyIlluminator;
	[SerializeField] private Button editButton;

	void OnEnable()
	{
		_workoutName.onSubmit.AddListener(delegate{HandleTitleChanged();});

		if (editButton != null) {
			editButton.onClick.AddListener (HandleEditPressed);		
		}
	}

	void OnDisable()
	{
		_workoutName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});

		if (editButton != null) {
			editButton.onClick.RemoveListener (HandleEditPressed);
		}
	}

	public void Init(WorkoutData workoutData)
	{
		this.workoutData = workoutData;
		UpdateColor ();
		fitBoyIlluminator.Init(workoutData.workoutType);
		UpdateText ();
	}

	void Awake()
	{
		if(workoutData != null){
			UpdateText();
		}
	}

	public void UpdateText()
	{
		workoutData.EstablishMinutes();
		_workoutName.text = workoutData.name;
		_minutesLabel.text = workoutData.minutes + " min";
	}

	public void HandleSelfClicked(){
		WorkoutManager.Instance.ActiveWorkout = workoutData;
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout(workoutData);
		Unhighlight ();

		SoundManager.Instance.PlayButtonPressSound ();
	}

//	public void HandleSelfClickedOnAddMenu()
//    {
//        Unhighlight();
//
//		WorkoutData copiedWorkout = new WorkoutData ();
//		copiedWorkout.name = workoutData.name;
//		copiedWorkout.workoutType = workoutData.workoutType;
//		copiedWorkout.exerciseData = new List<ExerciseData> ();
//
//		foreach(ExerciseData exercise in workoutData.exerciseData){
//
//			ExerciseData copiedExercise = ExerciseData.Copy(
//				exercise.name,
//				exercise.secondsToCompleteSet,
//				exercise.totalSets,
//				exercise.repsPerSet,
//				exercise.weight,
//				exercise.exerciseType
//			);
//
//			copiedWorkout.exerciseData.Add(copiedExercise);
//		}
//
//		WorkoutHUD.Instance.AddWorkoutPanel(copiedWorkout, false);
//        SoundManager.Instance.PlayButtonPressSound();
//		WorkoutManager.Instance.Save();
//
//		AddPanel.Instance.Exit ();
//
//		Canvas.ForceUpdateCanvases ();
//		WorkoutHUD.Instance.workoutsScrollRect.verticalScrollbar.value = 0f;
//		Canvas.ForceUpdateCanvases ();
//    }

	public void HandleSelfClickedOnAddMenu()
	{
		Unhighlight();
		AddPanel.Instance.ShowExercisesForWorkout (workoutData);
	}

	public void HandleSelfClickedOnAddPlanMenu()
	{
		AddPlanPanel.Instance.ShowExercisesForWorkout (this.workoutData);
	}

	void HandleTitleChanged(){
		workoutData.name = _workoutName.text;
		WorkoutManager.Instance.Save();
	}

	public void SelectTitle()
	{
		_workoutName.Select();
	}

	void HandleEditPressed()
	{
		EditWorkoutPanel.Instance.Init (this, false, false);
	}
}
