using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewExerciseView : MonoBehaviour {

	public static ViewExerciseView Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI _repsAndWeight;

	public StatViewRow exerciseViewRow;
	public StatViewRow setsViewRow;

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
		//exerciseViewRow.UpdateViewCustomLabel ("XRC: " + (currentExerciseIndex + 1) + " of " + totalExercises, totalExercises);
		Header.Instance.UpdateMiddleLabel(label);
		exerciseViewRow.lineSegmenter.ShowSegmentLit (currentExerciseIndex);
	}

	public void UpdateSetsView(string label, int value)
	{
		setsViewRow.UpdateView (label, value);
	}

	public void ShowActiveSet(string label, int currentExerciseIndex)
	{
		setsViewRow.lineSegmenter.ShowSegmentLit (currentExerciseIndex);
	}

	public void UpdateRepsAndWeightView(int reps, int weight)
	{
		_repsAndWeight.text = reps + " Reps @ " + weight + "LBs";
	}
}
