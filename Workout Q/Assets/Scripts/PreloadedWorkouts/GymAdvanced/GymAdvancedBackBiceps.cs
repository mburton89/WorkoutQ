using System.Collections.Generic;
using UnityEngine;

public class GymAdvancedBackBiceps : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
    {
		workoutData.workoutType = WorkoutType.pullupBar;

        workoutData.name = "Advanced Back & Biceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData bentOverRowsWarmup = new ExerciseData();
        bentOverRowsWarmup.Init("Bent Over Rows Warmup", 60, 3, 10, 45, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRowsWarmup);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 5, 5, 95, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData chinUps = new ExerciseData();
        chinUps.Init("Chin Ups", 60, 3, 10, 0, ExerciseType.pullUps);
        workoutData.exerciseData.Add(chinUps);

        ExerciseData dbRowsLeft = new ExerciseData();
        dbRowsLeft.Init("Dumbell Rows - Left Arm", 75, 3, 10, 30, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeft);

        ExerciseData dbRowsRight = new ExerciseData();
        dbRowsRight.Init("Dumbell Rows - Right Arm", 75, 3, 10, 30, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRight);

        ExerciseData straightLegDeadlift = new ExerciseData();
		straightLegDeadlift.Init ("Straight Leg Deadlift", 90, 3, 10, 95, ExerciseType.straightLegDeadlift);
        workoutData.exerciseData.Add(straightLegDeadlift);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 30, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

        ExerciseData reverseCurls = new ExerciseData();
		reverseCurls.Init("Reverse Curls", 75, 3, 10, 20, ExerciseType.reverseCurls);
        workoutData.exerciseData.Add(reverseCurls);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
