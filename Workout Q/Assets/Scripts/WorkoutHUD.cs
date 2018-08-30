using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutHUD : MonoBehaviour {

	public GridLayoutGroup workoutPanelsGridLayoutGroup;
	public GridLayoutGroup exercisePanelsGridLayoutGroup;

	[SerializeField]private WorkoutPanel WorkoutPanelPrefab;
	[SerializeField]private ExercisePanel ExercisePanelPrefab;

	[SerializeField]private Button addWorkoutPanelButton;
	[SerializeField]private Button addExercisePanelButton;

	void OnEnable(){
		addWorkoutPanelButton.onClick.AddListener(delegate{AddWorkoutPanel(null);});
		addExercisePanelButton.onClick.AddListener(delegate{AddExercisePanel(WorkoutManager.Instance.ActiveWorkout, null);});
	}

	void OnDisable(){
		addWorkoutPanelButton.onClick.RemoveListener(delegate{AddWorkoutPanel(null);});
		addExercisePanelButton.onClick.RemoveListener(delegate{AddExercisePanel(WorkoutManager.Instance.ActiveWorkout, null);});
	}

	void Start(){
		foreach(WorkoutData workout in WorkoutManager.Instance.workoutData){
			AddWorkoutPanel(workout);
		}
	}

	public void ShowWorkoutsMenu()
	{
		addWorkoutPanelButton.transform.localScale = Vector3.one;
		addExercisePanelButton.transform.localScale = Vector3.zero;

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.one;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		foreach(ExercisePanel panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExercisePanel>()){
			Destroy(panel.gameObject);
		}
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen)
	{
		Header.Instance.SetUpForExercisesMenu();
		addWorkoutPanelButton.transform.localScale = Vector3.zero;
		addExercisePanelButton.transform.localScale = Vector3.one;

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;

		foreach(ExerciseData exercise in workoutToOpen.exerciseData){
			AddExercisePanel(null, exercise);
		}
	}

	void AddWorkoutPanel(WorkoutData workoutData){
		WorkoutPanel newWorkoutPanel = Instantiate(WorkoutPanelPrefab);

		if(workoutData != null){
			newWorkoutPanel.workoutData = workoutData;
		}

		newWorkoutPanel.UpdateText();

		newWorkoutPanel.transform.SetParent(workoutPanelsGridLayoutGroup.transform);
		newWorkoutPanel.transform.localScale = Vector3.one;
	}

	void AddExercisePanel(WorkoutData workoutData, ExerciseData exerciseData){
		ExercisePanel newExercisePanel = Instantiate(ExercisePanelPrefab);

		if(workoutData != null)
		{
			exerciseData = new ExerciseData();
			exerciseData.parentWorkoutData = workoutData;
			workoutData.exerciseData.Add(exerciseData);
		}

		if(exerciseData != null)
		{
			newExercisePanel.exerciseData = exerciseData;
			newExercisePanel.exerciseName.text = exerciseData.name;
			newExercisePanel.timeNumberCircle.UpdateValue(exerciseData.secondsToCompleteSet);
			newExercisePanel.setsNumberCircle.UpdateValue(exerciseData.totalSets);
			newExercisePanel.repsNumberCircle.UpdateValue(exerciseData.repsPerSet);
			newExercisePanel.weightNumberCircle.UpdateValue(exerciseData.weight);
		}

		newExercisePanel.transform.SetParent(exercisePanelsGridLayoutGroup.transform);
		newExercisePanel.transform.localScale = Vector3.one;
	}
}
