using System.Collections.Generic;
using UnityEngine;

public class GymAdvancedCoreAndMore : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType._singleDumbell;

        workoutData.name = "Advanced Core & More";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData squatJumps = new ExerciseData();
		squatJumps.Init("Squat Jumps", 75, 3, 10, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(squatJumps);

        ExerciseData cleansWarmup = new ExerciseData();
		cleansWarmup.Init("Cleans Warmup", 60, 3, 10, 45, ExerciseType.cleans);
        workoutData.exerciseData.Add(cleansWarmup);

        ExerciseData cleans = new ExerciseData();
        cleans.Init("Cleans", 90, 5, 5, 95, ExerciseType.cleans);
        workoutData.exerciseData.Add(cleans);
      
        ExerciseData deadlift = new ExerciseData();
        deadlift.Init("Deadlifts", 90, 5, 5, 135, ExerciseType.deadlifts);
        workoutData.exerciseData.Add(deadlift);

        ExerciseData frontPlanks = new ExerciseData();
        frontPlanks.Init("Front Planks - 30 sec", 60, 3, 1, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add(frontPlanks);

        ExerciseData leftSidePlanks = new ExerciseData();
		leftSidePlanks.Init("Left Side Planks - 30 sec", 60, 3, 1, 0, ExerciseType.planksSide);
        workoutData.exerciseData.Add(leftSidePlanks);

        ExerciseData rightSidePlanks = new ExerciseData();
		rightSidePlanks.Init("Right Side Planks - 30 sec", 60, 3, 1, 0, ExerciseType.planksSide);
        workoutData.exerciseData.Add(rightSidePlanks);

        ExerciseData backPlanks = new ExerciseData();
		backPlanks.Init("Back Planks - 30 sec", 60, 3, 1, 0, ExerciseType.planksBack);
        workoutData.exerciseData.Add(backPlanks);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
