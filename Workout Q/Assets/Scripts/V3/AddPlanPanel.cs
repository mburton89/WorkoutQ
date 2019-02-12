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
	[SerializeField] private ShadowTextButton _skipButton;
	[SerializeField] private ShadowTextButton _choosePlanButton;
	[SerializeField] private ShadowButton _backButton;
	[SerializeField] private PlanMenuItem _addPlanItemPrefab;
	[SerializeField] private WorkoutPanel _addWorkoutItemPrefab;
	[SerializeField] private GridLayoutGroup _gridLayout;

	private List<PlanMenuItem> _planPanels = new List<PlanMenuItem>();
	private List<WorkoutPanel> _workoutPanels = new List<WorkoutPanel>();

	private const string TITLE_TEXT = "Choose a plan";
	private const string CHOOSE_PLAN_INFO = "Or tap 'SKIP' to plug in your own workouts and exercises.";
	private const string VIEWING_EXERCISES_INFO = "";

	void Awake()
	{
		Instance = this;
	}

	void OnEnable()
	{
		_skipButton.onShortClick.AddListener (HandleSkipPressed);
		_choosePlanButton.onShortClick.AddListener (HandleChoosePlanPressed);
		_backButton.onShortClick.AddListener (ShowPlans);
	}

	void OnDisable()
	{
		_skipButton.onShortClick.RemoveListener (HandleSkipPressed);
		_choosePlanButton.onShortClick.RemoveListener (HandleChoosePlanPressed);
		_backButton.onShortClick.RemoveListener (ShowPlans);
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

		_topTitle.gameObject.SetActive (false);
		_bottomTitle.text = TITLE_TEXT;
		_textBody.text = CHOOSE_PLAN_INFO;
		_skipButton.gameObject.SetActive (true);
		_choosePlanButton.gameObject.SetActive (false);
		_backButton.gameObject.SetActive (false);
	}

	public void ShowWorkoutsForPlan(PlanData plan)
	{
		TryClear ();

		foreach (WorkoutData workout in plan.workoutData)
		{
			WorkoutPanel workoutPanel = Instantiate(_addWorkoutItemPrefab);
			workoutPanel.workoutData = workout;
			workoutPanel.UpdateText();
			workoutPanel.UpdateColor();
			workoutPanel.transform.SetParent(_gridLayout.transform);
			workoutPanel.transform.localScale = Vector3.one;
			_workoutPanels.Add (workoutPanel);
		}

		_topTitle.gameObject.SetActive (true);
		_bottomTitle.text = plan.name;
		_textBody.text = VIEWING_EXERCISES_INFO;
		_skipButton.gameObject.SetActive (false);
		_choosePlanButton.gameObject.SetActive (true);	
		_backButton.gameObject.SetActive (true);
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
		foreach (WorkoutPanel workoutPanel in _workoutPanels) 
		{
			workoutPanel.HandleSelfClickedOnAddMenu ();
		}

		Exit ();
	}
}
