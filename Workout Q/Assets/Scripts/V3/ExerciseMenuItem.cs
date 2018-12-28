using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExerciseMenuItem : UIPanel {

	public ExerciseData exerciseData;
	public TMP_InputField exerciseName;
	public TextMeshProUGUI secondsText;
	public TextMeshProUGUI setsRepsText;
	public TextMeshProUGUI weightText;

	void OnEnable()
	{
		exerciseName.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable()
	{
		exerciseName.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
	}

	void Awake()
	{
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
		secondsText.text = seconds + "s";
		setsRepsText.text = sets + "x" + reps;
		weightText.text = weight + "lb";
	}

	void SelectTitle(){
		exerciseName.Select();
	}
}
