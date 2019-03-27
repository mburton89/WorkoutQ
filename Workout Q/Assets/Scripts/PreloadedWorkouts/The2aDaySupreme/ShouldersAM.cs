using System.Collections.Generic;
using UnityEngine;

public class ShouldersAM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Shoulders - AM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData cleanPressWarmup = new ExerciseData();
		cleanPressWarmup.Init("Clean Press Warmup", 60, 3, 10, 0, ExerciseType.cleanPress);
        workoutData.exerciseData.Add(cleanPressWarmup);

        ExerciseData cleanPress = new ExerciseData();
		cleanPress.Init("Clean Press", 90, 5, 5, 0, ExerciseType.cleanPress);
        workoutData.exerciseData.Add(cleanPress);

        ExerciseData uprightRows = new ExerciseData();
		uprightRows.Init("Upright Rows", 90 , 3, 10, 0, ExerciseType.uprightRows);
        workoutData.exerciseData.Add(uprightRows);

        ExerciseData shrugs = new ExerciseData();
        shrugs.Init("Shrugs", 75, 3, 10, 0, ExerciseType.shrugs);
        workoutData.exerciseData.Add(shrugs);

        return workoutData;

    }
}
