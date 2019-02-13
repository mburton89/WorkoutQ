using System.Collections.Generic;
using UnityEngine;

public class HomeGymIntermediateLegs : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    void Awake()
    {
        workoutData.name = "Home Gym - Intermediate - Legs & Core";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData squatJumps = new ExerciseData();
        squatJumps.Init("Squat Jumps", 75, 3, 10, 0, ExerciseType.squats); //TODO Update Animation
        workoutData.exerciseData.Add(squatJumps);

        ExerciseData dbSquats = new ExerciseData();
        dbSquats.Init("Dumbell Squats", 90, 3, 8, 50, ExerciseType.squats); //TODO Update Animation... maybe
        workoutData.exerciseData.Add(dbSquats);

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 75, 3, 10, 10, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 20, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData obliqueSideRaisesLeft = new ExerciseData();
        obliqueSideRaisesLeft.Init("Oblique Side Raises - Left Side", 60, 3, 10, 10, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(obliqueSideRaisesLeft);

        ExerciseData obliqueSideRaisesRight = new ExerciseData();
        obliqueSideRaisesRight.Init("Oblique Side Raises - Right Side", 60, 3, 10, 10, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(obliqueSideRaisesRight);

        workoutData.exerciseData.Add(cardio);
        workoutData.exerciseData.Add(squatJumps);
        workoutData.exerciseData.Add(dbSquats);
        workoutData.exerciseData.Add(lunges);
        workoutData.exerciseData.Add(calfRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesLeft);
        workoutData.exerciseData.Add(obliqueSideRaisesRight);
    }
}
