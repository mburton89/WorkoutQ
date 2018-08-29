using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExercisePanel : MonoBehaviour {

	public ExerciseData exerciseData;

	public TMP_InputField exerciseName;

	public NumberCircle timeNumberCircle;
	public NumberCircle setsNumberCircle;
	public NumberCircle repsNumberCircle;
	public NumberCircle weightNumberCircle;

	void OnEnable(){
		exerciseName.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable(){
		exerciseName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
	}

	void Awake(){
		if(exerciseData != null){
			UpdateText();
		}
	}

	public void UpdateText(){
		exerciseName.text = exerciseData.name;
	}

	void HandleTitleChanged(){
		exerciseData.name = exerciseName.text;
		WorkoutManager.Instance.Save();
	}
}
