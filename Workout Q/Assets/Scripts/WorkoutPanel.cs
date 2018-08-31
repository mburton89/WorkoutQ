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

	void OnEnable(){
		selfButton.onClick.AddListener(HandleSelfClicked);
		_workoutName.onSubmit.AddListener(delegate{HandleTitleChanged();});
		toggle.onValueChanged.AddListener(delegate{DetermineSelectability();});
	}

	void OnDisable(){
		selfButton.onClick.RemoveListener(HandleSelfClicked);
		_workoutName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
		toggle.onValueChanged.RemoveListener(delegate{DetermineSelectability();});
	}

	void Awake(){
		if(workoutData != null){
			UpdateText();
		}
	}

	public void UpdateText(){

		workoutData.EstablishMinutes();

		_workoutName.text = workoutData.name;
		_minutesLabel.text = workoutData.minutes + " Minutes";
	}

	void HandleSelfClicked(){
		WorkoutManager.Instance.ActiveWorkout = workoutData;
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout(workoutData);
	}

	void HandleTitleChanged(){
		workoutData.name = _workoutName.text;
		WorkoutManager.Instance.Save();
	}
}
