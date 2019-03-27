using System.Collections.Generic;
using UnityEngine;

public class LegsAM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Legs - AM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData boxJumps = new ExerciseData();
        boxJumps.Init("Box Jumps", 60, 3, 10, 0, ExerciseType.boxJumps);
        workoutData.exerciseData.Add(boxJumps);

        ExerciseData squatJumps = new ExerciseData();
		squatJumps.Init("Squat Jumps", 60, 3, 10, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(squatJumps);

        ExerciseData squats = new ExerciseData();
        squats.Init("Squats", 120, 5, 5, 0, ExerciseType.squats);
        workoutData.exerciseData.Add(squats);

        ExerciseData deadlift = new ExerciseData();
        deadlift.Init("Deadlift", 120, 3, 8, 135, ExerciseType.deadlifts);
        workoutData.exerciseData.Add(deadlift);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 40, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        return workoutData;
    }
}
