using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class EditWorkoutPanel : MonoBehaviour {

	public static EditWorkoutPanel Instance;
	public WorkoutData currentWorkoutData;
	[HideInInspector] public WorkoutPanel currentWorkoutPanel;
	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI topTitle;
	[SerializeField] private TextMeshProUGUI bottomTitle;
	[SerializeField] private TMP_InputField _workoutNameInputField;
	[SerializeField] private ShadowButton _backButton;
	[SerializeField] private ShadowButton _doneButton;
	[SerializeField] private ShadowButton _editTitleButton;
	[SerializeField] private ShadowButton _editIconButton;
	[SerializeField] private Button _clickOverlay;
	public WorkoutIconSelectMenu iconSelectMenu;
	[HideInInspector] public bool isCreatingNewWorkout;
	public FitBoyIlluminator workoutIconShower;

	[SerializeField] List<Image> _colorImages;
	[SerializeField] List<TextMeshProUGUI> _texts;

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		foreach (Image colorImage in _colorImages)
		{
			colorImage.color = ColorManager.Instance.ActiveColorLight;	
		}	

		foreach (TextMeshProUGUI text in _texts)
		{
			text.color = ColorManager.Instance.ActiveColorLight;	
		}	

		topTitle.color = ColorManager.Instance.ActiveColorDark;
		bottomTitle.color = ColorManager.Instance.ActiveColorLight;
	}

	public void Init(WorkoutData workoutToEdit, bool isCreatingNewWorkout, bool shouldAutoSelectInputField)
	{
		currentWorkoutPanel = null;
		currentWorkoutData = workoutToEdit;
		_workoutNameInputField.text = workoutToEdit.name;

		Show ();

		if (workoutIconShower != null) {
			workoutIconShower.Init(workoutToEdit.workoutType);
		}

		this.isCreatingNewWorkout = isCreatingNewWorkout;

		if (shouldAutoSelectInputField) {
			_workoutNameInputField.Select ();
		}
	}

	public void Init(WorkoutPanel workoutPanel, bool isCreatingNewWorkout, bool shouldAutoSelectInputField)
	{
		currentWorkoutPanel = workoutPanel;
		WorkoutData workoutToEdit = workoutPanel.workoutData;
		currentWorkoutData = workoutToEdit;
		_workoutNameInputField.text = workoutToEdit.name;

		Show ();

		if (workoutIconShower != null) {
			workoutIconShower.Init(workoutToEdit.workoutType);
		}

		this.isCreatingNewWorkout = isCreatingNewWorkout;

		if (shouldAutoSelectInputField) {
			_workoutNameInputField.Select ();
		}
	}

	private void OnEnable()
	{
		_workoutNameInputField.onValueChanged.AddListener(HandleInputFieldSubmitted);
		_clickOverlay.onClick.AddListener (Hide);
		_doneButton.onShortClick.AddListener (HandleDonePressed);
		_editTitleButton.onShortClick.AddListener (_workoutNameInputField.Select);
		_editIconButton.onShortClick.AddListener (HandleEditIconPressed);
		_backButton.onShortClick.AddListener (ShowEditPage);
	}

	private void OnDisable()
	{
		_workoutNameInputField.onValueChanged.RemoveListener(HandleInputFieldSubmitted);
		_clickOverlay.onClick.RemoveListener (Hide);
		_doneButton.onShortClick.RemoveListener (HandleDonePressed);
		_editTitleButton.onShortClick.RemoveListener (_workoutNameInputField.Select);
		_editIconButton.onShortClick.RemoveListener (HandleEditIconPressed);
		_backButton.onShortClick.RemoveListener (ShowEditPage);
	}

	void HandleEditIconPressed()
	{
		iconSelectMenu.controller = this;
		iconSelectMenu.ShowWorkoutIcons ();
		_doneButton.gameObject.SetActive (false);
		_backButton.gameObject.SetActive (true);
		topTitle.text = "Edit Workout";
		bottomTitle.text = "Choose Icon";
	}

	public void UpdateIcon(WorkoutType newWorkoutType)
	{
		currentWorkoutData.workoutType = newWorkoutType;
		workoutIconShower.Init (newWorkoutType);

		if (currentWorkoutPanel != null) 
		{
			currentWorkoutPanel.fitBoyIlluminator.Init (newWorkoutType);
		}

		ShowEditPage ();
		WorkoutManager.Instance.Save ();
	}

	void ShowEditPage(){
		iconSelectMenu.Hide ();
		_doneButton.gameObject.SetActive (true);
		_backButton.gameObject.SetActive (false);
		topTitle.text = "";
		bottomTitle.text = "Edit Workout";
	}

	void CreateWorkoutPanel()
	{
		WorkoutData copiedWorkout = new WorkoutData ();
		copiedWorkout.name = currentWorkoutData.name;
		copiedWorkout.workoutType = currentWorkoutData.workoutType;
		copiedWorkout.exerciseData = new List<ExerciseData> ();

		foreach(ExerciseData exercise in copiedWorkout.exerciseData){

			ExerciseData copiedExercise = ExerciseData.Copy(
				exercise.name,
				exercise.secondsToCompleteSet,
				exercise.totalSets,
				exercise.repsPerSet,
				exercise.weight,
				exercise.exerciseType
			);

			copiedWorkout.exerciseData.Add(copiedExercise);
		}

		WorkoutHUD.Instance.AddWorkoutPanel(copiedWorkout, false);
		SoundManager.Instance.PlayButtonPressSound();
		WorkoutManager.Instance.Save();

		Hide ();

		Canvas.ForceUpdateCanvases ();
		WorkoutHUD.Instance.workoutsScrollRect.verticalScrollbar.value = 0f;
		Canvas.ForceUpdateCanvases ();
	}

	void HandleDonePressed()
	{
		if (isCreatingNewWorkout) 
		{
			CreateWorkoutPanel ();
		}
		else 
		{
			Hide ();
		}
	}

	public void HandleInputFieldSubmitted(string title)
	{
		currentWorkoutData.name = title;

		if (currentWorkoutPanel != null) 
		{
			currentWorkoutPanel.workoutData.name = title;
			currentWorkoutPanel.UpdateText ();
			WorkoutManager.Instance.Save ();
		}

		if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
		{
			Header.Instance.UpdateMiddleLabel (title);
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
}
