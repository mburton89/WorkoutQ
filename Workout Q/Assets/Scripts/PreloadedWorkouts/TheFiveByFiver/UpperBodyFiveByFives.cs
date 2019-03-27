using System.Collections.Generic;
using UnityEngine;

public class UpperBodyFiveByFives : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Upper Body 5x5";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData benchPressWarmup = new ExerciseData();
        benchPressWarmup.Init("Bench Press Warmup", 75, 3, 10, 45, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPressWarmup);

        ExerciseData benchPress = new ExerciseData();
        benchPress.Init("Bench Press", 140, 5, 5, 135, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPress);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 140, 5, 5, 135, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData militaryPress = new ExerciseData();
		militaryPress.Init("Military Press", 140, 5, 5, 135, ExerciseType.militaryPress);
        workoutData.exerciseData.Add(militaryPress);

        return workoutData;
    }
}
