using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutPanel : MonoBehaviour {

	[HideInInspector]public Workout workout;
	[SerializeField]private TMP_InputField _workoutName;
	[SerializeField]private TextMeshProUGUI _minutesLabel;

	public Button selfButton;

	void OnEnable(){
		selfButton.onClick.AddListener(HandleSelfClicked);
	}

	void OnDisable(){
		selfButton.onClick.RemoveListener(HandleSelfClicked);
	}

	public void UpdateText(){
		_workoutName.text = workout.name;
		_minutesLabel.text = workout.minutes + " Minutes";
	}

	void HandleSelfClicked(){
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout(workout);
	}
}
