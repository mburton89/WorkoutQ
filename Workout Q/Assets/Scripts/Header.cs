using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Header : MonoBehaviour {

	public static Header Instance;

	[SerializeField] private TMP_InputField _middleLabel;

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}

		_middleLabel.text = PlayerPrefs.GetString("userTitle");
	}

	void OnEnable()
	{
		_middleLabel.onSubmit.AddListener(delegate{HandleTitleChanged();});
	}

	void OnDisable()
	{
		_middleLabel.onSubmit.RemoveListener(delegate{HandleTitleChanged();});
	}
		
	void HandleSettingsPressed()
	{
		SetupPanel.Instance.Show ();
	}

	public void SetUpForExercisesMenu(WorkoutData workoutData)
	{
		if (string.IsNullOrEmpty (workoutData.name))
		{
			UpdateMiddleLabel ("Enter workout name");
		}
		else
		{
			_middleLabel.text = workoutData.name;
		}
	}

	public void UpdateMiddleLabel(string newTitle)
	{
		_middleLabel.text = newTitle;
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

	void HandleEditPressed()
	{
		if (WorkoutHUD.Instance.currentMode == Mode.ViewingWorkouts) 
		{
			//TODO Edit Plan bro mama
		}
		else if (WorkoutHUD.Instance.currentMode == Mode.ViewingExercises) 
		{
			EditWorkoutPanel.Instance.Init (WorkoutManager.Instance.ActiveWorkout, false, false);
		}
		else if (WorkoutHUD.Instance.currentMode == Mode.EditingExercise || WorkoutHUD.Instance.currentMode == Mode.PlayingExercise) 
		{
			EditExercisePanel.Instance.Init (WorkoutManager.Instance.ActiveExercise, false, false);
		}
	}
}
