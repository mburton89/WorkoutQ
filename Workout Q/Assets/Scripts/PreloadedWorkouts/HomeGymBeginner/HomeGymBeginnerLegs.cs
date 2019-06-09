using System.Collections.Generic;
using UnityEngine;

public class HomeGymBeginnerLegs : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.doubleDumbell;

        workoutData.name = "Beginner Legs Workout";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 75, 3, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData bodySquats = new ExerciseData();
		bodySquats.Init("Body Squats", 90, 3, 10, 0, ExerciseType.bodySquats);
        workoutData.exerciseData.Add(bodySquats);

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 90, 3, 10, 0, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData frontPlanks = new ExerciseData();
        frontPlanks.Init("Front Planks - 15 sec", 75, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add(frontPlanks);

        ExerciseData backPlanks = new ExerciseData();
		backPlanks.Init("Back Plank - 15 sec", 75, 3, 10, 0, ExerciseType.planksBack);
        workoutData.exerciseData.Add(backPlanks);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
