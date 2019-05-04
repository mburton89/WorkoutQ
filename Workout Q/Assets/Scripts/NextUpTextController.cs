using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextUpTextController : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI _label;
	[SerializeField] private TextMeshProUGUI _exerciseName;
	[SerializeField] private TextMeshProUGUI _exerciseStats;

	void Start(){
		_label.color = ColorManager.Instance.ActiveColorDark;
		_exerciseName.color = ColorManager.Instance.ActiveColorDark;
		_exerciseStats.color = ColorManager.Instance.ActiveColorDark;
	}

	public void ShowNextExerciseText(ExerciseData nextExercise)
	{
		if (nextExercise != null) {
			_label.text = "Next: ";
			_exerciseName.text = nextExercise.name;
			_exerciseStats.text = nextExercise.totalInitialSets
			+ "x"
			+ nextExercise.repsPerSet
			+ "  "
			+ nextExercise.weight
			+ PlayerPrefs.GetString ("weightType") + "s  "
			+ nextExercise.secondsToCompleteSet + "s ";
		} else {
			ShowNothing ();
		}
	}

	public void ShowNothing()
	{
		_label.text = string.Empty;
		_exerciseName.text = string.Empty;
		_exerciseStats.text = string.Empty;
	}
}
