using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlanDifficulty
{
	easy,
	medium,
	hard
}

[System.Serializable]
public class PlanData {

	public PlanDifficulty planDifficulty;

	public string name;
	public string description;
	public List<WorkoutData> workoutData;

	public bool usesWeights;
	public string levelLabel;

	public int workoutsPerWeek()
	{
		return workoutData.Count;
	}
}
