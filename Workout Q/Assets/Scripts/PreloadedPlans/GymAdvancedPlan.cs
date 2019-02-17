using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymAdvancedPlan : MonoBehaviour {

	public PlanData planData;
	public GymAdvancedChestTriceps gymAdvancedChestTriceps;
	public GymAdvancedBackBiceps gymAdvancedBackBiceps;
	public GymAdvancedLegs gymAdvancedLegs;
	public GymAdvancedShoulders gymAdvancedShoulders;
	public GymAdvancedCoreAndMore gymAdvancedCoreAndMore;

	void Awake()
	{
		planData.planDifficulty = PlanDifficulty.hard;
		planData.name = "Advanced";
		planData.description = "Dumbells, Bench, Pull-Up Bar, Dips Bar, Barbell required";
		planData.workoutData.Add (WorkoutData.Copy(gymAdvancedChestTriceps.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(gymAdvancedBackBiceps.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(gymAdvancedLegs.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(gymAdvancedShoulders.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(gymAdvancedCoreAndMore.GetWorkoutData()));
	}
}
