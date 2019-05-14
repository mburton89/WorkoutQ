using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddPlanPanel : MonoBehaviour {

	public static AddPlanPanel Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI _topTitle;
	[SerializeField] private TextMeshProUGUI _bottomTitle;
	[SerializeField] private TextMeshProUGUI _textBody;
	[SerializeField] private ShadowButton _skipButton;
	[SerializeField] private ShadowButton _choosePlanButton;
	[SerializeField] private ShadowButton _backButton;
	[SerializeField] private Button _clickOverlay;
	[SerializeField] private PlanMenuItem _addPlanItemPrefab;
	[SerializeField] private WorkoutPanel _addWorkoutItemPrefab;
	[SerializeField] private ExerciseMenuItem _addExerciseItemPrefab;
	[SerializeField] private GridLayoutGroup _gridLayout;

	private List<PlanMenuItem> _planPanels = new List<PlanMenuItem>();
	private List<WorkoutPanel> _workoutPanels = new List<WorkoutPanel>();
	private List<ExerciseMenuItem> _exerciseMenuItems = new List<ExerciseMenuItem>();

	private const string TITLE_TEXT = "Choose a plan";
	private const string CHOOSE_PLAN_INFO = "Or tap 'SKIP' to plug in your own workouts and exercises.";
	private PlanData _currentPlanData;

	[SerializeField] List<Image> _colorImages;

	private enum PlanPanelViewMode{
		ShowingPlans,
		ShowingWorkouts,
		ShowingExercises
	}

	private PlanPanelViewMode _currentMode;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		foreach (Image colorImage in _colorImages)
		{
			colorImage.color = ColorManager.Instance.ActiveColorLight;	
		}	

		_topTitle.color = ColorManager.Instance.ActiveColorMedium;
	}

	void OnEnable()
	{
		_skipButton.onShortClick.AddListener (HandleSkipPressed);
		_choosePlanButton.onShortClick.AddListener (HandleChoosePlanPressed);
		_backButton.onShortClick.AddListener (HandleBackPressed);
		_clickOverlay.onClick.AddListener(Exit);
	}

	void OnDisable()
	{
		_skipButton.onShortClick.RemoveListener (HandleSkipPressed);
		_choosePlanButton.onShortClick.RemoveListener (HandleChoosePlanPressed);
		_backButton.onShortClick.RemoveListener (HandleBackPressed);
		_clickOverlay.onClick.RemoveListener(Exit);
	}

	public void ShowPlans()
	{
		TryClear ();

		_container.SetActive (true);

		foreach (PlanData plan in WorkoutGenerator.Instance.preloadedPlans)
		{
			PlanMenuItem planMenuItem = Instantiate(_addPlanItemPrefab);
			planMenuItem.Init (this, plan);
			planMenuItem.transform.SetParent(_gridLayout.transform);
			planMenuItem.transform.localScale = Vector3.one;
			_planPanels.Add (planMenuItem);
		}

		_topTitle.text = "";
		_bottomTitle.text = TITLE_TEXT;
		_textBody.text = CHOOSE_PLAN_INFO;
		_skipButton.gameObject.SetActive (true);
		_choosePlanButton.gameObject.SetActive (false);
		_backButton.gameObject.SetActive (false);
		_currentMode = PlanPanelViewMode.ShowingPlans;
	}

	public void ShowWorkoutsForPlan(PlanData plan)
	{
		TryClear ();

		foreach (WorkoutData workout in plan.workoutData)
		{
			WorkoutPanel workoutPanel = Instantiate(_addWorkoutItemPrefab);
			workoutPanel.Init (workout);
			workoutPanel.transform.SetParent(_gridLayout.transform);
			workoutPanel.transform.localScale = Vector3.one;
			_workoutPanels.Add (workoutPanel);
		}

		_topTitle.text = TITLE_TEXT;
		_bottomTitle.text = plan.name;
		_textBody.text = plan.description;
		_skipButton.gameObject.SetActive (false);
		_choosePlanButton.gameObject.SetActive (true);	
		_backButton.gameObject.SetActive (true);
		_currentPlanData = plan;
		_currentMode = PlanPanelViewMode.ShowingWorkouts;
	}

	public void ShowExercisesForWorkout(WorkoutData workout)
	{
		TryClear ();

		foreach (ExerciseData exercise in workout.exerciseData)
		{
			ExerciseMenuItem exerciseMenuItem = Instantiate(_addExerciseItemPrefab);
			exerciseMenuItem.Init (exercise);
			exerciseMenuItem.transform.SetParent(_gridLayout.transform);
			exerciseMenuItem.transform.localScale = Vector3.one;
			_exerciseMenuItems.Add (exerciseMenuItem);
		}

		_topTitle.text = _currentPlanData.name;
		_bottomTitle.text = workout.name;
		_currentMode = PlanPanelViewMode.ShowingExercises;
	}

	void TryClear()
	{
		foreach (PlanMenuItem planMenuItem in _gridLayout.GetComponentsInChildren<PlanMenuItem>())
		{
			Destroy(planMenuItem.gameObject);
			_planPanels.Clear ();
		}

		foreach (WorkoutPanel workoutPanel in _gridLayout.GetComponentsInChildren<WorkoutPanel>())
		{
			Destroy(workoutPanel.gameObject);
			_workoutPanels.Clear ();
		}

		foreach (ExerciseMenuItem exerciseMenuItem in _gridLayout.GetComponentsInChildren<ExerciseMenuItem>())
		{
			Destroy(exerciseMenuItem.gameObject);
			_exerciseMenuItems.Clear ();
		}
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	void Exit()
	{
		_container.SetActive (false);
	}

	void HandleSkipPressed()
	{
		Exit ();
	}

	void HandleChoosePlanPressed()
	{
		ShowWorkoutsForPlan (_currentPlanData);
		foreach (WorkoutPanel workoutPanel in _workoutPanels) 
		{
			workoutPanel.AddWorkoutFromPlanPanel ();
		}

		Exit ();
	}

	void HandleBackPressed()
	{
		if (_currentMode == PlanPanelViewMode.ShowingWorkouts) 
		{
			ShowPlans ();
		}
		else if (_currentMode == PlanPanelViewMode.ShowingExercises) 
		{
			ShowWorkoutsForPlan (_currentPlanData);
		}
	}

	public void UpdateTopTitle(string newTopTitle)
	{
		_topTitle.text = newTopTitle;
	}
}
