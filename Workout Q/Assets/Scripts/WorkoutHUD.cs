using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Mode
{
	ViewingWorkouts,
	ViewingExercises,
	EditingExercise,
	PlayingExercise
}

public class WorkoutHUD : MonoBehaviour {

	public static WorkoutHUD Instance;

	public GridLayoutGroup workoutPanelsGridLayoutGroup;
	public GridLayoutGroup exercisePanelsGridLayoutGroup;
	public GridLayoutGroup playModeExercisePanelsGridLayoutGroup;

	[SerializeField]private WorkoutPanel WorkoutMenuItemPrefab;
	[SerializeField]private ExerciseMenuItem _exerciseMenuItemPrefab;

	[SerializeField]private Button addWorkoutPanelButton;
	[SerializeField]private Button addExercisePanelButton;

	[HideInInspector]public UIPanel selectedPanel;
	[HideInInspector]public GridLayoutGroup activeGridLayout;

	[SerializeField]private GameObject _raycastBlocker;

	public Mode currentMode;

	[SerializeField] private EditExerciseView _editExerciseView;
	[SerializeField] private ViewExerciseView _viewExerciseView;

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
		_editExerciseView.Hide ();
		_viewExerciseView.Hide ();

		foreach(ExerciseMenuItem panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>()){
			Destroy(panel.gameObject);
		}

		Footer.Instance.Hide();

		currentMode = Mode.ViewingWorkouts;
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen)
	{
		foreach(ExerciseMenuItem panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>()){
			Destroy(panel.gameObject);
		}

		Header.Instance.SetUpForExercisesMenu(workoutToOpen.name);
		addWorkoutPanelButton.transform.localScale = Vector3.zero;
		addExercisePanelButton.transform.localScale = Vector3.one;

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		_editExerciseView.Hide ();
		_viewExerciseView.Hide ();

		foreach(ExerciseData exercise in workoutToOpen.exerciseData){
			AddExercisePanel(null, exercise);
		}

		Footer.Instance.ShowWorkoutControls();
		Footer.Instance.WorkoutControlsContatiner.ShowPausedMenu();

		currentMode = Mode.ViewingExercises;
	}

	public void ShowEditStatsViewForExercise(ExerciseData exerciseToOpen){
	
		Header.Instance.UpdateTitle(exerciseToOpen.name);

		addExercisePanelButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		_editExerciseView.Init (exerciseToOpen);
		_viewExerciseView.Init ("Exercise",
			WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf(exerciseToOpen),
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		Footer.Instance.ShowWorkoutControls();
		Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu();

		currentMode = Mode.EditingExercise;
	}

	public void ShowEditStatsViewForExerciseAtIndex(int index)
	{
		print ("index: " + index);

		if (index < 0 || index >= WorkoutManager.Instance.ActiveWorkout.exerciseData.Count)
		{
			return;
		} 

		ExerciseData nextExercise = WorkoutManager.Instance.ActiveWorkout.exerciseData [index];

		_editExerciseView.Init (nextExercise);
		_viewExerciseView.Init ("Exercise",
			WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf(nextExercise),
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		WorkoutManager.Instance.ActiveExercise = nextExercise;
	}

	public void PlayActiveWorkout()
	{
		Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout.name);

		addExercisePanelButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;
		_editExerciseView.Hide ();
		_viewExerciseView.Hide ();

		PlayModeManager.Instance.PlayWorkout(WorkoutManager.Instance.ActiveWorkout);

		currentMode = Mode.PlayingExercise;
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
		ExerciseMenuItem newExerciseMenuItem = Instantiate(_exerciseMenuItemPrefab);

		if(workoutData != null)
		{
			exerciseData = new ExerciseData();
			workoutData.exerciseData.Add(exerciseData);
		}

		if(exerciseData != null)
		{
			newExerciseMenuItem.Init (exerciseData);
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
