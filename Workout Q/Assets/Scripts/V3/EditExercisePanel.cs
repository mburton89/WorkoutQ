using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class EditExercisePanel : EditExerciseView {

	public static EditExercisePanel Instance;
	[SerializeField] private TextMeshProUGUI bottomTitle;
	[SerializeField] private Button _backButton;
	[SerializeField] private ShadowButton _doneButton;
	[SerializeField] private ShadowButton _editTitleButton;
	[SerializeField] private ShadowButton _editIconButton;
	[SerializeField] private Button _clickOverlay;
	public IconSelectMenu iconSelectMenu;

	private int _currentExerciseSecRemaining;
	private int _currentExerciseSetsComplete;

	private void Start()
	{
		Instance = this;
	}

	private void OnEnable()
	{
		_exerciseNameInputField.onValueChanged.AddListener(HandleInputFieldSubmitted);
		_clickOverlay.onClick.AddListener (HandleDonePressed);
		_doneButton.onShortClick.AddListener (HandleDonePressed);
		_editTitleButton.onShortClick.AddListener (_exerciseNameInputField.Select);
		_editIconButton.onShortClick.AddListener (HandleEditIconPressed);
		_backButton.onClick.AddListener (ShowEditPage);
	}

	private void OnDisable()
	{
		_exerciseNameInputField.onValueChanged.RemoveListener(HandleInputFieldSubmitted);
		_clickOverlay.onClick.RemoveListener (HandleDonePressed);
		_doneButton.onShortClick.RemoveListener (HandleDonePressed);
		_editTitleButton.onShortClick.RemoveListener (_exerciseNameInputField.Select);
		_editIconButton.onShortClick.RemoveListener (HandleEditIconPressed);
		_backButton.onClick.RemoveListener (ShowEditPage);
	}

	void HandleEditIconPressed()
	{
		iconSelectMenu.controller = this;
		iconSelectMenu.ShowExerciseIcons ();
		_doneButton.gameObject.SetActive (false);
		_backButton.gameObject.SetActive (true);
		bottomTitle.text = "Choose Icon";
	}

	public void UpdateIcon(ExerciseType newExerciseType)
	{
		currentExerciseData.exerciseType = newExerciseType;
		fitBoyAnimator.Init (newExerciseType);
		if (currentExerciseMenuItem != null) {
			currentExerciseMenuItem.fitBoyAnimator.Init (newExerciseType);
		}
		ShowEditPage ();
		WorkoutManager.Instance.Save ();
	}

	void ShowEditPage(){
		iconSelectMenu.Hide ();
		_doneButton.gameObject.SetActive (true);
		_backButton.gameObject.SetActive (false);
		bottomTitle.text = "Edit Exercise";
	}

	void CreateExerciseMenuItem()
	{
		ExerciseData copiedExercise = ExerciseData.Copy(
			currentExerciseData.name,
			currentExerciseData.secondsToCompleteSet,
			currentExerciseData.totalInitialSets,
			currentExerciseData.totalSets,
			currentExerciseData.repsPerSet,
			currentExerciseData.weight,
			currentExerciseData.exerciseType
		);

		WorkoutManager.Instance.ActiveWorkout.exerciseData.Add(copiedExercise);
		WorkoutHUD.Instance.AddExercisePanel(null, copiedExercise, false);
		SoundManager.Instance.PlayButtonPressSound();
		Header.Instance.SetUpForExercisesMenu(WorkoutManager.Instance.ActiveWorkout);
		WorkoutManager.Instance.Save();

		Hide ();

		Canvas.ForceUpdateCanvases ();
		WorkoutHUD.Instance.exercisesScrollRect.verticalScrollbar.value = 0f;
		Canvas.ForceUpdateCanvases ();
	}

	void HandleDonePressed()
	{
		if (isCreatingNewExercise) 
		{
			CreateExerciseMenuItem ();
		}
		else 
		{
			Hide ();
		}

		if (WorkoutHUD.Instance.currentMode == Mode.EditingExercise || WorkoutHUD.Instance.currentMode == Mode.PlayingExercise) 
		{
			WorkoutPlayerController.Instance.Refresh (_currentExerciseSecRemaining, _currentExerciseSetsComplete);
			ResetCurrentExerciseStats ();
		}
	}

	public void StoreCurrentExerciseSetsAndTime(int sec, int setsComplete)
	{
		_currentExerciseSecRemaining = sec;
		_currentExerciseSetsComplete = setsComplete;
	}

	void ResetCurrentExerciseStats()
	{
		_currentExerciseSecRemaining = 0;
		_currentExerciseSetsComplete = 0;
	}
}
