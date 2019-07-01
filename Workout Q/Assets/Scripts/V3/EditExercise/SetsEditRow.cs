using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetsEditRow : StatEditRow 
{
	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.totalInitialSets;
		numberInput.text = value.ToString();
		labelString = "Sets:";
	}

	void OnEnable () 
	{
		lessButton.onShortClick.AddListener (Decrement);
		moreButton.onShortClick.AddListener (Increment);
		numberInput.onValueChanged.AddListener(delegate{HandleInputFieldSubmitted();});
		numberInput.onSubmit.AddListener(delegate{HandleInputFieldSubmitted();});
	}

	void OnDisable () 
	{
		lessButton.onShortClick.RemoveListener (Decrement);
		moreButton.onShortClick.RemoveListener (Increment);
		numberInput.onValueChanged.RemoveListener(delegate{HandleInputFieldSubmitted();});
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

		if (controller.currentExerciseMenuItem != null)
		{
			controller.currentExerciseMenuItem.UpdateStatsText();
		}

		WorkoutManager.Instance.Save();
	}
}
