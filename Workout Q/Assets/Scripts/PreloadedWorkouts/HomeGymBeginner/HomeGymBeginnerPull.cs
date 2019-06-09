using System.Collections.Generic;
using UnityEngine;

public class HomeGymBeginnerPull : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.dumbellsOnBench;

        workoutData.name = "Beginner Pull Workout";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 75, 3, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 3, 10, 0, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData dbRowsLeftArm = new ExerciseData();
        dbRowsLeftArm.Init("Dumbbell Rows Left Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeftArm);

        ExerciseData dbRowsRightArm = new ExerciseData();
        dbRowsRightArm.Init("Dumbbell Rows Right Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRightArm);

        ExerciseData shrugs = new ExerciseData();
        shrugs.Init("Shrugs", 75, 3, 10, 0, ExerciseType.shrugs);
        workoutData.exerciseData.Add(shrugs);

        ExerciseData dbToeTouches = new ExerciseData();
		dbToeTouches.Init("DB Toe Touches", 75, 3, 10, 0, ExerciseType.dbToeTouches);
        workoutData.exerciseData.Add(dbToeTouches);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 0, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
