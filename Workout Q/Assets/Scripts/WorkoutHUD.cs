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

	public ShadowButton addWorkoutButton;
	public ShadowButton addExerciseButton;

	[HideInInspector]public UIPanel selectedPanel;
	[HideInInspector]public GridLayoutGroup activeGridLayout;

	public Mode currentMode;

	[SerializeField] private EditExerciseView _editExerciseView;
	[SerializeField] private ViewExerciseView _viewExerciseView;

	public ScrollRect exercisesScrollRect;
	public ScrollRect workoutsScrollRect;

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
			AddWorkoutPanel(workout, false);
		}

		currentMode = Mode.ViewingWorkouts;

		if(PlayerPrefs.GetInt("hasOpenedApp") != 1)
		{
			PlayerPrefs.SetInt ("hasOpenedApp", 1);
			WorkoutManager.Instance.Save();
			WorkoutManager.Instance.ShowWelcomeMenu ();
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
			AddWorkoutPanel(workout, false);
		}

		Footer.Instance.Hide();

		currentMode = Mode.ViewingWorkouts;
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen)
	{
		print ("workoutToOpen.exerciseData.Count:" + workoutToOpen.exerciseData.Count);

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

		print ("workoutToOpen.exerciseData.Count:" + workoutToOpen.exerciseData.Count);

		foreach(ExerciseData exercise in workoutToOpen.exerciseData){
			AddExercisePanel(null, exercise, false);
		}

		print ("workoutToOpen.exerciseData.Count:" + workoutToOpen.exerciseData.Count);

		currentMode = Mode.ViewingExercises;

		Footer.Instance.ShowWorkoutControls();
		Footer.Instance.WorkoutControlsContatiner.ShowPausedMenu();
		Footer.Instance.UpdateTitle ("");

		ExerciseSlider.Instance.Hide ();
	}

	public void ShowEditStatsViewForExercise(ExerciseData exerciseToOpen){

		addExerciseButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		//playModeExercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		int exerciseIndex = WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (exerciseToOpen);
		int exerciseCount = WorkoutManager.Instance.ActiveWorkout.exerciseData.Count;

		Header.Instance.lineSegmenter.gameObject.SetActive (true);
		Header.Instance.UpdateTopLabel (WorkoutManager.Instance.ActiveWorkout.name);
		Header.Instance.UpdateMiddleLabel ("XRC " + (exerciseIndex + 1) + " of " + exerciseCount);

		print ("exerciseToOpen: " + exerciseToOpen);
		print ("exerciseIndex: " + exerciseIndex);
		print ("exerciseCount: " + exerciseCount);

		_editExerciseView.Init (exerciseToOpen, false, false);
		_viewExerciseView.Init (exerciseToOpen, exerciseIndex, exerciseCount);

//		Footer.Instance.ShowWorkoutControls();
//
//		if (exerciseToOpen.totalSets <= 0) {
//			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (true);
//		} else {
//			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (false);
//		}

		currentMode = Mode.EditingExercise;
	}

	public void ShowEditStatsViewForExerciseAtIndex(int index)
	{
		int exerciseCount = WorkoutManager.Instance.ActiveWorkout.exerciseData.Count;

		Header.Instance.UpdateTopLabel (WorkoutManager.Instance.ActiveWorkout.name);
		Header.Instance.UpdateMiddleLabel ("XRC " + (index + 1) + " of " + exerciseCount);

		if (index < 0 || index >= exerciseCount)
		{
			return;
		} 

		ExerciseData nextExercise = WorkoutManager.Instance.ActiveWorkout.exerciseData [index];

		_editExerciseView.Init (nextExercise, false, false);
		_viewExerciseView.Init (nextExercise,
			WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf(nextExercise),
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		WorkoutManager.Instance.ActiveExercise = nextExercise;

//		Footer.Instance.ShowWorkoutControls();
//
//		if (nextExercise.totalSets <= 0) {
//			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (true);
//		} else {
//			Footer.Instance.WorkoutControlsContatiner.ShowEditingExerciseMenu (false);
//		}
	}

	public void SetupExerciseToPlay(int exerciseIndex)
	{
		//Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout);
		int exerciseCount = WorkoutManager.Instance.ActiveWorkout.exerciseData.Count;

		Header.Instance.lineSegmenter.gameObject.SetActive (true);
		Header.Instance.UpdateTopLabel (WorkoutManager.Instance.ActiveWorkout.name);
		Header.Instance.UpdateMiddleLabel ("XRC " + (exerciseIndex + 1) + " of " + exerciseCount);

		addExerciseButton.transform.localScale = Vector3.zero;

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		_editExerciseView.Hide ();

		if (currentMode == Mode.ViewingExercises && !WorkoutManager.Instance.ActiveWorkout.inProgress) {
			exerciseIndex = 0;
		}

		ExerciseData exerciseToPlay = WorkoutManager.Instance.ActiveWorkout.exerciseData [exerciseIndex];
		_viewExerciseView.Init (exerciseToPlay,
			exerciseIndex,
			WorkoutManager.Instance.ActiveWorkout.exerciseData.Count);

		PlayModeManager.Instance.SetUpExercise(WorkoutManager.Instance.ActiveWorkout, exerciseIndex);

		currentMode = Mode.PlayingExercise;

		WorkoutManager.Instance.ActiveExercise = exerciseToPlay;

		ExerciseSlider.Instance.Init (exerciseCount, exerciseIndex);
	}

	public void AddWorkoutPanel(WorkoutData workoutData, bool isFromButton){
		WorkoutPanel newWorkoutPanel = Instantiate(WorkoutMenuItemPrefab);

		if (workoutData != null) {
			newWorkoutPanel.workoutData = workoutData;
		} 

		if (isFromButton) 
		{
			workoutData = new WorkoutData ();
			workoutData.exerciseData = new List<ExerciseData> ();
			workoutData.minutes = 0;
			workoutData.workoutType = WorkoutType._singleDumbell;
		}

		newWorkoutPanel.Init (workoutData);
		newWorkoutPanel.transform.SetParent(workoutPanelsGridLayoutGroup.transform);
		newWorkoutPanel.transform.localScale = Vector3.one;

		if (isFromButton) 
		{
			newWorkoutPanel.SelectTitle ();
		}
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

//		AddPlanPanel.Instance.Show ();
//		AddPlanPanel.Instance.ShowWorkoutsForPlan (WorkoutGenerator.Instance.homeIntermediatePlan.planData);
    }

    void HandleAddExercisePressed()
    {
        AddPanel.Instance.ShowForAddExercises();
		SoundManager.Instance.PlayButtonPressSound();
    }
}
