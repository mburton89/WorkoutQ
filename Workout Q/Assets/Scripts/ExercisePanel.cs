﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExercisePanel : UIPanel {

	public ExerciseData exerciseData;

	public TMP_InputField exerciseName;

	public NumberCircle timeNumberCircle;
	public NumberCircle setsNumberCircle;
	public NumberCircle repsNumberCircle;
	public NumberCircle weightNumberCircle;

	void OnEnable(){
		exerciseName.onSubmit.AddListener(delegate{HandleTitleChanged();});
		toggle.onValueChanged.AddListener(delegate{HandleTogglePressed();});
	}

	void OnDisable(){
		exerciseName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
		toggle.onValueChanged.RemoveListener(delegate{HandleTogglePressed();});
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

	public void PopulateFields(string title, int seconds, int sets, int reps, int weight){
		exerciseName.text = title;
		timeNumberCircle.UpdateValue(seconds);
		setsNumberCircle.UpdateValue(sets);
		repsNumberCircle.UpdateValue(reps);
		weightNumberCircle.UpdateValue(weight);
	}
}
