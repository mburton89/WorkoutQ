using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewExerciseView : MonoBehaviour {

	public static ViewExerciseView Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private StatViewRow _exerciseViewRow;
	[SerializeField] private StatViewRow _setsViewRow;
	[SerializeField] private StatViewRow _secondsViewRow;
	[SerializeField] private TextMeshProUGUI _repsAndWeight;

	void Awake()
	{
		Instance = this;
	}

	public void Init(string label, int currentExerciseIndex, int totalExercises)
	{
		Show ();
		UpdateExerciseView (label, currentExerciseIndex, totalExercises);
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	public void Hide()
	{
		_container.SetActive (false);
	}

	public void UpdateExerciseView(string label, int currentExerciseIndex, int totalExercises)
	{
		_exerciseViewRow.UpdateViewCustomLabel ("XRC: " + (currentExerciseIndex + 1) + " of " + totalExercises, totalExercises);
		_exerciseViewRow.lineSegmenter.ShowSegmentLit (currentExerciseIndex);
	}

	public void UpdateSetsView(string label, int value)
	{
		_setsViewRow.UpdateView (label, value);
	}

	public void UpdateSecondsView(string label, int value)
	{
		_secondsViewRow.UpdateView (label, value);
	}

	public void UpdateRepsAndWeightView(int reps, int weight)
	{
		_repsAndWeight.text = reps + " Reps @ " + weight + "LBs";
	}
}
