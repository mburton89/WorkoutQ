using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Header : MonoBehaviour {

	public static Header Instance;

	[SerializeField]private Button SettingsButton;
	[SerializeField]private Button BackButton;
	[SerializeField]private TextMeshProUGUI _topLabel;
	//[SerializeField]private TextMeshProUGUI _middleLabel;

	[SerializeField] private TMP_InputField _middleLabel;

	public LineSegmenter lineSegmenter;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
		_middleLabel.text = PlayerPrefs.GetString("userTitle");
	}

	void OnEnable(){
		BackButton.onClick.AddListener(HandleBackPressed);
		SettingsButton.onClick.AddListener(HandleSettingsPressed);
		_middleLabel.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable(){
		BackButton.onClick.RemoveListener(HandleBackPressed);
		SettingsButton.onClick.RemoveListener(HandleSettingsPressed);
		_middleLabel.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	public void HandleBackPressed()
	{
		if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
		{
			SettingsButton.gameObject.SetActive(true);
			BackButton.gameObject.SetActive(false);
			WorkoutManager.Instance.workoutHUD.ShowWorkoutsMenu();
			Footer.Instance.Hide();
			_middleLabel.text = PlayerPrefs.GetString("userTitle");
			lineSegmenter.Clear ();
			SettingsButton.gameObject.SetActive (true);
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

		SoundManager.Instance.PlayButtonPressSound ();
	}

	void HandleSettingsPressed()
	{
		SceneManager.LoadScene (1);	
	}

	public void SetUpForExercisesMenu(WorkoutData workoutData){
		SettingsButton.gameObject.SetActive(false);
		BackButton.gameObject.SetActive(true);

		if (string.IsNullOrEmpty (workoutData.name)) {
			UpdateMiddleLabel ("Enter workout name");
		} else {
			_middleLabel.text = workoutData.name;
		}

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
