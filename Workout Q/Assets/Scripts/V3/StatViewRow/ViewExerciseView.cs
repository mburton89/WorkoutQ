using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewExerciseView : MonoBehaviour {

	public static ViewExerciseView Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI _setsText;
	[SerializeField] private TextMeshProUGUI _repsText;
	[SerializeField] private TextMeshProUGUI _weightLabel;
	[SerializeField] private TextMeshProUGUI _weightText;
	[SerializeField] private TMP_InputField _exerciseName;

	public StatViewRow exerciseViewRow;
	public StatViewRow setsViewRow;

	public FitBoyAnimator fitBoyAnimator;

	void Awake()
	{
		Instance = this;
	}

	public void Init(ExerciseData exercise, int currentExerciseIndex, int totalExercises)
	{
		Show ();
		UpdateExerciseView (exercise.name, currentExerciseIndex, totalExercises);
		fitBoyAnimator.Init(exercise.exerciseType);
		_weightLabel.text = PlayerPrefs.GetString ("weightType") + "s";
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
		if (string.IsNullOrEmpty (label)) {
			_exerciseName.text = "Enter Exercise Name";
		} else {
			_exerciseName.text = label;
		}
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

	public void UpdateSetsView(int currentSet, int totalSets)
	{
		_setsText.text = currentSet + " of " + totalSets;
	}

	public void UpdateRepsView(int reps)
	{
		_repsText.text = "x " + reps;
	}

	public void UpdateWeightView(int weight)
	{
		_weightText.text = weight + PlayerPrefs.GetString ("weightType");
	}

	public void UpdateExerciseName(string exerciseName)
	{
		_exerciseName.text = exerciseName;
	}
}
