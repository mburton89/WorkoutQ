using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Footer : MonoBehaviour
{
	public static Footer Instance;

	public PanelMover MovePanelContatiner;
	public WorkoutControls WorkoutControlsContatiner;
	//public Image timerLine;
	//public TextMeshProUGUI title;
	public TextMeshProUGUI seconds;

	public TimeSlider timeSlider;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	public void Hide()
	{
		MovePanelContatiner.gameObject.SetActive(false);
		WorkoutControlsContatiner.gameObject.SetActive(false);

//		if (WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts) 
//		{
//			WorkoutHUD.Instance.addWorkoutButton.gameObject.SetActive (true);
//		}
//		else if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
//		{
//			WorkoutHUD.Instance.addExerciseButton.gameObject.SetActive (true);
//		}
	}

	public void ShowPanelMover()
	{
		MovePanelContatiner.gameObject.SetActive(true);
		WorkoutControlsContatiner.gameObject.SetActive(false);

//		if (WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts) 
//		{
//			WorkoutHUD.Instance.addWorkoutButton.gameObject.SetActive (false);
//		}
//		else if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
//		{
//			WorkoutHUD.Instance.addExerciseButton.gameObject.SetActive (false);
//		}
	}

	public void ShowWorkoutControls()
	{
		MovePanelContatiner.gameObject.SetActive(false);
		WorkoutControlsContatiner.gameObject.SetActive(true);
	}

	public void ResetTimerLine(){
		timeSlider.slider.value = 0f;
		seconds.SetText ("");
	}

	public void UpdateTitle(string newTitle){
		//title.text = newTitle;
	}
}
