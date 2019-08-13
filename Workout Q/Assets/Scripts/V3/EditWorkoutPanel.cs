using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class EditWorkoutPanel : MonoBehaviour 
{
	public static EditWorkoutPanel Instance;
	public WorkoutData currentWorkoutData;
	[HideInInspector] public WorkoutPanel currentWorkoutPanel;
	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI bottomTitle;
	[SerializeField] private TMP_InputField _workoutNameInputField;
	[SerializeField] private Button _backButton;
	[SerializeField] private ShadowButton _doneButton;
	[SerializeField] private ShadowButton _editTitleButton;
	[SerializeField] private ShadowButton _editIconButton;
	[SerializeField] private Button _clickOverlay;
	public WorkoutIconSelectMenu iconSelectMenu;
	[HideInInspector] public bool isCreatingNewWorkout;
	public FitBoyIlluminator workoutIconShower;

	[SerializeField] private TMP_InputField _secondsBetweenExercisesInputField;
	[SerializeField] private  ShadowButton _lessButton;
	[SerializeField] private  ShadowButton _moreButton;

	[SerializeField] List<Image> _colorImages;
	[SerializeField] List<TextMeshProUGUI> _texts;

	[SerializeField] private Slider _tenSecSlider;
	[SerializeField] private Button _onButton;
	[SerializeField] private Button _offButton;

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

		#if UNITY_ANDROID
		//Do nothing
		#else
		_secondsBetweenExercisesInputField.shouldHideMobileInput = false;
		#endif
	}

	public void Init(WorkoutData workoutToEdit, bool isCreatingNewWorkout, bool shouldAutoSelectInputField)
	{
		if (isCreatingNewWorkout) {
			workoutToEdit.secondsBetweenExercises = 60;
		}

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

		_secondsBetweenExercisesInputField.text = workoutToEdit.secondsBetweenExercises.ToString ();

		if (workoutToEdit.hasTenSecTimer)
		{
			_tenSecSlider.value = 0;	
		}
		else
		{
			_tenSecSlider.value = 1;			
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

		_secondsBetweenExercisesInputField.text = workoutToEdit.secondsBetweenExercises.ToString ();

		if (workoutToEdit.hasTenSecTimer)
		{
			_tenSecSlider.value = 0;	
		}
		else
		{
			_tenSecSlider.value = 1;			
		}
	}

	private void OnEnable()
	{
		_workoutNameInputField.onValueChanged.AddListener(HandleInputFieldSubmitted);
		_workoutNameInputField.onSubmit.AddListener(HandleInputFieldSubmitted);
		_clickOverlay.onClick.AddListener (Hide);
		_doneButton.onShortClick.AddListener (HandleDonePressed);
		_editTitleButton.onShortClick.AddListener (_workoutNameInputField.Select);
		_editIconButton.onShortClick.AddListener (HandleEditIconPressed);
		_backButton.onClick.AddListener (ShowEditPage);
		_lessButton.onShortClick.AddListener (Decrement);
		_moreButton.onShortClick.AddListener (Increment);
		_secondsBetweenExercisesInputField.onValueChanged.AddListener (HandleSecondsBetweenExercisesInputFieldChanged);
		_tenSecSlider.onValueChanged.AddListener (Handle10SecTimerChanged);
		_onButton.onClick.AddListener (HandleOnPressed);
		_offButton.onClick.AddListener(HandleOffPressed);
	}

	private void OnDisable()
	{
		_workoutNameInputField.onValueChanged.RemoveListener(HandleInputFieldSubmitted);
		_workoutNameInputField.onSubmit.RemoveListener(HandleInputFieldSubmitted);
		_clickOverlay.onClick.RemoveListener (Hide);
		_doneButton.onShortClick.RemoveListener (HandleDonePressed);
		_editTitleButton.onShortClick.RemoveListener (_workoutNameInputField.Select);
		_editIconButton.onShortClick.RemoveListener (HandleEditIconPressed);
		_backButton.onClick.RemoveListener (ShowEditPage);
		_lessButton.onShortClick.RemoveListener (Decrement);
		_moreButton.onShortClick.RemoveListener (Increment);
		_secondsBetweenExercisesInputField.onValueChanged.AddListener (HandleSecondsBetweenExercisesInputFieldChanged);
		_tenSecSlider.onValueChanged.RemoveListener(Handle10SecTimerChanged);
		_onButton.onClick.RemoveListener (HandleOnPressed);
		_offButton.onClick.RemoveListener(HandleOffPressed);
	}

	void HandleEditIconPressed()
	{
		iconSelectMenu.controller = this;
		iconSelectMenu.ShowWorkoutIcons ();
		_doneButton.gameObject.SetActive (false);
		_backButton.gameObject.SetActive (true);
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
		bottomTitle.text = "Edit Workout";
	}

	void CreateWorkoutPanel()
	{
		WorkoutData copiedWorkout = new WorkoutData ();
		copiedWorkout.name = currentWorkoutData.name;
		copiedWorkout.workoutType = currentWorkoutData.workoutType;
		copiedWorkout.secondsBetweenExercises = currentWorkoutData.secondsBetweenExercises;
		copiedWorkout.exerciseData = new List<ExerciseData> ();

		foreach(ExerciseData exercise in copiedWorkout.exerciseData){

			ExerciseData copiedExercise = ExerciseData.Copy(
				exercise.name,
				exercise.secondsToCompleteSet,
				exercise.totalInitialSets,
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

        if (currentWorkoutPanel != null)
        {
            currentWorkoutPanel.UpdateText();
        }
    }

	void Decrement()
	{
		if (currentWorkoutData.secondsBetweenExercises > 0) 
		{
			currentWorkoutData.secondsBetweenExercises = currentWorkoutData.secondsBetweenExercises - 5;			
		}

		if (currentWorkoutData.secondsBetweenExercises < 0)
		{
			currentWorkoutData.secondsBetweenExercises = 0;
		}

		_secondsBetweenExercisesInputField.text = currentWorkoutData.secondsBetweenExercises.ToString();

		SoundManager.Instance.PlayButtonPressSound ();

        WorkoutManager.Instance.Save();
    }

    void Increment()
	{
		if (currentWorkoutData.secondsBetweenExercises < 995) 
		{
			currentWorkoutData.secondsBetweenExercises = currentWorkoutData.secondsBetweenExercises + 5;			
		}

		if (currentWorkoutData.secondsBetweenExercises > 999)
		{
			currentWorkoutData.secondsBetweenExercises = 999;
		}

		_secondsBetweenExercisesInputField.text = currentWorkoutData.secondsBetweenExercises.ToString();

		SoundManager.Instance.PlayButtonPressSound ();

        WorkoutManager.Instance.Save();
    }

    void HandleSecondsBetweenExercisesInputFieldChanged(string value)
	{
		int newValue;

		if(string.IsNullOrEmpty(value))
		{
			newValue = 0;
		}
		else
		{
			newValue = int.Parse(value);
		}

		currentWorkoutData.secondsBetweenExercises = newValue;

        WorkoutManager.Instance.Save();
    }

	void Handle10SecTimerChanged(float tenSec)
	{
		if (tenSec == 0) {
			currentWorkoutData.hasTenSecTimer = true;
		}
		else
		{
			currentWorkoutData.hasTenSecTimer = false;
		}

		WorkoutManager.Instance.Save ();
	}

	void HandleOnPressed()
	{
		_tenSecSlider.value = 0;
		WorkoutManager.Instance.Save ();
	}

	void HandleOffPressed()
	{
		_tenSecSlider.value = 1;
		WorkoutManager.Instance.Save ();
	}
}
