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

	[SerializeField]private ShadowButton addWorkoutButton;
	[SerializeField]private ShadowButton addExerciseButton;

	[HideInInspector]public UIPanel selectedPanel;
	[HideInInspector]public GridLayoutGroup activeGridLayout;

	public Mode currentMode;

	[SerializeField] private EditExerciseView _editExerciseView;
	[SerializeField] private ViewExerciseView _viewExerciseView;

	void OnEnable()
	{
		addWorkoutButton.onShortClick.AddListener(HandleAddWorkoutPressed);
		addExerciseButton.onShortClick.AddListener(HandleAddExercisePressed);
	}

	void OnDisable()
	{
		addWorkoutButton.onShortClick.RemoveListener(HandleAddWorkoutPressed);
		addExerciseButton.onShortClick.RemoveListener(HandleAddExercisePressed);
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

		if(PlayerPrefs.GetInt("hasOpenedApp") != 1)
		{
			PlayerPrefs.SetInt ("hasOpenedApp", 1);
			WorkoutManager.Instance.Save();
		}
	}

	public void ShowWorkoutsMenu()
	{
		Header.Instance.UpdateTopLabel ("");

		addWorkoutButton.transform.localScale = Vector3.one;
		addExerciseButton.transform.localScale = Vector3.zero;

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.one;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		//playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		_editExerciseView.Hide ();
		_viewExerciseView.Hide ();

		foreach(ExerciseMenuItem panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>()){
			Destroy(panel.gameObject);
		}

		foreach(WorkoutPanel panel in workoutPanelsGridLayoutGroup.GetComponentsInChildren<WorkoutPanel>()){
			Destroy(panel.gameObject);
		}

		foreach(WorkoutData workout in WorkoutManager.Instance.workoutData){
			AddWorkoutPanel(workout);
		}

		Footer.Instance.Hide();

		currentMode = Mode.ViewingWorkouts;
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen)
	{
		foreach(ExerciseMenuItem panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>()){
			Destroy(panel.gameObject);
		}

		Header.Instance.SetUpForExercisesMenu(workoutToOpen);
		Header.Instance.UpdateTopLabel (PlayerPrefs.GetString("userTitle"));
		addWorkoutButton.transform.localScale = Vector3.zero;
		addExerciseButton.transform.localScale = Vector3.one;

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;
		//playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		_editExerciseView.Hide ();
		_viewExerciseView.Hide ();

		foreach(ExerciseData exercise in workoutToOpen.exerciseData){
			AddExercisePanel(null, exercise, false);
		}

		Footer.Instance.ShowWorkoutControls();
		Footer.Instance.WorkoutControlsContatiner.ShowPausedMenu();
		Footer.Instance.UpdateTitle ("");

		currentMode = Mode.ViewingExercises;
	}

	public void ShowEditStatsViewForExercise(ExerciseData exerciseToOpen){
	
		Header.Instance.UpdateTopLabel (WorkoutManager.Instance.ActiveWorkout.name);

		addExerciseButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		//playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		_editExerciseView.Init (exerciseToOpen);
		_viewExerciseView.Init (exerciseToOpen,
			WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf(exerciseToOpen),
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		Footer.Instance.ShowWorkoutControls();
		Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu();

		currentMode = Mode.EditingExercise;
	}

	public void ShowEditStatsViewForExerciseAtIndex(int index)
	{
		Header.Instance.UpdateTopLabel (WorkoutManager.Instance.ActiveWorkout.name);

		if (index < 0 || index >= WorkoutManager.Instance.ActiveWorkout.exerciseData.Count)
		{
			return;
		} 

		ExerciseData nextExercise = WorkoutManager.Instance.ActiveWorkout.exerciseData [index];

		_editExerciseView.Init (nextExercise);
		_viewExerciseView.Init (nextExercise,
			WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf(nextExercise),
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		WorkoutManager.Instance.ActiveExercise = nextExercise;
	}

	public void PlayActiveWorkout(int exerciseIndex)
	{
		Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout);

		addExerciseButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		_editExerciseView.Hide ();

		if (currentMode == Mode.ViewingExercises) {
			exerciseIndex = 0;
		}

		ExerciseData exerciseToPlay = WorkoutManager.Instance.ActiveWorkout.exerciseData [exerciseIndex];
		_viewExerciseView.Init (exerciseToPlay,
			exerciseIndex,
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		PlayModeManager.Instance.PlayWorkout(WorkoutManager.Instance.ActiveWorkout, exerciseIndex);

		currentMode = Mode.PlayingExercise;
	}

	public void AddWorkoutPanel(WorkoutData workoutData){
		WorkoutPanel newWorkoutPanel = Instantiate(WorkoutMenuItemPrefab);

		if (workoutData != null) {
			newWorkoutPanel.workoutData = workoutData;
		} else {
			newWorkoutPanel.SelectTitle ();
		}

		newWorkoutPanel.UpdateText();
		newWorkoutPanel.UpdateColor();

		newWorkoutPanel.transform.SetParent(workoutPanelsGridLayoutGroup.transform);
		newWorkoutPanel.transform.localScale = Vector3.one;
	}

	public void AddExercisePanel(WorkoutData workoutData, ExerciseData exerciseData, bool isFromButton)
	{
		ExerciseMenuItem newExerciseMenuItem = Instantiate(_exerciseMenuItemPrefab);

		if(workoutData != null)
		{
			exerciseData = new ExerciseData();
			workoutData.exerciseData.Add(exerciseData);
		}

		if (isFromButton) {
			exerciseData.totalSets = 3;
			exerciseData.totalInitialSets = 3;
			exerciseData.repsPerSet = 10;
			exerciseData.secondsToCompleteSet = 60;
		}

		if (exerciseData != null) {
			newExerciseMenuItem.Init (exerciseData);
		}

		if (isFromButton) {
			newExerciseMenuItem.SelectTitle ();
			Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout);
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

	void HandleAddWorkoutPressed()
    {
        AddPanel.Instance.ShowForAddWorkouts();
		SoundManager.Instance.PlayButtonPressSound();
    }

    void HandleAddExercisePressed()
    {
        AddPanel.Instance.ShowForAddExercises();
		SoundManager.Instance.PlayButtonPressSound();
    }
}
