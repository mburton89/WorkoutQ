using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Header : MonoBehaviour {

	public static Header Instance;

	[SerializeField]private Button SettingsButton;
	[SerializeField]private Button HomeButton;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void OnEnable(){
		HomeButton.onClick.AddListener(SetUpForWorkoutsMenu);
	}

	void OnDisable(){
		HomeButton.onClick.RemoveListener(SetUpForWorkoutsMenu);
	}

	public void SetUpForWorkoutsMenu(){
		SettingsButton.gameObject.SetActive(true);
		HomeButton.gameObject.SetActive(false);

		WorkoutManager.Instance.workoutHUD.ShowWorkoutsMenu();
	}

	public void SetUpForExercisesMenu(){
		SettingsButton.gameObject.SetActive(false);
		HomeButton.gameObject.SetActive(true);
	}
}
