using System.Collections.Generic;
using UnityEngine;

public class ChestTricepAM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Chest & Triceps - AM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData pushups = new ExerciseData();
        pushups.Init("Pushups", 60, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add(pushups);

        ExerciseData benchPressWarmup = new ExerciseData();
        benchPressWarmup.Init("Bench Press Warmup", 75, 3, 10, 0, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPressWarmup);

        ExerciseData benchPress = new ExerciseData();
        benchPress.Init("Bench Press", 120, 5, 5, 0, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPress);

        ExerciseData inclineBench = new ExerciseData();
        inclineBench.Init("DB Incline Bench Press", 90, 3, 8, 0, ExerciseType.inclineBench);
        workoutData.exerciseData.Add(inclineBench);

        return workoutData;
    }
}
