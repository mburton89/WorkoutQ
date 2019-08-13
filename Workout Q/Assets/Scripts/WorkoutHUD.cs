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

	[HideInInspector]public UIPanel selectedPanel;
	[HideInInspector]public GridLayoutGroup activeGridLayout;

	public Mode currentMode;

	public ScrollRect exercisesScrollRect;
	public ScrollRect workoutsScrollRect;

	void Awake()
	{
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

		if (Camera.main.aspect < (0.512f)) 
		{
			exercisesScrollRect.GetComponent<RectTransform> ().offsetMin = new Vector2(exercisesScrollRect.GetComponent<RectTransform> ().offsetMin.x, 195f);
			workoutsScrollRect.GetComponent<RectTransform> ().offsetMin = new Vector2(exercisesScrollRect.GetComponent<RectTransform> ().offsetMin.x, 195f);
		}
	}

	public void ShowWorkoutsMenu()
	{
		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.one;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		foreach(ExerciseMenuItem panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>()){
			Destroy(panel.gameObject);
		}

		foreach(WorkoutPanel panel in workoutPanelsGridLayoutGroup.GetComponentsInChildren<WorkoutPanel>()){
			Destroy(panel.gameObject);
		}

		foreach(WorkoutData workout in WorkoutManager.Instance.workoutData){
			AddWorkoutPanel(workout, false);
		}

		FooterV2.Instance.ShowViewingPlanButtonGroup ();

		currentMode = Mode.ViewingWorkouts;
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen)
	{
		foreach(ExerciseMenuItem panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>())
		{
			Destroy(panel.gameObject);
		}

		Header.Instance.SetUpForExercisesMenu(workoutToOpen);

		workoutPanelsGridLayoutGroup.transform.localScale = Vector3.zero;
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.one;

		foreach(ExerciseData exercise in workoutToOpen.exerciseData)
		{
			AddExercisePanel(null, exercise, false);
		}
			
		currentMode = Mode.ViewingExercises;

		FooterV2.Instance.ShowViewingWorkoutButtonGroup ();
	}

	public void ShowEditStatsViewForExercise(ExerciseData exerciseToOpen)
	{
		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		int exerciseIndex = WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (exerciseToOpen);
		int exerciseCount = WorkoutManager.Instance.ActiveWorkout.exerciseData.Count;

		Header.Instance.UpdateMiddleLabel ("XRC " + (exerciseIndex + 1) + " of " + exerciseCount);

		currentMode = Mode.EditingExercise;
	}

	public void ShowEditStatsViewForExerciseAtIndex(int index)
	{
		int exerciseCount = WorkoutManager.Instance.ActiveWorkout.exerciseData.Count;

		Header.Instance.UpdateMiddleLabel ("XRC " + (index + 1) + " of " + exerciseCount);

		if (index < 0 || index >= exerciseCount)
		{
			return;
		} 

		ExerciseData nextExercise = WorkoutManager.Instance.ActiveWorkout.exerciseData [index];
		WorkoutManager.Instance.ActiveExercise = nextExercise;
	}

	public void SetupExerciseToPlay(int exerciseIndex)
	{
		int exerciseCount = WorkoutManager.Instance.ActiveWorkout.exerciseData.Count;

		Header.Instance.UpdateMiddleLabel ("XRC " + (exerciseIndex + 1) + " of " + exerciseCount);

		exercisePanelsGridLayoutGroup.transform.localScale = Vector3.zero;

		ExerciseData exerciseToPlay = WorkoutManager.Instance.ActiveWorkout.exerciseData [exerciseIndex];
		currentMode = Mode.PlayingExercise;
		WorkoutManager.Instance.ActiveExercise = exerciseToPlay;
		WorkoutPlayerController.Instance.Init (WorkoutManager.Instance.ActiveWorkout, exerciseIndex);
		FooterV2.Instance.ShowViewingExerciseButtonGroup ();
	}

	public WorkoutPanel AddWorkoutPanel(WorkoutData workoutData, bool isFromButton){
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

		return newWorkoutPanel;
	}

	public ExerciseMenuItem AddExercisePanel(WorkoutData workoutData, ExerciseData exerciseData, bool isFromButton)
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

		return newExerciseMenuItem;
	}

	public void HandlePanelSelected(UIPanel panel){
		if(selectedPanel != null && selectedPanel != panel)
		{
			selectedPanel.Deselect();			
		}
			
		selectedPanel = panel;
		activeGridLayout = panel.GetComponentInParent<GridLayoutGroup>();

		FooterV2.Instance.ShowPanelMoverButtonGroup();
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
