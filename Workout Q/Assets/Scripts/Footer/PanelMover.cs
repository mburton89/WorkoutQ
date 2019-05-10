using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour 
{
	[SerializeField]private HighlightButton _deleteButton;
	[SerializeField]private HighlightButton _moveUpButton;
	[SerializeField]private HighlightButton _moveDownButton;
	[SerializeField]private HighlightButton _dismissButton;

	void OnEnable()
	{
		_moveUpButton.onClick.AddListener(MovePanelUp);
		_deleteButton.onClick.AddListener(DeletePanel);
		_moveDownButton.onClick.AddListener(MovePanelDown);
		_dismissButton.onClick.AddListener(Confirm);
	}

	void OnDisable()
	{
		_moveUpButton.onClick.RemoveListener(MovePanelUp);
		_deleteButton.onClick.RemoveListener(DeletePanel);
		_moveDownButton.onClick.RemoveListener(MovePanelDown);
		_dismissButton.onClick.RemoveListener(Confirm);
	}

	void DeletePanel()
	{
		TrashBin.Instance.ThrowInTrash(WorkoutManager.Instance.workoutHUD.selectedPanel.gameObject.transform);
		SaveExercisePanelOrder();
		WorkoutManager.Instance.Save();
		Confirm();
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

	void Confirm()
	{
		WorkoutManager.Instance.workoutHUD.selectedPanel.Deselect();
		gameObject.SetActive (false);
//		if (WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts) {
//			Footer.Instance.Hide ();		
//		} else {
//			Footer.Instance.ShowWorkoutControls ();
//		}
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	void SaveExercisePanelOrder(){
		if(WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<ExerciseMenuItem>())
		{
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Clear();
			print("SaveExercisePanelOrder");
			foreach(ExerciseMenuItem panel in WorkoutManager.Instance.workoutHUD.exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>())
			{
				WorkoutManager.Instance.ActiveWorkout.exerciseData.Add(panel.exerciseData);
			}
		}
	}
}
