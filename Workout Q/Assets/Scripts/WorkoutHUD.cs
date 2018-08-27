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

	[SerializeField]private Button addButton;

	void OnEnable(){
		addButton.onClick.AddListener(delegate{AddWorkoutPanel(null);});
	}

	void OnDisable(){
		addButton.onClick.RemoveListener(delegate{AddWorkoutPanel(null);});
	}

	void Start(){
		foreach(WorkoutData workout in WorkoutManager.Instance.workoutData){
			AddWorkoutPanel(workout);
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

		foreach(ExercisePanel panel in exercisePanelsGridLayoutGroup.GetComponentsInChildren<ExercisePanel>()){
			Destroy(panel.gameObject);
		}
	}

	public void ShowExercisesForWorkout(WorkoutData workoutToOpen){

		Header.Instance.SetUpForExercisesMenu();

		workoutPanelsGridLayoutGroup.gameObject.SetActive(false);
		exercisePanelsGridLayoutGroup.gameObject.SetActive(true);

		foreach(ExerciseData exercise in workoutToOpen.ExerciseData){
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

	void AddWorkoutPanel(WorkoutData workout){
		WorkoutPanel newWorkoutPanel = Instantiate(WorkoutPanelPrefab);

		if(workout != null){
			newWorkoutPanel.workoutData = workout;
		}

		newWorkoutPanel.UpdateText();

		newWorkoutPanel.transform.SetParent(workoutPanelsGridLayoutGroup.transform);
		newWorkoutPanel.transform.localScale = Vector3.one;
	}
}
