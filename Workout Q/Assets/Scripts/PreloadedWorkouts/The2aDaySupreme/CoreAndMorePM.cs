using System.Collections.Generic;
using UnityEngine;

public class CoreAndMorePM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "CoreAndMore - PM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 60, 4, 25, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks); ;

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

        return workoutData;

    }
}
