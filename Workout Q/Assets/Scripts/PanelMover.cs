using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour 
{
	[SerializeField]private Button deleteButton;
	[SerializeField]private Button moveUpButton;
	[SerializeField]private Button moveDownButton;
	[SerializeField]private Button dismissButton;

	void OnEnable()
	{
		moveUpButton.onClick.AddListener(MovePanelUp);
		deleteButton.onClick.AddListener(DeletePanel);
		moveDownButton.onClick.AddListener(MovePanelDown);
		dismissButton.onClick.AddListener(Hide);
	}

	void OnDisable()
	{
		moveUpButton.onClick.RemoveListener(MovePanelUp);
		deleteButton.onClick.RemoveListener(DeletePanel);
		moveDownButton.onClick.RemoveListener(MovePanelDown);
		dismissButton.onClick.RemoveListener(Hide);
	}

	void DeletePanel()
	{
		Destroy(WorkoutManager.Instance.workoutHUD.selectedPanel.gameObject);
		WorkoutManager.Instance.Save();
	}

	void MovePanelUp()
	{
		int siblingIndex = WorkoutManager.Instance.workoutHUD.selectedPanel.transform.GetSiblingIndex();

		if(siblingIndex > 0)
		{
			WorkoutManager.Instance.workoutHUD.selectedPanel.transform.SetSiblingIndex(siblingIndex - 1);
		}
		SaveExercisePanelOrder();
		WorkoutManager.Instance.Save();
	}

	void MovePanelDown()
	{
		int siblingIndex = WorkoutManager.Instance.workoutHUD.selectedPanel.transform.GetSiblingIndex();
		int childrenCount = WorkoutManager.Instance.workoutHUD.activeGridLayout.transform.childCount;

		if(siblingIndex < childrenCount)
		{
			WorkoutManager.Instance.workoutHUD.selectedPanel.transform.SetSiblingIndex(siblingIndex + 1);
		}
		SaveExercisePanelOrder();
		WorkoutManager.Instance.Save();
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	void SaveExercisePanelOrder(){
		if(WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<ExercisePanel>())
		{
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Clear();
			print("SaveExercisePanelOrder");
			foreach(ExercisePanel panel in WorkoutManager.Instance.workoutHUD.exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExercisePanel>())
			{
				WorkoutManager.Instance.ActiveWorkout.exerciseData.Add(panel.exerciseData);
			}
		}
	}
}
