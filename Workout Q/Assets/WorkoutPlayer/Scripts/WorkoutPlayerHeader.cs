using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutPlayerHeader : MonoBehaviour {

	private WorkoutPlayerController _controller;

	[SerializeField] private Button _backButton;
	[SerializeField] private Button _editButton;
	[SerializeField] private TextMeshProUGUI _title;

	private int _totalExercises;
	private const string EXERCISE_PREFIX = "EXERCISE ";
	private const string WORKOUT_COMPLETE_TITLE = "WORKOUT COMPLETE!";

	public void Init(WorkoutPlayerController controller, int totalExercises)
	{
		_controller = controller;
		_backButton.GetComponent<Image> ().color = ColorManager.Instance.ActiveColorLight;
		_editButton.GetComponent<Image> ().color = ColorManager.Instance.ActiveColorLight;
		_title.color = ColorManager.Instance.ActiveColorLight;
		_totalExercises = totalExercises;
	}

	void OnEnable()
	{
		_backButton.onClick.AddListener (HandleBackPressed);
		_editButton.onClick.AddListener (HandleEditPressed);
	}

	void OnDisable()
	{
		_backButton.onClick.RemoveListener (HandleBackPressed);
		_editButton.onClick.RemoveListener (HandleEditPressed);
	}

	public void UpdateTitle(int exerciseIndex)
	{	
		int exerciseNumber = exerciseIndex + 1;
		_title.text = EXERCISE_PREFIX + exerciseNumber + " / " + _totalExercises;
	}

	void HandleBackPressed()
	{
		SoundManager.Instance.PlayButtonPressSound ();

		//TODO Get rid of nasty old header. Make newer better cleaner header.
		if (Header.Instance != null) 
		{
			_controller.Exit ();
		}
		else 
		{
			Debug.Log ("No function in test mode");
		}
	}

	void HandleEditPressed()
	{
		SoundManager.Instance.PlayButtonPressSound ();

		if (EditExercisePanel.Instance != null) 
		{
			EditExercisePanel.Instance.Init (WorkoutManager.Instance.ActiveExercise, false, false);
		} 
		else 
		{
			Debug.Log ("No function in test mode");
		}
	}

	public void ShowWorkoutComplete()
	{
		_title.text = WORKOUT_COMPLETE_TITLE;
	}
}
