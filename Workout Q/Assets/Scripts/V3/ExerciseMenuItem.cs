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
	//[SerializeField] private Image _progressMeter;
	[SerializeField] private Image _progressCircle;
	[SerializeField] private Image _progressCircleBG;
	[SerializeField] private GameObject _checkMark;
	[SerializeField] private GameObject _activeIndicator;

	void Awake()
	{
		if(exerciseData != null){
			UpdateText();
		}
	}

	void OnEnable()
	{
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
		UpdateStatsText (exerciseData.totalInitialSets, exerciseData.repsPerSet, exerciseData.weight, exerciseData.secondsToCompleteSet);
   		fitBoyAnimator.Init(exerciseData.exerciseType);
		UpdateColor(); 

		UpdateSetsCompleteDisplay (exerciseData.totalSets, exerciseData.totalInitialSets);

		if (exerciseData.isInProgress) 
		{
			_activeIndicator.SetActive (true);
		}
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
		//WorkoutHUD.Instance.ShowEditStatsViewForExercise(exerciseData);
		WorkoutHUD.Instance.SetupExerciseToPlay((WorkoutManager.Instance.ActiveWorkout.exerciseData.IndexOf (exerciseData)));
		SoundManager.Instance.PlayButtonPressSound ();

		if (PanelMover.Instance != null)
		{
			PanelMover.Instance.Confirm ();
		}
	}

	public void HandleSelfClickedOnAddMenu()
    {
        Unhighlight();
		AddPanel.Instance.Exit ();
		EditExercisePanel.Instance.CopyAndInit (exerciseData, true, false);
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

	public void UpdateSetsCompleteDisplay(int remainingSets, int totalSets)
	{
//		if (remainingSets == 0) {
//			_setsCompleteText.text = "COMPLETE";
//		}else if (remainingSets == totalSets) {
//			_setsCompleteText.text = "";
//		}else{
//			int setsComplete = totalSets - remainingSets;
//			_setsCompleteText.text = setsComplete + "/" + totalSets + "complete";
//		}

		float setsComplete = totalSets - remainingSets;
		float percentComplete = setsComplete / totalSets;

		//_progressMeter.fillAmount = percentComplete;
		if (_progressCircle != null) {
			_progressCircle.fillAmount = percentComplete;
			_progressCircle.color = ColorManager.Instance.ActiveColorLight;
			_progressCircleBG.color = ColorManager.Instance.ActiveColorDark;
			if (percentComplete >= 1) {
				_checkMark.SetActive (true);
			}
		}
	}
}
