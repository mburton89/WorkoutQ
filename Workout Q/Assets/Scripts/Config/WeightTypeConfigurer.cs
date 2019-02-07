using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightTypeConfigurer : MonoBehaviour {

	public Slider weightTypeSlider;

	void Start()
	{
		if (PlayerPrefs.GetString ("weightType") == "kg") 
		{
			weightTypeSlider.value = 1;	
		} 
	}

	void OnEnable()
	{
		weightTypeSlider.onValueChanged.AddListener (HandleWeightTypeChanged);
	}

	void OnDisable()
	{
		weightTypeSlider.onValueChanged.RemoveListener(HandleWeightTypeChanged);
	}

	void HandleWeightTypeChanged(float weightType)
	{
		if (weightType == 0) {
			PlayerPrefs.SetString ("weightType", "lb");
		} else {
			PlayerPrefs.SetString ("weightType", "kg");		
		}
	}
}
