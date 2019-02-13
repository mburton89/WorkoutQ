using System.Collections.Generic;
using UnityEngine;

public class HomeGymBeginnerPull : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    void Awake()
    {
        workoutData.name = "Home Gym - Beginner - Push";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 75, 3, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 3, 10, 5, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData dbRowsLeftArm = new ExerciseData();
        dbRowsLeftArm.Init("Dumbbell Rows Left Arm", 75, 3, 10, 5, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeftArm);

        ExerciseData dbRowsRightArm = new ExerciseData();
        dbRowsRightArm.Init("Dumbbell Rows Right Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRightArm);

        ExerciseData shrugs = new ExerciseData();
        shrugs.Init("Shrugs", 75, 3, 10, 0, ExerciseType.shrugs);
        workoutData.exerciseData.Add(shrugs);

        ExerciseData dbToeTouches = new ExerciseData();
        dbToeTouches.Init("DB Toe Touches", 75, 3, 10, 0, ExerciseType.deadlifts); //TODO Update Animation
        workoutData.exerciseData.Add(dbToeTouches);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 0, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

        workoutData.exerciseData.Add(jumpingJacks);
        workoutData.exerciseData.Add(bentOverRows);
        workoutData.exerciseData.Add(dbRowsLeftArm);
        workoutData.exerciseData.Add(dbRowsRightArm);
        workoutData.exerciseData.Add(shrugs);
        workoutData.exerciseData.Add(dbToeTouches);
        workoutData.exerciseData.Add(curls);
    }
}
