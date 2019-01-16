using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightEditRow : StatEditRow 
{
	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.weight;
		labelString = "LBS:";
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
		controller.currentExerciseData.weight = value;
		UpdateStatView ();
	}

	void UpdateStatView()
	{
		//ViewExerciseView.Instance.UpdateRepsAndWeightView (controller.currentExerciseData.repsPerSet, value);
	}
}
