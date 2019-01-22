using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetsEditRow : StatEditRow 
{
	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.totalSets;
		numberInput.text = value.ToString();
		labelString = "Sets:";
		UpdateStatView ();
	}

	void OnEnable () 
	{
		lessButton.onClick.AddListener (Decrement);
		moreButton.onClick.AddListener (Increment);
		numberInput.onSubmit.AddListener(delegate{HandleInputFieldSubmitted();});
	}

	void OnDisable () 
	{
		lessButton.onClick.RemoveListener (Decrement);
		moreButton.onClick.RemoveListener (Increment);
		numberInput.onSubmit.RemoveListener(delegate{HandleInputFieldSubmitted();});
	}

	public void HandleInputFieldSubmitted()
	{
		int newValue = int.Parse (numberInput.text);

		if(string.IsNullOrEmpty(numberInput.text) ||  newValue < 1)
		{
			value = 1;
			numberInput.text = value.ToString();
		}
		else
		{
			value = newValue;
		}

		UpdateData ();
	}

	void Decrement()
	{
		if (value > 1) 
		{
			value--;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
		SoundManager.Instance.PlayButtonPressSound ();
	}

	void Increment()
	{
		if (value < 99) 
		{
			value++;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
		SoundManager.Instance.PlayButtonPressSound ();
	}

	void UpdateData()
	{
		controller.currentExerciseData.totalSets = value;
		controller.currentExerciseData.totalInitialSets = value;
		UpdateStatView ();
		WorkoutManager.Instance.Save();
	}

	void UpdateStatView()
	{
		ViewExerciseView.Instance.UpdateSetsView (labelString, value);
	}
}
