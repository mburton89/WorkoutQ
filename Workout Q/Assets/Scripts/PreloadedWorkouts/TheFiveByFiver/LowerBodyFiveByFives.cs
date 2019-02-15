using System.Collections.Generic;
using UnityEngine;

public class LowerBodyFiveByFives : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Lower Body 5x5";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData squatsWarmup = new ExerciseData();
        squatsWarmup.Init("Sqauts Warmup", 75, 3, 10, 45, ExerciseType.squats);
        workoutData.exerciseData.Add(squatsWarmup);

        ExerciseData squats = new ExerciseData();
        squats.Init("Dumbell Squats", 140, 5, 5, 135, ExerciseType.squats);
        workoutData.exerciseData.Add(squats);

        ExerciseData deadlift = new ExerciseData();
        deadlift.Init("Deadlift", 140, 5, 5, 135, ExerciseType.deadlifts);
        workoutData.exerciseData.Add(deadlift);

        return workoutData;
    }
}
