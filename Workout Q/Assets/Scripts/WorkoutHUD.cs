using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkoutHUD : MonoBehaviour {

	public TextMeshProUGUI ActiveWorkoutText;
	public TextMeshProUGUI ActiveExcersizeText;
	public TextMeshProUGUI SecondsToCompleteText;
	public TextMeshProUGUI SetsText;
	public TextMeshProUGUI RepsText;
	public TextMeshProUGUI WeightText;

	public GridLayoutGroup workoutPanelsGridLayoutGroup;
	public GridLayoutGroup exercisePanelsGridLayoutGroup;

	[SerializeField]private WorkoutPanel WorkoutPanelPrefab;
	[SerializeField]private ExercisePanel ExercisePanelPrefab;

	void Start(){
		foreach(Workout workout in WorkoutManager.Instance.Workouts){
			WorkoutPanel newWorkoutPanel = Instantiate(WorkoutPanelPrefab);
			newWorkoutPanel.workout = workout;
			newWorkoutPanel.UpdateText();

			newWorkoutPanel.transform.SetParent(workoutPanelsGridLayoutGroup.transform);
			newWorkoutPanel.transform.localScale = Vector3.one;
		}
	}

	public void UpdateText(Exercise exercise){
		ActiveExcersizeText.text = exercise.name;
		SecondsToCompleteText.text = exercise.secondsToCompleteSet.ToString();
		SetsText.text = exercise.totalSets.ToString();
		RepsText.text = exercise.repsPerSet.ToString();
		WeightText.text = exercise.weight.ToString();
	}

	public void ShowWorkoutsMenu(){
		workoutPanelsGridLayoutGroup.gameObject.SetActive(true);
		exercisePanelsGridLayoutGroup.gameObject.SetActive(false);
	}

	public void ShowExercisesForWorkout(Workout workoutToOpen){

		Header.Instance.SetUpForExercisesMenu();

		workoutPanelsGridLayoutGroup.gameObject.SetActive(false);
		exercisePanelsGridLayoutGroup.gameObject.SetActive(true);

		foreach(Exercise exercise in WorkoutManager.Instance.ActiveWorkout.Exercises){
			ExercisePanel newExercisePanel = Instantiate(ExercisePanelPrefab);
			newExercisePanel.exerciseName.text = exercise.name;
			newExercisePanel.timeNumberCircle.UpdateValue(exercise.secondsToCompleteSet);
			newExercisePanel.setsNumberCircle.UpdateValue(exercise.totalSets);
			newExercisePanel.repsNumberCircle.UpdateValue( exercise.repsPerSet);
			newExercisePanel.weightNumberCircle.UpdateValue(exercise.weight);

			newExercisePanel.transform.SetParent(exercisePanelsGridLayoutGroup.transform);
			newExercisePanel.transform.localScale = Vector3.one;
		}
	}
}
