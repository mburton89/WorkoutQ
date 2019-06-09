using System.Collections.Generic;
using UnityEngine;

public class HomeGymIntermediateLegs : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType._singleDumbell;

        workoutData.name = "Intermediate Legs & Core";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData squatJumps = new ExerciseData();
		squatJumps.Init("Squat Jumps", 75, 3, 10, 0, ExerciseType.squatJumps);
		workoutData.exerciseData.Add(squatJumps);

        ExerciseData dbSquats = new ExerciseData();
		dbSquats.Init("Dumbell Squats", 90, 3, 8, 50, ExerciseType.squats);
        workoutData.exerciseData.Add(dbSquats);

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 75, 3, 10, 10, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 20, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData obliqueSideRaisesLeft = new ExerciseData();
		obliqueSideRaisesLeft.Init("Oblique Side Raises - Left Side", 60, 3, 10, 10, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesLeft);

        ExerciseData obliqueSideRaisesRight = new ExerciseData();
		obliqueSideRaisesRight.Init("Oblique Side Raises - Right Side", 60, 3, 10, 10, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesRight);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
	}
}
