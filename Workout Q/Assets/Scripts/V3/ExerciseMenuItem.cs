using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExerciseMenuItem : UIPanel {

	public ExerciseData exerciseData;
	//public TextMeshProUGUI exerciseName;
	public TextMeshProUGUI statsText;
	[HideInInspector] public string weightLabel = "lb";	

	public TMP_InputField exerciseName;

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

	public void Init(ExerciseData exerciseData){
		this.exerciseData = exerciseData;
		exerciseName.text = exerciseData.name;
		statsText.text = exerciseData.totalSets 
			+ "x" + exerciseData.repsPerSet 
			+ "   " + exerciseData.weight + weightLabel 
			+ "   " + exerciseData.secondsToCompleteSet 
			+ "s";
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
		WorkoutManager.Instance.ActiveWorkout.exerciseData.Add(exerciseData);
		WorkoutHUD.Instance.AddExercisePanel(null, exerciseData, false);
        SoundManager.Instance.PlayButtonPressSound();
		Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout);
		WorkoutManager.Instance.Save();
    }

	public void SelectTitle(){
		exerciseName.Select();
	}
}
