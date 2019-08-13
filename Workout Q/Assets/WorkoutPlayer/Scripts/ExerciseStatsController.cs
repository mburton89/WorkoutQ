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
	[SerializeField] private TextMeshProUGUI _repLabel;
	[SerializeField] private TextMeshProUGUI _timeLabel;
	[SerializeField] private TextMeshProUGUI _weightLabel;

	public void Init(WorkoutPlayerController controller)
	{
		_controller = controller;
		_repValue.color = ColorManager.Instance.ActiveColorLight;
		_timeValue.color = ColorManager.Instance.ActiveColorLight;
		_repLabel.color = ColorManager.Instance.ActiveColorLight;
		_timeLabel.color = ColorManager.Instance.ActiveColorLight;
		UpdateWeightLabel ();
	}

	public void UpdateRepValue(int repValue)
	{
		_repValue.text = "x" + repValue;
	}

	public void UpdateTimeValue(int timeValue)
	{
		int minutes = timeValue / 60;
		int seconds = timeValue % 60;
		string secondsString;

		if (seconds < 10) 
		{
			secondsString = "0" + seconds.ToString ();
		} 
		else 
		{
			secondsString = seconds.ToString ();
		}

		_timeValue.text = minutes + ":" + secondsString;
	}

	public void UpdateWeightValue(int weightValue)
	{
		if (weightValue > 0) {
			_weightValue.text = weightValue.ToString ();
			_weightValue.color = ColorManager.Instance.ActiveColorLight;
			_weightLabel.color = ColorManager.Instance.ActiveColorLight;
		} else {
			_weightValue.text = "NA";
			_weightValue.color = ColorManager.Instance.ActiveColorDark;
			_weightLabel.color = ColorManager.Instance.ActiveColorDark;
		}
	}

	void UpdateWeightLabel()
	{
		_weightLabel.text = PlayerPrefs.GetString ("weightType") + "s";
	}
}
