using UnityEngine;
using UnityEngine.UI;
using System;

public class WorkoutIconSelectMenu : MonoBehaviour {

	[HideInInspector] public EditWorkoutPanel controller;
	[SerializeField] private GameObject _container;
	[SerializeField] private SelectableWorkoutIcon selectableWorkoutIconPrefab;

	public GridLayoutGroup gridLayoutGroup;

	public void ShowWorkoutIcons()
	{
		_container.SetActive (true);

		WorkoutType workoutType;

		for(int i = 0; i < Enum.GetNames(typeof(WorkoutType)).Length; i++) 
		{
			SelectableWorkoutIcon newSelectableWorkoutIcon = Instantiate (selectableWorkoutIconPrefab);
			newSelectableWorkoutIcon.controller = controller;
			workoutType = (WorkoutType)i;
			newSelectableWorkoutIcon.Init (workoutType);
			newSelectableWorkoutIcon.transform.SetParent (gridLayoutGroup.transform);
			newSelectableWorkoutIcon.transform.localScale = Vector3.one;
			newSelectableWorkoutIcon.bg.color = ColorManager.Instance.ActiveColorLight;
		}
	}

	public void Hide()
	{
		foreach (SelectableWorkoutIcon selectableWorkoutIcon in gridLayoutGroup.GetComponentsInChildren<SelectableWorkoutIcon>())
		{
			Destroy(selectableWorkoutIcon.gameObject);
		}

		_container.SetActive (false);
	}
}
