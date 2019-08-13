using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutPanel : UIPanel {

	public WorkoutData workoutData;
	[SerializeField]private TMP_InputField _workoutName;
	[SerializeField]private TextMeshProUGUI _minutesLabel;
	public Button selfButton;
	public FitBoyIlluminator fitBoyIlluminator;
	[SerializeField] private Button editButton;

	void OnEnable()
	{
		_workoutName.onSubmit.AddListener(delegate{HandleTitleChanged();});

		if (editButton != null) 
        {
			editButton.onClick.AddListener (HandleEditPressed);		
		}
	}

	void OnDisable()
	{
		_workoutName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});

		if (editButton != null) {
			editButton.onClick.RemoveListener (HandleEditPressed);
		}
	}

	public void Init(WorkoutData workoutData)
	{
		this.workoutData = workoutData;
		UpdateColor ();
		fitBoyIlluminator.Init(workoutData.workoutType);
		UpdateText ();
	}

	void Awake()
	{
		if(workoutData != null){
			UpdateText();
		}
	}

	public void UpdateText()
	{
		workoutData.EstablishMinutes();
		_workoutName.text = workoutData.name;

		if (workoutData.minutes < 1) {
			_minutesLabel.text = "0 min";
		} else {
			_minutesLabel.text = workoutData.minutes + " min";
		}
	}

	public void HandleSelfClicked(){

		foreach (ExerciseData exercise in workoutData.exerciseData)
		{
			exercise.isInProgress = false;
		}

		WorkoutManager.Instance.ActiveWorkout = workoutData;
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout(workoutData);
		Unhighlight ();

		SoundManager.Instance.PlayButtonPressSound ();

		if (PanelMover.Instance != null)
		{
			PanelMover.Instance.Confirm ();
		}
	}

	public void AddWorkoutFromPlanPanel()
    {
		WorkoutData copiedWorkout = new WorkoutData ();
		copiedWorkout.name = workoutData.name;
		copiedWorkout.workoutType = workoutData.workoutType;
		copiedWorkout.secondsBetweenExercises = workoutData.secondsBetweenExercises;
		copiedWorkout.exerciseData = new List<ExerciseData> ();

		foreach(ExerciseData exercise in workoutData.exerciseData){

			ExerciseData copiedExercise = ExerciseData.Copy(
				exercise.name,
				exercise.secondsToCompleteSet,
				exercise.totalInitialSets,
				exercise.totalSets,
				exercise.repsPerSet,
				exercise.weight,
				exercise.exerciseType
			);

			copiedWorkout.exerciseData.Add(copiedExercise);
		}

		WorkoutHUD.Instance.AddWorkoutPanel(copiedWorkout, false);
		WorkoutManager.Instance.Save();
    }

	public void HandleSelfClickedOnAddMenu()
	{
		Unhighlight();
		AddPanel.Instance.ShowExercisesForWorkout (workoutData);
	}

	public void HandleSelfClickedOnAddPlanMenu()
	{
		AddPlanPanel.Instance.ShowExercisesForWorkout (this.workoutData);
	}

	void HandleTitleChanged(){
		workoutData.name = _workoutName.text;
		WorkoutManager.Instance.Save();
	}

	public void SelectTitle()
	{
		_workoutName.Select();
	}

	void HandleEditPressed()
	{
		EditWorkoutPanel.Instance.Init (this, false, false);
	}
}
