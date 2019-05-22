using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExerciseTitlesController : MonoBehaviour {

	private WorkoutPlayerController _controller;

	[SerializeField] private TextMeshProUGUI _activeExerciseTitle;
	[SerializeField] private TextMeshProUGUI _nextExerciseTitle;
	//[SerializeField] private TextMeshProUGUI _nextExerciseLabel;

	public void Init(WorkoutPlayerController controller)
	{
		_controller = controller;
		_activeExerciseTitle.color = ColorManager.Instance.ActiveColorLight;
		_nextExerciseTitle.color = ColorManager.Instance.ActiveColorLight;
	}

	public void UpdateActiveExerciseTitle(string currentExerciseTitle)
	{
		_activeExerciseTitle.text = currentExerciseTitle;
	}

	public void UpdateNextExerciseTitle(string nextExerciseTitle, int weightValue)
	{
		_nextExerciseTitle.text = nextExerciseTitle + " " + weightValue + PlayerPrefs.GetString ("weightType") + "s";
	}

	public void HideNextExerciseText()
	{
		_nextExerciseTitle.text = string.Empty;
	}
}
