using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeightEditRow : StatEditRow 
{
	[SerializeField] TextMeshProUGUI _weightLabel;

	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.weight;
		labelString = "LBS:";
		numberInput.text = value.ToString();
		_weightLabel.text = PlayerPrefs.GetString ("weightType") + "s";
		UpdateStatView ();
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
		if (value > 0) 
		{
			if (PlayerPrefs.GetString ("weightType") == "lb")
			{
				value = value - 5;			
			}
			else 
			{
				value = value - 1;	
			}
		}

		numberInput.text = value.ToString();
		UpdateData ();
		SoundManager.Instance.PlayButtonPressSound ();
	}

	void Increment()
	{
		if (value < 995) 
		{
			if (PlayerPrefs.GetString ("weightType") == "lb")
			{
				value = value + 5;		
			}
			else 
			{
				value = value + 1;
			}
		}

		numberInput.text = value.ToString();
		UpdateData ();
		SoundManager.Instance.PlayButtonPressSound ();
	}

	void UpdateData()
	{
		controller.currentExerciseData.weight = value;

		if (controller.currentExerciseMenuItem != null)
		{
			controller.currentExerciseMenuItem.UpdateStatsText();
		}

		UpdateStatView ();
		WorkoutManager.Instance.Save();
	}

	void UpdateStatView()
	{
		//ViewExerciseView.Instance.UpdateWeightView (value);
	}
}
