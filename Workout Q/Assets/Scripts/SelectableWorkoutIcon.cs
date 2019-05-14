using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableWorkoutIcon : FitBoyIlluminator {

	[HideInInspector] public EditWorkoutPanel controller;
	[SerializeField] private Button _button;
	public Image bg;

//	public void Init(WorkoutType workoutType)
//	{
//		this.workoutType = workoutType;
//		glowFrameSprite = WorkoutGenerator.Instance.GetSpriteForWorkout(workoutType);
//		Play();
//	}

	void OnEnable()
	{
		_button.onClick.AddListener (HandleClicked);
	}

	void OnDisable()
	{
		_button.onClick.RemoveListener (HandleClicked);
	}

	void HandleClicked()
	{
		controller.UpdateIcon (workoutType);
	}
}
