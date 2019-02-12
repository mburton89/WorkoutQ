using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanData {

	public string name;
	public List<WorkoutData> workoutData;

	public bool usesWeights;
	public string levelLabel;

	public int workoutsPerWeek()
	{
		return workoutData.Count;
	}
}
