using System.Collections.Generic;
using UnityEngine;

public class BackBicepAM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Back & Bicep - AM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData rowMachine = new ExerciseData();
		rowMachine.Init("Row Machine", 300, 1, 1, 0, ExerciseType.rowMachine);
        workoutData.exerciseData.Add(rowMachine);

        ExerciseData bentOverRowsWarmup = new ExerciseData();
        bentOverRowsWarmup.Init("Bent Over Rows Warmup", 60, 3, 10, 0, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRowsWarmup);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 5, 5, 0, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData straightLegDeadlift = new ExerciseData();
		straightLegDeadlift.Init("Straight Leg Deadlift", 90, 5, 5, 0, ExerciseType.straightLegDeadlift);
        workoutData.exerciseData.Add(straightLegDeadlift);

        ExerciseData dbRowsLeft = new ExerciseData();
        dbRowsLeft.Init("Dumbell Rows - Left Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeft);

        ExerciseData dbRowsRight = new ExerciseData();
        dbRowsRight.Init("Dumbell Rows - Right Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRight);

        return workoutData;
    }
}
