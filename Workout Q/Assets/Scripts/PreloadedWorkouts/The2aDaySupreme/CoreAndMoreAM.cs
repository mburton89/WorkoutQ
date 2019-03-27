using System.Collections.Generic;
using UnityEngine;

public class CoreAndMoreAM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "CoreAndMore - AM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData squatJumps = new ExerciseData();
        squatJumps.Init("Squat Jumps", 75, 3, 10, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(squatJumps);

        ExerciseData cleansWarmup = new ExerciseData();
        cleansWarmup.Init("Cleans Warmup", 60, 3, 10, 0, ExerciseType.cleans);
        workoutData.exerciseData.Add(cleansWarmup);

        ExerciseData cleans = new ExerciseData();
        cleans.Init("Cleans", 90, 5, 5, 0, ExerciseType.cleans);
        workoutData.exerciseData.Add(cleans);
      
        ExerciseData deadlift = new ExerciseData();
        deadlift.Init("Cleans", 90, 5, 5, 0, ExerciseType.deadlifts);
        workoutData.exerciseData.Add(deadlift);

        return workoutData;

    }
}
