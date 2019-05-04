using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExerciseTitlesController : MonoBehaviour {

	private WorkoutPlayerController _controller;

	[SerializeField] private TextMeshProUGUI _activeExerciseTitle;
	[SerializeField] private TextMeshProUGUI _nextExerciseTitle;

	private const string NEXT_PREFIX_LABEL = "Next: ";

	public void Init(WorkoutPlayerController controller)
	{
		_controller = controller;
	}

	public void UpdateActiveExerciseTitle(string currentExerciseTitle)
	{
		_activeExerciseTitle.text = currentExerciseTitle;
	}

	public void UpdateNextExerciseTitle(string nextExerciseTitle, int weightValue)
	{
		_nextExerciseTitle.text = NEXT_PREFIX_LABEL + nextExerciseTitle + " " + weightValue + PlayerPrefs.GetString ("weightType") + "s";
	}

	public void HideNextExerciseText()
	{
		_nextExerciseTitle.text = string.Empty;
	}
}
