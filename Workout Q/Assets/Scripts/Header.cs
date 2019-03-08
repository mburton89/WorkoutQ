using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Header : MonoBehaviour {

	public static Header Instance;

	[SerializeField]private ShadowButton _settingsButton;
	[SerializeField]private ShadowButton _backButton;
	[SerializeField]private TextMeshProUGUI _topLabel;

	[SerializeField] private TMP_InputField _middleLabel;

	public LineSegmenter lineSegmenter;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
		_middleLabel.text = PlayerPrefs.GetString("userTitle");
	}

	void Start()
	{
		_topLabel.color = ColorManager.Instance.ActiveColorMedium;
	}

	void OnEnable(){
		_backButton.onShortClick.AddListener(HandleBackPressed);
		_settingsButton.onShortClick.AddListener(HandleSettingsPressed);
		_middleLabel.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable(){
		_backButton.onShortClick.RemoveListener(HandleBackPressed);
		_settingsButton.onShortClick.RemoveListener(HandleSettingsPressed);
		_middleLabel.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	public void HandleBackPressed()
	{
		if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
		{
			_settingsButton.gameObject.SetActive(true);
			_backButton.gameObject.SetActive(false);
			WorkoutManager.Instance.workoutHUD.ShowWorkoutsMenu();
			Footer.Instance.Hide();
			_middleLabel.text = PlayerPrefs.GetString("userTitle");
			lineSegmenter.Clear ();
			_settingsButton.gameObject.SetActive (true);
		}
		else if (WorkoutHUD.Instance.currentMode == Mode.EditingExercise || WorkoutHUD.Instance.currentMode == Mode.PlayingExercise) 
		{
			WorkoutManager.Instance.workoutHUD.ShowExercisesForWorkout (WorkoutManager.Instance.ActiveWorkout);
			_middleLabel.text = WorkoutManager.Instance.ActiveWorkout.name;
			PlayModeManager.Instance.Reset();
			Footer.Instance.ResetTimerLine ();
			_topLabel.text = PlayerPrefs.GetString("userTitle");
			Footer.Instance.WorkoutControlsContatiner.editButton.gameObject.SetActive(false);
		}
	}

	void HandleSettingsPressed()
	{
		SetupPanel.Instance.Show ();
	}

	public void SetUpForExercisesMenu(WorkoutData workoutData){
		_settingsButton.gameObject.SetActive(false);
		_backButton.gameObject.SetActive(true);

		if (string.IsNullOrEmpty (workoutData.name)) {
			UpdateMiddleLabel ("Enter workout name");
		} else {
			_middleLabel.text = workoutData.name;
		}

		_topLabel.text = "";

		lineSegmenter.Init(workoutData.exerciseData.Count);
	}

	public void UpdateMiddleLabel(string newTitle){
		_middleLabel.text = newTitle;
	}

	public void UpdateTopLabel(string newTitle){
		_topLabel.text = newTitle;
	}

	void HandleTitleChanged()
	{
		if (WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts) 
		{
			PlayerPrefs.SetString("userTitle", _middleLabel.text);
		}
		else if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
		{
			WorkoutManager.Instance.ActiveWorkout.name = _middleLabel.text;
			WorkoutManager.Instance.Save();
		}
		else if (WorkoutHUD.Instance.currentMode == Mode.EditingExercise) 
		{
			WorkoutManager.Instance.ActiveExercise.name = _middleLabel.text;
			WorkoutManager.Instance.Save();
		}
	}
}
