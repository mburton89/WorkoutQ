using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewExerciseView : MonoBehaviour {

	public static ViewExerciseView Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private StatViewRow _setsViewRow;
	[SerializeField] private StatViewRow _secondsViewRow;
	[SerializeField] private TextMeshProUGUI _repsAndWeight;
	[SerializeField] private TextMeshProUGUI _exerciseName;

	void Awake()
	{
		Instance = this;
	}

	public void Init(string exerciseName)
	{
		Show ();
		UpdateExerciseName (exerciseName);
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	public void Hide()
	{
		_container.SetActive (false);
	}

	public void UpdateSetsValue(int value)
	{
		_setsViewRow.UpdateValue(value);
	}

	public void UpdateSecondsView(string label, int value)
	{
		_secondsViewRow.UpdateView (label, value);
	}

	public void UpdateRepsAndWeightView(int reps, int weight)
	{
		_repsAndWeight.text = reps + " Reps @ " + weight + "LBs";
	}

	public void UpdateExerciseName(string exerciseName)
	{
		_exerciseName.text = exerciseName;
	}
}
