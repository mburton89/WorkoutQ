using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditExerciseView : MonoBehaviour {

	[SerializeField] private GameObject _container;
	[SerializeField] public TMP_InputField _exerciseNameInputField;
	[SerializeField] private SetsEditRow _setsRow;
	[SerializeField] private RepsEditRow _repsRow;
	[SerializeField] private WeightEditRow _weightRow;
	[SerializeField] private SecondsEditRow _secondsRow;
	public FitBoyAnimator fitBoyAnimator;

	public ExerciseData currentExerciseData;
	[HideInInspector] public ExerciseMenuItem currentExerciseMenuItem;

	public void Init(ExerciseData exerciseToEdit)
	{
		currentExerciseData = exerciseToEdit;
		_exerciseNameInputField.text = exerciseToEdit.name;
		_setsRow.Init (this);
		_repsRow.Init (this);
		_weightRow.Init (this);
		_secondsRow.Init (this);
		Show ();

		if (fitBoyAnimator != null) {
			fitBoyAnimator.Init(exerciseToEdit.exerciseType);
		}
	}

	public void Init(ExerciseMenuItem exerciseMenuItem)
	{
		currentExerciseMenuItem = exerciseMenuItem;
		currentExerciseData = currentExerciseMenuItem.exerciseData;
		_exerciseNameInputField.text = currentExerciseData.name;
		_setsRow.Init (this);
		_repsRow.Init (this);
		_weightRow.Init (this);
		_secondsRow.Init (this);
		Show ();

		if (fitBoyAnimator != null) {
			fitBoyAnimator.Init(currentExerciseData.exerciseType);
		}
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	public void Hide()
	{
		_container.SetActive (false);
	}

	public void HandleInputFieldSubmitted(string title)
	{
		print ("KSJHDKJF");
		currentExerciseData.name = _exerciseNameInputField.text;
		currentExerciseMenuItem.exerciseData.name = _exerciseNameInputField.text;
		currentExerciseMenuItem.UpdateText ();
	}

	public void UpdateCurrentExerciseItem()
	{
		currentExerciseMenuItem.UpdateStatsText ();
	}
}
