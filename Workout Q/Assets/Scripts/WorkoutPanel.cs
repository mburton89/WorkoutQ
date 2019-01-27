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

	void OnEnable()
	{
		_workoutName.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable()
	{
		_workoutName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
	}

	void Awake()
	{
		if(workoutData != null){
			UpdateText();
		}
	}

	public void UpdateText(){

		workoutData.EstablishMinutes();

		_workoutName.text = workoutData.name;
		_minutesLabel.text = workoutData.minutes + " min";
	}

	public void HandleSelfClicked(){
		WorkoutManager.Instance.ActiveWorkout = workoutData;
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout(workoutData);
		Unhighlight ();

		SoundManager.Instance.PlayButtonPressSound ();
	}

	public void HandleSelfClickedOnAddMenu()
    {
        Unhighlight();
		WorkoutHUD.Instance.AddWorkoutPanel(workoutData);
        SoundManager.Instance.PlayButtonPressSound();
		WorkoutManager.Instance.Save();
    }

	void HandleTitleChanged(){
		workoutData.name = _workoutName.text;
		WorkoutManager.Instance.Save();
	}

	public void SelectTitle(){
		_workoutName.Select();
	}
}
