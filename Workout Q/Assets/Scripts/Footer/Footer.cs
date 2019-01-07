using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Footer : MonoBehaviour
{
	public static Footer Instance;

	public PanelMover MovePanelContatiner;
	public WorkoutControls WorkoutControlsContatiner;

	public Image timerLine;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	public void Hide()
	{
		MovePanelContatiner.gameObject.SetActive(false);
		WorkoutControlsContatiner.gameObject.SetActive(false);
	}

	public void ShowPanelMover()
	{
		MovePanelContatiner.gameObject.SetActive(true);
		WorkoutControlsContatiner.gameObject.SetActive(false);
	}

	public void ShowWorkoutControls()
	{
		MovePanelContatiner.gameObject.SetActive(false);
		WorkoutControlsContatiner.gameObject.SetActive(true);
	}

	public void ResetTimerLine(){
		timerLine.fillAmount = 1f;
	}
}
