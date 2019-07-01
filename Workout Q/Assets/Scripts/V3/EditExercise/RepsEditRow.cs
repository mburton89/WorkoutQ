using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepsEditRow : StatEditRow 
{
	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.repsPerSet;
		labelString = "Reps:";
		numberInput.text = value.ToString();
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
		if(string.IsNullOrEmpty(numberInput.text))
		{
			value = 0;
		}
		else
		{
			value = int.Parse(numberInput.text);
		}

		UpdateData ();
	}

	void Decrement()
	{

		print ("YO");

		if (value > 0) 
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
		controller.currentExerciseData.repsPerSet = value;

		if (controller.currentExerciseMenuItem != null)
		{
			controller.currentExerciseMenuItem.UpdateStatsText();
		}

		WorkoutManager.Instance.Save();
	}
}
