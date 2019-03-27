using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IconSelectMenu : MonoBehaviour {

	[HideInInspector] public EditExercisePanel controller;
	[SerializeField] private GameObject _container;
	[SerializeField] private SelectableFitBoy selectablefitBoyAnimatorPrefab;

	public GridLayoutGroup gridLayoutGroup;

	public void ShowExerciseIcons()
	{
		_container.SetActive (true);

		ExerciseType exerciseType;

		for(int i = 0; i < Enum.GetNames(typeof(ExerciseType)).Length; i++) 
		{
			SelectableFitBoy newFitBoyAnimator = Instantiate (selectablefitBoyAnimatorPrefab);
			newFitBoyAnimator.controller = controller;
			exerciseType = (ExerciseType)i;
			newFitBoyAnimator.Init (exerciseType);
			newFitBoyAnimator.transform.SetParent (gridLayoutGroup.transform);
			newFitBoyAnimator.transform.localScale = Vector3.one;
		}
	}

	public void Hide()
	{
		foreach (SelectableFitBoy newFitBoyAnimator in gridLayoutGroup.GetComponentsInChildren<SelectableFitBoy>())
		{
			Destroy(newFitBoyAnimator.gameObject);
		}

		_container.SetActive (false);
	}
}
