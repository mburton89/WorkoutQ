using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExerciseMenuItem : UIPanel {

	public ExerciseData exerciseData;
	public TextMeshProUGUI statsText;
	public TMP_InputField exerciseName;
	public FitBoyAnimator fitBoyAnimator;

	void Awake()
	{
		if(exerciseData != null){
			UpdateText();
		}
	}

	void OnEnable(){
		exerciseName.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable(){
		exerciseName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
	}

	public void Init(ExerciseData exerciseData)
	{
		this.exerciseData = exerciseData;
		exerciseName.text = exerciseData.name;
		statsText.text = exerciseData.totalSets 
			+ "x" + exerciseData.repsPerSet 
			+ "   " + exerciseData.weight + PlayerPrefs.GetString ("weightType")
			+ "   " + exerciseData.secondsToCompleteSet 
			+ "s";

   		fitBoyAnimator.Init(WorkoutGenerator.Instance.GetSpritesForExercise(exerciseData.exerciseType));
		UpdateColor(); 
	}

	public void UpdateText(){
		exerciseName.text = exerciseData.name;
	}

	void HandleTitleChanged(){
		exerciseData.name = exerciseName.text;
		WorkoutManager.Instance.Save();
	}
		
	public void HandleSelfClicked(){
		Unhighlight ();
		WorkoutManager.Instance.ActiveExercise = exerciseData;
		WorkoutHUD.Instance.ShowEditStatsViewForExercise(exerciseData);
		SoundManager.Instance.PlayButtonPressSound ();
	}

	public void HandleSelfClickedOnAddMenu()
    {
        Unhighlight();

		ExerciseData copiedExercise = ExerciseData.Copy(
			exerciseData.name,
			exerciseData.secondsToCompleteSet,
			exerciseData.totalSets,
			exerciseData.repsPerSet,
			exerciseData.weight,
			exerciseData.exerciseType
		);

		WorkoutManager.Instance.ActiveWorkout.exerciseData.Add(copiedExercise);
		WorkoutHUD.Instance.AddExercisePanel(null, copiedExercise, false);
        SoundManager.Instance.PlayButtonPressSound();
		Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout);
		WorkoutManager.Instance.Save();

		AddPanel.Instance.Exit ();
    }

	public void SelectTitle(){
		exerciseName.Select();
	}
}
