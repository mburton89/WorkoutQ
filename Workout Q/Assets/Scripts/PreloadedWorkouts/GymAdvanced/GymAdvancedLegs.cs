using System.Collections.Generic;
using UnityEngine;

public class GymAdvancedLegs : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.squatRack;

        workoutData.name = "Advanced Legs";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData boxJumps = new ExerciseData();
        boxJumps.Init("Box Jumps", 60, 3, 10, 0, ExerciseType.boxJumps); 
        workoutData.exerciseData.Add(boxJumps);

        ExerciseData squatJumps = new ExerciseData();
		squatJumps.Init("Squat Jumps", 60, 3, 10, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(squatJumps);

        ExerciseData squats = new ExerciseData();
        squats.Init("Dumbell Squats", 120, 5, 5, 135, ExerciseType.squats);
        workoutData.exerciseData.Add(squats);

        ExerciseData deadlift = new ExerciseData();
        deadlift.Init("Deadlift", 120, 3, 8, 135, ExerciseType.deadlifts);
        workoutData.exerciseData.Add(deadlift);

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 75, 3, 10, 20, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 40, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData obliqueSideRaisesLeft = new ExerciseData();
		obliqueSideRaisesLeft.Init("Oblique Side Raises - Left Side", 60, 3, 10, 15, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesLeft);

        ExerciseData obliqueSideRaisesRight = new ExerciseData();
		obliqueSideRaisesRight.Init("Oblique Side Raises - Right Side", 60, 3, 10, 15, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesRight);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
