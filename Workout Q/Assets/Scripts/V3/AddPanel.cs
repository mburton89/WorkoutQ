using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
	}

	private void OnDisable()
    {
		_addCustomButton.onShortClick.RemoveListener(AddCustom);
		_doneButton.onShortClick.RemoveListener(Exit);
		_clickOverlay.onClick.RemoveListener(Exit);
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

	void Exit () 
	{
		TryClear();
		_container.SetActive(false);
	}

    void AddCustom()
	{
		if(_isForWorkouts)
		{
			WorkoutHUD.Instance.AddWorkoutPanel(null);
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
			workoutMenuItem.workoutData = workout;
			workoutMenuItem.UpdateText();
			workoutMenuItem.UpdateColor();
            workoutMenuItem.transform.SetParent(_gridLayout.transform);
            workoutMenuItem.transform.localScale = Vector3.one;
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
        }
	}

    void TryClear()
	{
		foreach (ExerciseMenuItem exercisePanel in _gridLayout.GetComponentsInChildren<ExerciseMenuItem>())
        {
            Destroy(exercisePanel.gameObject);
        }

		foreach (WorkoutPanel workoutPanel in _gridLayout.GetComponentsInChildren<WorkoutPanel>())
        {
            Destroy(workoutPanel.gameObject);
        }
	}
}
