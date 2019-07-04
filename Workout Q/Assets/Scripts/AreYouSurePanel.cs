using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AreYouSurePanel : MonoBehaviour 
{
    public static AreYouSurePanel Instance;

    [SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI _title;
	[SerializeField] private TextMeshProUGUI _body;
    [SerializeField] private ShadowButton _yesButton;
    [SerializeField] private ShadowButton _noButton;
    [SerializeField] private Button _overlay;

	private const string DELETE_PHRASE = "Are you sure you want to delete ";
	private const string RESET_PHRASE = "End current workout and reset progress?";

    [SerializeField] List<Image> _colorImages;
    //[SerializeField] List<TextMeshProUGUI> _texts;

	enum AreYouSureMode
	{
		deleteWorkout,
		resetWorkout
	}

	private AreYouSureMode _activeMode;

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

		_body.color = ColorManager.Instance.ActiveColorLight;
    }

    void OnEnable()
    {
		_yesButton.onShortClick.AddListener(HandleYesPressed);
        _noButton.onShortClick.AddListener(Exit);
        _overlay.onClick.AddListener(Exit);
    }

    void OnDisable()
    {
		_yesButton.onShortClick.RemoveListener(HandleYesPressed);
        _noButton.onShortClick.RemoveListener(Exit);
        _overlay.onClick.RemoveListener(Exit);
    }

    public void ShowForDelete()
    {
        _body.text = DELETE_PHRASE + WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<WorkoutPanel>().workoutData.name + " ?";
        _container.SetActive(true);
		_title.text = "Delete Workout";
		_activeMode = AreYouSureMode.deleteWorkout;
    }

	public void ShowForReset()
	{
		_body.text = RESET_PHRASE;
		_container.SetActive(true);
		_title.text = "Reset Progress";
		_activeMode = AreYouSureMode.resetWorkout;
	}

	void HandleYesPressed()
	{
		if (_activeMode == AreYouSureMode.deleteWorkout) 
		{
			DeleteWorkout ();
		}
		else if (_activeMode == AreYouSureMode.resetWorkout) 
		{
			WorkoutManager.Instance.ActiveWorkout.Reset ();
			WorkoutHUD.Instance.ShowExercisesForWorkout (WorkoutManager.Instance.ActiveWorkout);
			WorkoutManager.Instance.Save ();
			FooterV2.Instance.EstablishPlayOrEndButton ();
			Exit ();
		}
	}

    void DeleteWorkout()
    {
        TrashBin.Instance.ThrowInTrash(WorkoutManager.Instance.workoutHUD.selectedPanel.gameObject.transform);
        SaveExercisePanelOrder();
        WorkoutManager.Instance.Save();
        Exit();
    }

    void Exit()
    {
        _container.SetActive(false);

		if (_activeMode == AreYouSureMode.deleteWorkout) 
		{
			PanelMover.Instance.Confirm();
		}
    }

    void SaveExercisePanelOrder()
    {
        if (WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<ExerciseMenuItem>())
        {
            WorkoutManager.Instance.ActiveWorkout.exerciseData.Clear();
            print("SaveExercisePanelOrder");
            foreach (ExerciseMenuItem panel in WorkoutManager.Instance.workoutHUD.exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExerciseMenuItem>())
            {
                WorkoutManager.Instance.ActiveWorkout.exerciseData.Add(panel.exerciseData);
            }
        }
    }
}
