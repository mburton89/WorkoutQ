using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditExerciseView : MonoBehaviour {

	[SerializeField] private GameObject _container;
	[SerializeField] private TMP_InputField _exerciseNameInputField;
	[SerializeField] private SetsEditRow _setsRow;
	[SerializeField] private RepsEditRow _repsRow;
	[SerializeField] private WeightEditRow _weightRow;
	[SerializeField] private SecondsEditRow _secondsRow;

	public ExerciseData currentExerciseData;

	void OnEnable () 
	{
		_exerciseNameInputField.onSubmit.AddListener(delegate{HandleInputFieldSubmitted();});
	}

	void OnDisable () 
	{
		_exerciseNameInputField.onSubmit.RemoveListener(delegate{HandleInputFieldSubmitted();});
	}

	public void Init(ExerciseData exerciseToEdit)
	{
		currentExerciseData = exerciseToEdit;
		_exerciseNameInputField.text = exerciseToEdit.name;
		_setsRow.Init (this);
		_repsRow.Init (this);
		_weightRow.Init (this);
		_secondsRow.Init (this);
		Show ();
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	public void Hide()
	{
		_container.SetActive (false);
	}

	public void HandleInputFieldSubmitted()
	{
		currentExerciseData.name = _exerciseNameInputField.text;
	}
}
