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
	public Button titleButton;

	void OnEnable(){
		selfButton.onClick.AddListener(HandleSelfClicked);
		titleButton.onClick.AddListener(SelectTitle);
		_workoutName.onSubmit.AddListener(delegate{HandleTitleChanged();});
		//toggle.onValueChanged.AddListener(delegate{HandleTogglePressed();});
	}

	void OnDisable(){
		selfButton.onClick.RemoveListener(HandleSelfClicked);
		titleButton.onClick.RemoveListener(SelectTitle);
		_workoutName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
		//toggle.onValueChanged.RemoveListener(delegate{HandleTogglePressed();});
	}

	void Awake(){
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

	void HandleTitleChanged(){
		workoutData.name = _workoutName.text;
		WorkoutManager.Instance.Save();
	}

	public void SelectTitle(){
		_workoutName.Select();
	}
}
