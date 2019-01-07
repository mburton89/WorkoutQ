using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutHUD : MonoBehaviour {

	public enum Mode
	{
		ViewingWorkouts,
		ViewingExercises,
		PlayingExercises
	}

	public static WorkoutHUD Instance;

	public GridLayoutGroup workoutPanelsGridLayoutGroup;
	public GridLayoutGroup exercisePanelsGridLayoutGroup;
	public GridLayoutGroup playModeExercisePanelsGridLayoutGroup;

	[SerializeField]private WorkoutPanel WorkoutMenuItemPrefab;
	[SerializeField]private ExercisePanel ExerciseMenuItemPrefab;

	[SerializeField]private Button addWorkoutPanelButton;
	[SerializeField]private Button addExercisePanelButton;

	[HideInInspector]public UIPanel selectedPanel;
	[HideInInspector]public GridLayoutGroup activeGridLayout;

	[SerializeField]private GameObject _raycastBlocker;

	public Mode currentMode;

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

		currentMode = Mode.ViewingWorkouts;
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

		_raycastBlocker.SetActive (false);

		currentMode = Mode.ViewingWorkouts;
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

		currentMode = Mode.ViewingExercises;
	}

	public void PlayActiveWorkout()
	{
		addExercisePanelButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;

		PlayModeManager.Instance.PlayWorkout(WorkoutManager.Instance.ActiveWorkout);

		_raycastBlocker.SetActive (true);

		currentMode = Mode.PlayingExercises;
	}

	void AddWorkoutPanel(WorkoutData workoutData){
		WorkoutPanel newWorkoutPanel = Instantiate(WorkoutMenuItemPrefab);

		if(workoutData != null){
			newWorkoutPanel.workoutData = workoutData;
		}

		newWorkoutPanel.UpdateText();
		newWorkoutPanel.UpdateColor();

		newWorkoutPanel.transform.SetParent(workoutPanelsGridLayoutGroup.transform);
		newWorkoutPanel.transform.localScale = Vector3.one;
	}

	void AddExercisePanel(WorkoutData workoutData, ExerciseData exerciseData)
	{
		ExercisePanel newExerciseMenuItem = Instantiate(ExerciseMenuItemPrefab);

		if(workoutData != null)
		{
			exerciseData = new ExerciseData();
			workoutData.exerciseData.Add(exerciseData);
		}

		if(exerciseData != null)
		{
			newExerciseMenuItem.exerciseData = exerciseData;
//			newExerciseMenuItem.PopulateFields (
//				exerciseData.name,
//				exerciseData.secondsToCompleteSet,
//				exerciseData.totalSets,
//				exerciseData.repsPerSet,
//				exerciseData.weight
//			);

			newExerciseMenuItem.exerciseName.text = exerciseData.name;
			newExerciseMenuItem.timeNumberCircle.UpdateValue(exerciseData.secondsToCompleteSet); //TODO put these lines in own method to populate panel
			newExerciseMenuItem.setsNumberCircle.UpdateValue(exerciseData.totalSets);
			newExerciseMenuItem.repsNumberCircle.UpdateValue(exerciseData.repsPerSet);
			newExerciseMenuItem.weightNumberCircle.UpdateValue(exerciseData.weight);
		}

		newExerciseMenuItem.UpdateColor(); 
		newExerciseMenuItem.transform.SetParent(exercisePanelsGridLayoutGroup.transform);
		newExerciseMenuItem.transform.localScale = Vector3.one;
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
