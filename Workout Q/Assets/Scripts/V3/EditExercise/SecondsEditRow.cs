using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsEditRow : StatEditRow 
{
	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.secondsToCompleteSet;
		numberInput.text = value.ToString();
		labelString = "Sec: ";
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
		if (value > 6) 
		{
			value = value - 5;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
	}

	void Increment()
	{
		if (value < 995) 
		{
			value = value + 5;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
	}

	void UpdateData()
	{
		controller.currentExerciseData.secondsToCompleteSet = value;
		UpdateStatView ();
		WorkoutManager.Instance.Save();
	}

	void UpdateStatView()
	{
		Footer.Instance.UpdateTitle (labelString);
	}
}
