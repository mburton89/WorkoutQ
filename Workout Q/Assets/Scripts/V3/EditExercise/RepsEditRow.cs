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
		if (value > 0) 
		{
			value--;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
	}

	void Increment()
	{
		if (value < 99) 
		{
			value++;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
	}

	void UpdateData()
	{
		controller.currentExerciseData.repsPerSet = value;
		UpdateStatView ();
	}

	void UpdateStatView()
	{
		ViewExerciseView.Instance.UpdateRepsAndWeightView (value, controller.currentExerciseData.weight);
	}
}
