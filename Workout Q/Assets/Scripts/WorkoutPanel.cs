using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutPanel : MonoBehaviour {

	[HideInInspector]public WorkoutData workoutData;
	[SerializeField]private TMP_InputField _workoutName;
	[SerializeField]private TextMeshProUGUI _minutesLabel;

	public Button selfButton;

	void OnEnable(){
		selfButton.onClick.AddListener(HandleSelfClicked);
		_workoutName.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable(){
		selfButton.onClick.RemoveListener(HandleSelfClicked);
		_workoutName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
	}

	void Awake(){
		if(workoutData != null){
			UpdateText();
		}
	}

	public void UpdateText(){
		_workoutName.text = workoutData.name;
		_minutesLabel.text = workoutData.minutes + " Minutes";
	}

	void HandleSelfClicked(){
		WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout(workoutData);
	}

	void HandleTitleChanged(){
		workoutData.name = _workoutName.text;
		WorkoutManager.Instance.Save();
	}
}
