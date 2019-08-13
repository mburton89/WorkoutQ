using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightTypeConfigurer : MonoBehaviour {

	public Slider weightTypeSlider;
	[SerializeField] private Button _lbButton;
	[SerializeField] private Button _kgButton;

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
		_lbButton.onClick.AddListener (HandleLBClicked);
		_kgButton.onClick.AddListener(HandleKGClicked);
	}

	void OnDisable()
	{
		weightTypeSlider.onValueChanged.RemoveListener(HandleWeightTypeChanged);
		_lbButton.onClick.RemoveListener (HandleLBClicked);
		_kgButton.onClick.RemoveListener(HandleKGClicked);
	}

	void HandleWeightTypeChanged(float weightType)
	{
		if (weightType == 0) {
			PlayerPrefs.SetString ("weightType", "lb");
		} else {
			PlayerPrefs.SetString ("weightType", "kg");		
		}
	}


	void HandleLBClicked()
	{
		weightTypeSlider.value = 0;
		PlayerPrefs.SetString ("weightType", "lb");
	}


	void HandleKGClicked()
	{
		weightTypeSlider.value = 1;	
		PlayerPrefs.SetString ("weightType", "kg");	
	}
}
