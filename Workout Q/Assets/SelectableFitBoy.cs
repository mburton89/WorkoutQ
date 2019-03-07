using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableFitBoy : FitBoyAnimator {

	[HideInInspector] public EditExercisePanel controller;
	[SerializeField] private Button _button;

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
		controller.UpdateIcon (exerciseType);
	}
}
