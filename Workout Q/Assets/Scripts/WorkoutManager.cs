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
	public WorkoutData ActiveWorkout;
	public WorkoutHUD workoutHUD;
	public Button SaveButton;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}

		Load();
	}

	void OnEnable(){
		SaveButton.onClick.AddListener(Save);
	}

	void OnDisable(){
		SaveButton.onClick.RemoveListener(Save);
	}

	public void Save(){

		workoutData.Clear();

		foreach(WorkoutPanel panel in workoutHUD.workoutPanelsGridLayoutGroup.GetComponentsInChildren<WorkoutPanel>())
		{
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

			workoutData = data.workoutData;

			print("Opened from: " + file);
		}
	}
}

[System.Serializable]
class UserData{
	public List<WorkoutData> workoutData;
}
