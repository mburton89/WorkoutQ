using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeSlider : MonoBehaviour {

	public Slider slider;
	public UISelectHandler selectHandler;

	void OnEnable()
	{
		slider.onValueChanged.AddListener (HandleHandleMoved);
	}

	void OnDisable()
	{
		slider.onValueChanged.RemoveListener (HandleHandleMoved);
	}

	void HandleHandleMoved(float value)
	{
		if (!selectHandler.pointerIsDown)return;

		PlayModeManager.Instance.secondsRemaining = (1 - value) * PlayModeManager.Instance.ActiveExercise.secondsToCompleteSet;
	}
}
