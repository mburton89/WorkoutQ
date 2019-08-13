using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour 
{
    public static PanelMover Instance;

	[SerializeField]private HighlightButton _deleteButton;
	[SerializeField]private HighlightButton _moveUpButton;
	[SerializeField]private HighlightButton _moveDownButton;
	[SerializeField]private HighlightButton _dismissButton;
	[SerializeField]private HighlightButton _duplicateButton;

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
	{
		_moveUpButton.onClick.AddListener(MovePanelUp);
		_deleteButton.onClick.AddListener(DeletePanel);
		_moveDownButton.onClick.AddListener(MovePanelDown);
		_dismissButton.onClick.AddListener (Confirm);
		_duplicateButton.onClick.AddListener(Duplicate);
	}

	void OnDisable()
	{
		_moveUpButton.onClick.RemoveListener(MovePanelUp);
		_deleteButton.onClick.RemoveListener(DeletePanel);
		_moveDownButton.onClick.RemoveListener(MovePanelDown);
		_dismissButton.onClick.RemoveListener(Confirm);
		_duplicateButton.onClick.RemoveListener(Duplicate);
	}

	void DeletePanel()
	{
        if(WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts)
        {
            AreYouSurePanel.Instance.ShowForDelete();
        }
        else
        {
            TrashBin.Instance.ThrowInTrash(WorkoutManager.Instance.workoutHUD.selectedPanel.gameObject.transform);
            SaveExercisePanelOrder();
            WorkoutManager.Instance.Save();
            Confirm();
        }
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

	public void Confirm()
	{
		WorkoutManager.Instance.workoutHUD.selectedPanel.Deselect();
		gameObject.SetActive (false);
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

	void Duplicate()
	{
		if(WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts)
		{
			WorkoutPanel workoutPanelToCopy = WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<WorkoutPanel> ();
			int workoutPanelToCopyIndex = workoutPanelToCopy.transform.GetSiblingIndex ();
			WorkoutData copiedWorkout = WorkoutData.Copy(workoutPanelToCopy.workoutData);
			WorkoutPanel newWorkoutPanel = WorkoutHUD.Instance.AddWorkoutPanel (copiedWorkout, false);
			newWorkoutPanel.transform.SetSiblingIndex (workoutPanelToCopyIndex + 1);
			SaveExercisePanelOrder();
			WorkoutManager.Instance.Save();
			Confirm ();
		}
		else
		{
			ExerciseMenuItem exerciseMenuItemToCopy = WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<ExerciseMenuItem> ();
			int exerciseMenuItemToCopyIndex = exerciseMenuItemToCopy.transform.GetSiblingIndex ();

			print ("exerciseMenuItemToCopy.exerciseData.name" + exerciseMenuItemToCopy.exerciseData.name);

			ExerciseData copiedExercise = ExerciseData.Copy(
				exerciseMenuItemToCopy.exerciseData.name,
				exerciseMenuItemToCopy.exerciseData.secondsToCompleteSet,
				exerciseMenuItemToCopy.exerciseData.totalInitialSets,
				exerciseMenuItemToCopy.exerciseData.totalSets,
				exerciseMenuItemToCopy.exerciseData.repsPerSet,
				exerciseMenuItemToCopy.exerciseData.weight,
				exerciseMenuItemToCopy.exerciseData.exerciseType
			);

			ExerciseMenuItem newExerciseMenuItem = WorkoutHUD.Instance.AddExercisePanel (null, copiedExercise, false);
			newExerciseMenuItem.transform.SetSiblingIndex (exerciseMenuItemToCopyIndex + 1);
			SaveExercisePanelOrder();
			WorkoutManager.Instance.Save();
			Confirm ();
		}
	}
}
