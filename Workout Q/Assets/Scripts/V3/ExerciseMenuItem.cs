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
	[SerializeField] private Button editButton;
	[SerializeField] private TextMeshProUGUI _setsCompleteText;

	void Awake()
	{
		if(exerciseData != null){
			UpdateText();
		}
	}

	void OnEnable(){
		exerciseName.onSubmit.AddListener(delegate{HandleTitleChanged();});

		if (editButton != null) 
		{
			editButton.onClick.AddListener (HandleEditPressed);		
		}
	}

	void OnDisable(){
		exerciseName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});

		if (editButton != null) 
		{
			editButton.onClick.RemoveListener (HandleEditPressed);
		}
	}

	public void Init(ExerciseData exerciseData)
	{
		this.exerciseData = exerciseData;
		exerciseName.text = exerciseData.name;
		UpdateStatsText (exerciseData.totalSets, exerciseData.repsPerSet, exerciseData.weight, exerciseData.secondsToCompleteSet);
   		fitBoyAnimator.Init(exerciseData.exerciseType);
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
		AddPanel.Instance.Exit ();
		EditExercisePanel.Instance.Init (exerciseData, true, false);
    }

	public void SelectTitle(){
		exerciseName.Select();
	}

	void HandleEditPressed()
	{
		EditExercisePanel.Instance.Init (this, false, false);
	}

	public void UpdateStatsText(int sets, int reps, int weight, int seconds)
	{
		statsText.text = sets 
			+ "x" + reps 
			+ "   " + weight + PlayerPrefs.GetString ("weightType")
			+ "   " + seconds
			+ "s";
	}

	public void UpdateStatsText()
	{
		statsText.text = exerciseData.totalInitialSets 
			+ "x" + exerciseData.repsPerSet 
			+ "   " + exerciseData.weight + PlayerPrefs.GetString ("weightType")
			+ "   " + exerciseData.secondsToCompleteSet
			+ "s";
	}

	public void UpdateSetsCompleteDisplay(int completedSets, int totalSets)
	{
		if (completedSets == totalSets) {
			_setsCompleteText = "COMPLETE";
		}else{
			_setsCompleteText = completedSets + "/" + totalSets + "complete";
		}
	}
}
