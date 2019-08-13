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

	public bool isCreatingNewExercise;

	public void Init(ExerciseData exerciseToEdit, bool isCreatingNewExercise, bool shouldAutoSelectInputField)
	{
		currentExerciseMenuItem = null;
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

		this.isCreatingNewExercise = isCreatingNewExercise;

		if (shouldAutoSelectInputField) {
			_exerciseNameInputField.Select ();
		}
	}

	public void Init(ExerciseMenuItem exerciseMenuItem, bool isCreatingNewExercise, bool shouldAutoSelectInputField)
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

		this.isCreatingNewExercise = isCreatingNewExercise;

		if (shouldAutoSelectInputField) {
			_exerciseNameInputField.Select ();
		}
	}

	public void CopyAndInit(ExerciseData exerciseToCopy, bool isCreatingNewExercise, bool shouldAutoSelectInputField)
	{
		ExerciseData copiedExercise = ExerciseData.Copy(
			exerciseToCopy.name,
			exerciseToCopy.secondsToCompleteSet,
			exerciseToCopy.totalInitialSets,
			exerciseToCopy.totalSets,
			exerciseToCopy.repsPerSet,
			exerciseToCopy.weight,
			exerciseToCopy.exerciseType
		);
	
		currentExerciseMenuItem = null;
		currentExerciseData = copiedExercise;
		_exerciseNameInputField.text = copiedExercise.name;
		_setsRow.Init (this);
		_repsRow.Init (this);
		_weightRow.Init (this);
		_secondsRow.Init (this);
		Show ();

		if (fitBoyAnimator != null) {
			fitBoyAnimator.Init(copiedExercise.exerciseType);
		}

		this.isCreatingNewExercise = isCreatingNewExercise;

		if (shouldAutoSelectInputField) {
			_exerciseNameInputField.Select ();
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
		currentExerciseData.name = _exerciseNameInputField.text;

		if (currentExerciseMenuItem != null) 
		{
			currentExerciseMenuItem.exerciseData.name = _exerciseNameInputField.text;
			currentExerciseMenuItem.UpdateText ();
			WorkoutManager.Instance.Save ();
		}
	}

	public void UpdateCurrentExerciseItem()
	{
		currentExerciseMenuItem.UpdateStatsText ();
	}
}
