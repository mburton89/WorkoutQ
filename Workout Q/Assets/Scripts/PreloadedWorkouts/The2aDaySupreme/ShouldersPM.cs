using System.Collections.Generic;
using UnityEngine;

public class ShouldersPM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Shoulders - AM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 60, 4, 25, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks); ;

        ExerciseData dbShoulderPressWarmup = new ExerciseData();
        dbShoulderPressWarmup.Init("DB Shoulder Press Warmup", 60, 3, 10, 0, ExerciseType.db_shoulder_press); 
        workoutData.exerciseData.Add(dbShoulderPressWarmup);

        ExerciseData dbShoulderPress = new ExerciseData();
        dbShoulderPress.Init("DB Shoulder Press", 90, 3, 8, 0, ExerciseType.db_shoulder_press);
        workoutData.exerciseData.Add(dbShoulderPress);

        ExerciseData frontRaises = new ExerciseData();
        frontRaises.Init("Front Raises", 75, 3, 10, 0, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(frontRaises);

        ExerciseData sideRaises = new ExerciseData();
        sideRaises.Init("Side Raises", 75, 3, 10, 0, ExerciseType.db_side_raises);
        workoutData.exerciseData.Add(sideRaises);

        ExerciseData reverseFlies = new ExerciseData();
        reverseFlies.Init("Reverse Flies", 75, 3, 10, 0, ExerciseType.db_side_raises);
        workoutData.exerciseData.Add(reverseFlies);

        return workoutData;

    }
}
