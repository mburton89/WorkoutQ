using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExerciseStatsController : MonoBehaviour
{
	private WorkoutPlayerController _controller;

	[SerializeField] private TextMeshProUGUI _repValue;
	[SerializeField] private TextMeshProUGUI _timeValue;
	[SerializeField] private TextMeshProUGUI _weightValue;
	[SerializeField] private TextMeshProUGUI _weightLabel;

	public void Init(WorkoutPlayerController controller)
	{
		_controller = controller;
		UpdateWeightLabel ();
	}

	public void UpdateRepValue(int repValue)
	{
		_repValue.text = "x" + repValue;
	}

	public void UpdateTimeValue(int timeValue)
	{
		_timeValue.text = timeValue + "s";
	}

	public void UpdateWeightValue(int weightValue)
	{
		_weightValue.text = weightValue.ToString();
	}

	void UpdateWeightLabel()
	{
		_weightLabel.text = PlayerPrefs.GetString ("weightType") + "s";
	}
}
