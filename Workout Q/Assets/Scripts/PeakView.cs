using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeakView : MonoBehaviour {

	public static PeakView Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private LineSegment _headerLineSegmentToLight;
	[SerializeField] private LineSegmenter _lineSegmenter;
	[SerializeField] private FitBoyAnimator _fitBoy;
	[SerializeField] private TextMeshProUGUI _exerciseName;
	[SerializeField] private TextMeshProUGUI _setAmount;
	[SerializeField] private TextMeshProUGUI _repAmount;
	[SerializeField] private TextMeshProUGUI _weightAmount;
	[SerializeField] private TextMeshProUGUI _secondsAmount;

	private int _peakIndex;

	void Awake()
	{
		Instance = this;
	}

	public void PeakAtExercise(ExerciseData exerciseToPeakAt)
	{
		_peakIndex = PlayModeManager.Instance.ActiveWorkout.exerciseData.IndexOf (exerciseToPeakAt);
		_container.SetActive (true);
		_lineSegmenter.Init(exerciseToPeakAt.totalInitialSets);
		_fitBoy.Init(exerciseToPeakAt.exerciseType);
		_exerciseName.text = exerciseToPeakAt.name.ToString();
		_setAmount.text = exerciseToPeakAt.totalInitialSets.ToString();
		_repAmount.text = "x " + exerciseToPeakAt.repsPerSet.ToString();
		_weightAmount.text = exerciseToPeakAt.weight.ToString() + " lb";
		_secondsAmount.text = exerciseToPeakAt.secondsToCompleteSet.ToString() + "s";
	}

	public void FinishPeaking()
	{
		_container.SetActive (false);
	}
}
