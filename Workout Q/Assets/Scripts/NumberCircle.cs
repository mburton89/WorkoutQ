using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberCircle : MonoBehaviour {

	[SerializeField]private ExercisePanel exercisePanel;

	public enum Type{
		Seconds,
		Sets,
		Reps,
		Weight
	}

	public Type type;

	//public Image circleOutline;
	public TextMeshProUGUI label;
	public TMP_InputField inputField;
	public Button inputFieldSelectButton;

	[HideInInspector]public int value;

	void OnEnable() {
		inputFieldSelectButton.onClick.AddListener(SelectInputField);
		inputField.onSubmit.AddListener(delegate{HandleValueChanged();});
	}

	void OnDisable() {
		inputFieldSelectButton.onClick.RemoveListener(SelectInputField);
		inputField.onSubmit.RemoveListener(delegate{HandleValueChanged();});
	}
	
	 void HandleValueChanged(){
		if(string.IsNullOrEmpty(inputField.text)){
			label.color = Color.grey;
			//circleOutline.color = Color.grey;
		}else{
			label.color = Color.white;
			//circleOutline.color = Color.white;
		}
			
		if(string.IsNullOrEmpty(inputField.text)){
			value = 0;
		}else{
			value = int.Parse(inputField.text);
		}

		if(type == Type.Seconds)
		{
			exercisePanel.exerciseData.secondsToCompleteSet = value;
		}
		else if(type == Type.Sets)
		{
			//CreatePiesAndNotches();
			exercisePanel.exerciseData.totalSets = value;
		}
		else if(type == Type.Reps)
		{
			exercisePanel.exerciseData.repsPerSet = value;
		}
		else if(type == Type.Weight)
		{
			exercisePanel.exerciseData.weight = value;
		}

		WorkoutManager.Instance.Save();
	}

	void CreatePiesAndNotches()
	{
		for(int i = 0; i < value; i++){
			print("_value: " + value);
		}
	}

	public void UpdateValue(int value)
	{
		inputField.text = value.ToString();
	}

	void SelectInputField(){
		inputField.Select();
	}
}
