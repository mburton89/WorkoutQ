using System.Collections.Generic;
using UnityEngine;

public class PilatesBeginnerLowerBodyWorkout : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData(){

		workoutData.workoutType = WorkoutType.noWeights;

		workoutData.name = "Lower Body - No Weights";
        workoutData.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add (jumpingJacks);

		ExerciseData bodySquats = new ExerciseData ();
		bodySquats.Init ("Body Squats", 90, 3, 10, 0, ExerciseType.bodySquats);
        workoutData.exerciseData.Add (bodySquats);

		ExerciseData squatJumps = new ExerciseData ();
		squatJumps.Init ("Squat Jumps", 90, 3, 10, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add (squatJumps);

		ExerciseData lunges = new ExerciseData ();
		lunges.Init ("Lunges", 90, 3, 10, 0, ExerciseType.lunges);
        workoutData.exerciseData.Add (lunges);

		ExerciseData calfRaises = new ExerciseData ();
		calfRaises.Init ("Calf Raises", 90, 3, 10, 0, ExerciseType.calfRaises);
        workoutData.exerciseData.Add (calfRaises);

		workoutData.secondsBetweenExercises = 30;

        return workoutData;
	}
}
