using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Header : MonoBehaviour {

	public static Header Instance;

	[SerializeField]private Button SettingsButton;
	[SerializeField]private Button HomeButton;
	[SerializeField]private TextMeshProUGUI title;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void OnEnable(){
		HomeButton.onClick.AddListener(HandleHomePressed);
	}

	void OnDisable(){
		HomeButton.onClick.RemoveListener(HandleHomePressed);
	}

	public void HandleHomePressed(){
		SettingsButton.gameObject.SetActive(true);
		HomeButton.gameObject.SetActive(false);

		WorkoutManager.Instance.workoutHUD.ShowWorkoutsMenu();

		PlayModeManager.Instance.Reset();

		Footer.Instance.Hide();

		title.text = "Workouts";
	}

	public void SetUpForExercisesMenu(WorkoutData workout){
		SettingsButton.gameObject.SetActive(false);
		HomeButton.gameObject.SetActive(true);
		title.text = workout.name;
	}
}
