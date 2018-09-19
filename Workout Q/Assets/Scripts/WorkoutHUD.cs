using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutHUD : MonoBehaviour {

	public static WorkoutHUD Instance;

	public GridLayoutGroup workoutPanelsGridLayoutGroup;
	public GridLayoutGroup exercisePanelsGridLayoutGroup;
	public GridLayoutGroup playModeExercisePanelsGridLayoutGroup;

	[SerializeField]private WorkoutPanel WorkoutPanelPrefab;
	[SerializeField]private ExercisePanel ExercisePanelPrefab;

	[SerializeField]private Button addWorkoutPanelButton;
	[SerializeField]private Button addExercisePanelButton;

	[HideInInspector]public UIPanel selectedPanel;
	[HideInInspector]public GridLayoutGroup activeGridLayout;

	void OnEnable(){
		addWorkoutPanelButton.onClick.AddListener(delegate{AddWorkoutPanel(null);});
		addExercisePanelButton.onClick.AddListener(delegate{AddExercisePanel(WorkoutManager.Instance.ActiveWorkout, null);});
	}

	void OnDisable(){
		addWorkoutPanelButton.onClick.RemoveListener(delegate{AddWorkoutPanel(null);});
		addExercisePanelButton.onClick.RemoveListener(delegate{AddExercisePanel(WorkoutManager.Instance.ActiveWorkout, null);});
	}

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
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
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		foreach(ExercisePanel panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExercisePanel>()){
			Destroy(panel.gameObject);
		}

		Footer.Instance.Hide();
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen)
	{
		Header.Instance.SetUpForExercisesMenu(workoutToOpen);
		addWorkoutPanelButton.transform.localScale = Vector3.zero;
		addExercisePanelButton.transform.localScale = Vector3.one;

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		foreach(ExerciseData exercise in workoutToOpen.exerciseData){
			AddExercisePanel(null, exercise);
		}

		Footer.Instance.ShowWorkoutControls();
		Footer.Instance.WorkoutControlsContatiner.ShowPausedMenu();
	}

	public void PlayActiveWorkout()
	{
		addExercisePanelButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;

		PlayModeManager.Instance.PlayWorkout(WorkoutManager.Instance.ActiveWorkout);
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
			workoutData.exerciseData.Add(exerciseData);
		}

		if(exerciseData != null)
		{
			newExercisePanel.exerciseData = exerciseData;
			newExercisePanel.exerciseName.text = exerciseData.name;
			newExercisePanel.timeNumberCircle.UpdateValue(exerciseData.secondsToCompleteSet); //TODO put these lines in own method to populate panel
			newExercisePanel.setsNumberCircle.UpdateValue(exerciseData.totalSets);
			newExercisePanel.repsNumberCircle.UpdateValue(exerciseData.repsPerSet);
			newExercisePanel.weightNumberCircle.UpdateValue(exerciseData.weight);
		}

		newExercisePanel.transform.SetParent(exercisePanelsGridLayoutGroup.transform);
		newExercisePanel.transform.localScale = Vector3.one;
	}

	public void HandlePanelSelected(UIPanel panel){
		if(selectedPanel != null && selectedPanel != panel)
		{
			selectedPanel.Deselect();			
		}
			
		selectedPanel = panel;
		activeGridLayout = panel.GetComponentInParent<GridLayoutGroup>();

		Footer.Instance.ShowPanelMover();
	}
}
