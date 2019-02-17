using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBeginnerPlan : MonoBehaviour {

	public PlanData planData;
	public HomeGymBeginnerPush homeGymBeginnerPush;
	public HomeGymBeginnerPull homeGymBeginnerPull;
	public HomeGymBeginnerLegs homeGymBeginnerLegs;

	void Awake()
	{
		planData.planDifficulty = PlanDifficulty.easy;
		planData.name = "Beginner";
		planData.description = "Dumbells required.";
		planData.workoutData.Add (WorkoutData.Copy(homeGymBeginnerPush.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(homeGymBeginnerPull.GetWorkoutData()));
		planData.workoutData.Add (WorkoutData.Copy(homeGymBeginnerLegs.GetWorkoutData()));
	}
}
