﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIntermediatePlan : MonoBehaviour {

	public PlanData planData;
	public HomeGymIntermediateChestTriceps homeGymIntermediateChestTriceps;
	public HomeGymIntermediateBackBiceps homeGymIntermediateBackBiceps;
	public HomeGymIntermediateLegs homeGymIntermediateLegs;
	public HomeGymIntermediateShoulders homeGymIntermediateShoulders;

	void Awake()
	{
		planData.name = "Intermediate";
		planData.workoutData.Add (WorkoutData.Copy(homeGymIntermediateChestTriceps.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(homeGymIntermediateBackBiceps.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(homeGymIntermediateLegs.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(homeGymIntermediateShoulders.GetWorkoutData()));
	}
}
