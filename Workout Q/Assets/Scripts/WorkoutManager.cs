using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutManager : MonoBehaviour {

	public static WorkoutManager Instance;

	public List<WorkoutData> workoutData;
	public Workout ActiveWorkout;
	private int _activeExerciseIndex;
	public Exercise ActiveExercise;
	public WorkoutHUD workoutHUD;

	public Button SaveButton;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}

		Load();

//		foreach(Workout workout in GetComponentsInChildren<Workout>()){
//			Workouts.Add(workout);
//		}
	}

	void OnEnable(){
		SaveButton.onClick.AddListener(Save);
	}

	void OnDisable(){
		SaveButton.onClick.RemoveListener(Save);
	}

	void Start(){
		workoutHUD.ActiveWorkoutText.text = ActiveWorkout.name;
		workoutHUD.UpdateText(ActiveExercise); 
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			DecrementSetsRemaining();
		}
	}

	public void DecrementSetsRemaining(){
		ActiveExercise.totalSets --;

		if(ActiveExercise.totalSets == 0 && ActiveWorkout.Exercises.Count > (_activeExerciseIndex + 1)){
			//Handle Index Out of Range. End Workout
			_activeExerciseIndex ++;
			ActiveExercise = ActiveWorkout.Exercises[_activeExerciseIndex];
		}

		workoutHUD.UpdateText(ActiveExercise); 
	}

	public void Save(){

		workoutData.Clear();

		foreach(WorkoutPanel panel in workoutHUD.workoutPanelsGridLayoutGroup.GetComponentsInChildren<WorkoutPanel>()){
			workoutData.Add(panel.workoutData);
		}

		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
	
		UserData userData = new UserData();
		userData.workoutData = workoutData;

		binaryFormatter.Serialize(file, userData);
		file.Close();

		print("Saved to: " + file);
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			UserData data = (UserData)binaryFormatter.Deserialize(file); 
			file.Close();

//			foreach(WorkoutData workout in data.workoutData){
//				workoutData.Add(workout);
//			}

			workoutData = data.workoutData;

			print("Opened from: " + file);
		}
	}
}

[System.Serializable]
class UserData{

	public List<WorkoutData> workoutData;

}
