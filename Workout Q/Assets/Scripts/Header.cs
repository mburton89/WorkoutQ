using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Header : MonoBehaviour {

	public static Header Instance;

	[SerializeField]private Button SettingsButton;
	[SerializeField]private Button BackButton;
	[SerializeField]private TextMeshProUGUI title;

	public LineSegmenter lineSegmenter;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void OnEnable(){
		BackButton.onClick.AddListener(HandleBackPressed);
	}

	void OnDisable(){
		BackButton.onClick.RemoveListener(HandleBackPressed);
	}

	public void HandleBackPressed()
	{
		if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
		{
			SettingsButton.gameObject.SetActive(true);
			BackButton.gameObject.SetActive(false);
			WorkoutManager.Instance.workoutHUD.ShowWorkoutsMenu();
			Footer.Instance.Hide();
			title.text = "Workouts";
		}
		else if (WorkoutHUD.Instance.currentMode == Mode.EditingExercise || WorkoutHUD.Instance.currentMode == Mode.PlayingExercise) 
		{
			WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout (WorkoutManager.Instance.ActiveWorkout);
			title.text = WorkoutManager.Instance.ActiveWorkout.name;
			PlayModeManager.Instance.Reset();
			Footer.Instance.ResetTimerLine ();
		}

		WorkoutManager.Instance.Save ();
	}

	public void SetUpForExercisesMenu(string workoutName){
		SettingsButton.gameObject.SetActive(false);
		BackButton.gameObject.SetActive(true);
		title.text = workoutName;
	}

	public void UpdateTitle(string newTitle){
		title.text = newTitle;
	}

	public void UpdateExerciseView(int currentExerciseIndex, int totalExercises)
	{
		lineSegmenter.Init (totalExercises);
		lineSegmenter.ShowSegmentLit (currentExerciseIndex);
	}
}
