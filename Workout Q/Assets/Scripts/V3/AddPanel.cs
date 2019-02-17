using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AddPanel : MonoBehaviour {

	public static AddPanel Instance;
    
	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI _title;
	[SerializeField] private ShadowTextButton _addCustomButton;
	[SerializeField] private ShadowTextButton _doneButton;
	[SerializeField] private Button _clickOverlay;
	[SerializeField] private WorkoutPanel _addWorkoutItemPrefab;
	[SerializeField] private ExerciseMenuItem _addExerciseItemPrefab;
	[SerializeField] private GridLayoutGroup _gridLayout;
	[SerializeField] private TMP_InputField _searchInputField;
	[SerializeField] private Image _searchIcon;

	private List<WorkoutPanel> _workoutPanels = new List<WorkoutPanel>();
	private List<ExerciseMenuItem> _exerciseMenuItems = new List<ExerciseMenuItem>();

	private bool _isForWorkouts;

	private void Awake()
	{
		Instance = this;
	}

	private void OnEnable()
	{
		_addCustomButton.onShortClick.AddListener(AddCustom);
		_doneButton.onShortClick.AddListener(Exit);
		_clickOverlay.onClick.AddListener(Exit);
		_searchInputField.onValueChanged.AddListener (HandleSearch);
	}

	private void OnDisable()
    {
		_addCustomButton.onShortClick.RemoveListener(AddCustom);
		_doneButton.onShortClick.RemoveListener(Exit);
		_clickOverlay.onClick.RemoveListener(Exit);
		_searchInputField.onValueChanged.RemoveListener (HandleSearch);
	}

    public void ShowForAddWorkouts()
	{
		_container.SetActive(true);
		_title.text = "Add Workouts";
		ShowPreloadedWorkouts();
		_isForWorkouts = true;
	}

	public void ShowForAddExercises()
    {
        _container.SetActive(true);
		_title.text = "Add Exercises";
        ShowPreloadedExercises();
		_isForWorkouts = false;
	}

	public void Exit () 
	{
		TryClear();
		_container.SetActive(false);
	}

    void AddCustom()
	{
		if(_isForWorkouts)
		{
			WorkoutHUD.Instance.AddWorkoutPanel(null, true);
		}
		else
		{
			WorkoutHUD.Instance.AddExercisePanel(WorkoutManager.Instance.ActiveWorkout, null, true);
		}

		Exit();
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
			exerciseMenuItem.UpdateColor();
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

			_searchIcon.gameObject.SetActive (false);
		}
	}
}
