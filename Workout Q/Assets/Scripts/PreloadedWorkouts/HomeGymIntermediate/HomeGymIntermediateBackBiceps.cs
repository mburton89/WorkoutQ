using System.Collections.Generic;
using UnityEngine;

public class HomeGymIntermediateBackBiceps : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.pullupBar;

        workoutData.name = "Intermediate Back & Biceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 3, 8, 50, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData dbRowsLeft = new ExerciseData();
        dbRowsLeft.Init("Dumbell Rows - Left Arm", 75, 3, 10, 20, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeft);

        ExerciseData dbRowsRight = new ExerciseData();
        dbRowsRight.Init("Dumbell Rows - Right Arm", 75, 3, 10, 20, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRight);

        ExerciseData straightLegDeadlift = new ExerciseData();
		straightLegDeadlift.Init("Straight Leg Deadlift", 90, 3, 10, 50, ExerciseType.straightLegDeadlift);
        workoutData.exerciseData.Add(straightLegDeadlift);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 20, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

        ExerciseData reverseCurls = new ExerciseData();
		reverseCurls.Init("Reverse Curls", 75, 3, 10, 10, ExerciseType.reverseCurls); 
        workoutData.exerciseData.Add(reverseCurls);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
