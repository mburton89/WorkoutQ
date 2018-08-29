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

	public Image circleOutline;
	public TextMeshProUGUI label;
	public TMP_InputField inputField;

	private int _value;

	void Start () {
		inputField.onSubmit.AddListener(delegate{HandleValueChanged();});
	}
	
	 void HandleValueChanged(){
		if(string.IsNullOrEmpty(inputField.text)){
			label.color = Color.grey;
			circleOutline.color = Color.grey;
		}else{
			label.color = Color.white;
			circleOutline.color = Color.white;
		}
			
		_value = int.Parse(inputField.text);

		if(type == Type.Seconds)
		{
			exercisePanel.exerciseData.secondsToCompleteSet = _value;
		}
		else if(type == Type.Sets)
		{
			CreatePiesAndNotches();
			exercisePanel.exerciseData.totalSets = _value;
		}
		else if(type == Type.Reps)
		{
			exercisePanel.exerciseData.repsPerSet = _value;
		}
		else if(type == Type.Weight)
		{
			exercisePanel.exerciseData.weight = _value;
		}

		WorkoutManager.Instance.Save();
	}

	void CreatePiesAndNotches()
	{
		for(int i = 0; i < _value; i++){
			print("_value: " + _value);
		}
	}

	public void UpdateValue(int value)
	{
		inputField.text = value.ToString();
		HandleValueChanged();
	}
}
