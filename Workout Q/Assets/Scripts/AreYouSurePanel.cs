using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AreYouSurePanel : MonoBehaviour 
{
    public static AreYouSurePanel Instance;

    [SerializeField] private GameObject _container;
    [SerializeField] private TextMeshProUGUI _body;
    [SerializeField] private ShadowButton _yesButton;
    [SerializeField] private ShadowButton _noButton;
    [SerializeField] private Button _overlay;

    private const string DELETE_PHRASE = "Are you sure you want to delete ";

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

    void OnEnable()
    {
        _yesButton.onShortClick.AddListener(DeleteWorkout);
        _noButton.onShortClick.AddListener(Exit);
        _overlay.onClick.AddListener(Exit);
    }

    void OnDisable()
    {
        _yesButton.onShortClick.RemoveListener(DeleteWorkout);
        _noButton.onShortClick.RemoveListener(Exit);
        _overlay.onClick.RemoveListener(Exit);
    }

    public void Show()
    {
        _body.text = DELETE_PHRASE + WorkoutManager.Instance.workoutHUD.selectedPanel.GetComponent<WorkoutPanel>().workoutData.name + " ?";
        _container.SetActive(true);
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
        PanelMover.Instance.Confirm();
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
