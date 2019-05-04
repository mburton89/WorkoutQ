using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutPlayerTester : MonoBehaviour 
{
	[SerializeField] private WorkoutPlayerController _workoutPlayerController;
	[SerializeField] private WorkoutData _testWorkout;

	void Awake()
	{
		_workoutPlayerController.Init (_testWorkout, 0);
	}

#if UNITY_EDITOR
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_workoutPlayerController.GoToPreviousExercise ();
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			_workoutPlayerController.GoToNextExercise ();
		}
	}
#endif
}
