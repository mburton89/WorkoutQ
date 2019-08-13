using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AddPanel : MonoBehaviour {

	public static AddPanel Instance;

    [SerializeField] private GameObject _container;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private ShadowButton _addCustomButton;
	[SerializeField] private Button _doneButton;
	[SerializeField] private Button _backButton;
	[SerializeField] private ShadowButton _addWorkoutButton;
	[SerializeField] private Button _clickOverlay;
	[SerializeField] private WorkoutPanel _addWorkoutItemPrefab;
	[SerializeField] private ExerciseMenuItem _addExerciseItemPrefab;
	[SerializeField] private ExerciseMenuItem _nonClickableExerciseItemPrefab;
	[SerializeField] private GridLayoutGroup _gridLayout;
	[SerializeField] private TMP_InputField _searchInputField;
	[SerializeField] private GameObject _searchContainer;
	[SerializeField] private GameObject _headerLine2;
	[SerializeField] private Image _searchIcon;

	private List<WorkoutPanel> _workoutPanels = new List<WorkoutPanel>();
	private List<ExerciseMenuItem> _exerciseMenuItems = new List<ExerciseMenuItem>();

	private bool _isForWorkouts;

	[HideInInspector] public WorkoutData currentWorkoutData;

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
	}

	private void OnEnable()
	{
		_addCustomButton.onShortClick.AddListener(AddCustom);
		_doneButton.onClick.AddListener(Exit);
		_clickOverlay.onClick.AddListener(Exit);
		_searchInputField.onValueChanged.AddListener (HandleSearch);
		_backButton.onClick.AddListener (HandleBackPressed);
		_addWorkoutButton.onShortClick.AddListener (HandleAddWorkoutPressed);
	}

	private void OnDisable()
    {
		_addCustomButton.onShortClick.RemoveListener(AddCustom);
		_doneButton.onClick.RemoveListener(Exit);
		_clickOverlay.onClick.RemoveListener(Exit);
		_searchInputField.onValueChanged.RemoveListener (HandleSearch);
		_backButton.onClick.RemoveListener (HandleBackPressed);
		_addWorkoutButton.onShortClick.RemoveListener (HandleAddWorkoutPressed);
	}

    public void ShowForAddWorkouts()
	{
		_container.SetActive(true);
		_title.text = "Add Workout";
		ShowPreloadedWorkouts();
		_isForWorkouts = true;
		_searchContainer.SetActive (true);
		_headerLine2.SetActive (true);
		_addCustomButton.gameObject.SetActive (true);
		_addWorkoutButton.gameObject.SetActive (false);
	}

	public void ShowForAddExercises()
    {
        _container.SetActive(true);
		_title.text = "Add Exercise";
        ShowPreloadedExercises();
		_isForWorkouts = false;
		_searchContainer.SetActive (true);
		_headerLine2.SetActive (true);
	}

	public void Exit () 
	{
		TryClear();
		_container.SetActive(false);
		_searchInputField.text = string.Empty;
	}

    void AddCustom()
	{
		if(_isForWorkouts)
		{
			WorkoutData emptyWorkoutData = new WorkoutData ();
			emptyWorkoutData.name = "New Workout";
			EditWorkoutPanel.Instance.Init (emptyWorkoutData, true, false);
		}
		else
		{
			//WorkoutHUD.Instance.AddExercisePanel(WorkoutManager.Instance.ActiveWorkout, null, true);
			ExerciseData emptyExerciseData = new ExerciseData ();
			emptyExerciseData.name = "New Exercise";
			emptyExerciseData.totalInitialSets = 3;
			emptyExerciseData.totalSets = 3;
			emptyExerciseData.repsPerSet = 10;
			emptyExerciseData.weight = 0;
			emptyExerciseData.secondsToCompleteSet = 90;
			EditExercisePanel.Instance.Init (emptyExerciseData, true, true);
		}

		Exit();

		Canvas.ForceUpdateCanvases ();
		WorkoutHUD.Instance.workoutsScrollRect.verticalScrollbar.value = 0f;
		Canvas.ForceUpdateCanvases ();
	}

	void ShowPreloadedWorkouts()
    {
		foreach (WorkoutData workout in WorkoutGenerator.Instance.preloadedWorkouts)
        {
			WorkoutPanel workoutMenuItem = Instantiate(_addWorkoutItemPrefab);
			workoutMenuItem.Init (workout);
            workoutMenuItem.transform.SetParent(_gridLayout.transform);
            workoutMenuItem.transform.localScale = Vector3.one;
			_workoutPanels.Add (workoutMenuItem);
        }
    }

    void ShowPreloadedExercises()
	{
		foreach(ExerciseData exercise in WorkoutGenerator.Instance.preloadedExercises)
		{
			ExerciseMenuItem exerciseMenuItem = Instantiate(_addExerciseItemPrefab);
			exerciseMenuItem.Init(exercise);
			exerciseMenuItem.transform.SetParent(_gridLayout.transform);
			exerciseMenuItem.transform.localScale = Vector3.one;

			_exerciseMenuItems.Add (exerciseMenuItem);
        }
	}

    void TryClear()
	{
		foreach (ExerciseMenuItem exercisePanel in _gridLayout.GetComponentsInChildren<ExerciseMenuItem>())
        {
            Destroy(exercisePanel.gameObject);
			_exerciseMenuItems.Clear ();
        }

		foreach (WorkoutPanel workoutPanel in _gridLayout.GetComponentsInChildren<WorkoutPanel>())
        {
            Destroy(workoutPanel.gameObject);
			_workoutPanels.Clear ();
        }
	}

	void HandleSearch(string searchText)
	{
		if (_isForWorkouts) {
			if (string.IsNullOrEmpty (searchText)) {
				foreach (WorkoutPanel workoutPanel in _workoutPanels) {
					workoutPanel.gameObject.SetActive (true);
				}
				_searchIcon.gameObject.SetActive (true);
				return;
			}

			foreach (WorkoutPanel workoutPanel in _workoutPanels) 
			{
				if (!workoutPanel.workoutData.name.ToLower ().Contains (searchText.ToLower ())) 
				{
					workoutPanel.gameObject.SetActive (false);
				}
				else 
				{
					workoutPanel.gameObject.SetActive (true);
				}
			}

			_searchIcon.gameObject.SetActive (false);
		} 
		else 
		{
			if (string.IsNullOrEmpty (searchText)) 
			{
				foreach (ExerciseMenuItem exerciseMenuItem in _exerciseMenuItems)
				{
					exerciseMenuItem.gameObject.SetActive (true);
					exerciseMenuItem.fitBoyAnimator.Play ();
				}
				_searchIcon.gameObject.SetActive (true);
				return;
			}

			foreach (ExerciseMenuItem exerciseMenuItem in _exerciseMenuItems) 
			{
				if (!exerciseMenuItem.exerciseData.name.ToLower ().Contains (searchText.ToLower ())) {
					exerciseMenuItem.gameObject.SetActive (false);
				} else {
					exerciseMenuItem.gameObject.SetActive (true);
					exerciseMenuItem.fitBoyAnimator.Play ();
				}
			}
		}
	}

	public void ShowExercisesForWorkout(WorkoutData workout)
	{
		TryClear ();

		currentWorkoutData = workout;

		foreach (ExerciseData exercise in currentWorkoutData.exerciseData)
		{
			ExerciseMenuItem exerciseMenuItem = Instantiate(_nonClickableExerciseItemPrefab);
			exerciseMenuItem.Init (exercise);
			exerciseMenuItem.transform.SetParent(_gridLayout.transform);
			exerciseMenuItem.transform.localScale = Vector3.one;
			_exerciseMenuItems.Add (exerciseMenuItem);
		}

		_title.text = currentWorkoutData.name;

		_backButton.gameObject.SetActive (true);
		_addWorkoutButton.gameObject.SetActive (true);
		_searchContainer.SetActive (false);
		_headerLine2.SetActive (false);
		_addCustomButton.gameObject.SetActive (false);
	}

	void HandleBackPressed()
	{
		_backButton.gameObject.SetActive (false);
		_addWorkoutButton.gameObject.SetActive (false);
		_addCustomButton.gameObject.SetActive (true);

		TryClear ();

		ShowForAddWorkouts ();

		SoundManager.Instance.PlayButtonPressSound ();
	}

	void HandleAddWorkoutPressed()
	{
		_backButton.gameObject.SetActive (false);
		_addWorkoutButton.gameObject.SetActive (false);

		WorkoutData copiedWorkout = new WorkoutData ();
		copiedWorkout.name = currentWorkoutData.name;
		copiedWorkout.workoutType = currentWorkoutData.workoutType;
		copiedWorkout.secondsBetweenExercises = currentWorkoutData.secondsBetweenExercises;
		copiedWorkout.exerciseData = new List<ExerciseData> ();

		foreach(ExerciseData exercise in currentWorkoutData.exerciseData){

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

		AddPanel.Instance.Exit ();

//		Canvas.ForceUpdateCanvases ();
//		WorkoutHUD.Instance.workoutsScrollRect.verticalScrollbar.value = 0f;
//		Canvas.ForceUpdateCanvases ();
	}
}
