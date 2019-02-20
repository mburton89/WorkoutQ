using System.Collections.Generic;
using UnityEngine;

public class PilatesBeginnerLowerBodyWorkout : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData(){

        name = "Lower Body Pilates";
        workoutData.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add (jumpingJacks);

		ExerciseData bodySquats = new ExerciseData ();
        bodySquats.Init ("Body Squats", 90, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add (bodySquats);

		ExerciseData squatJumps = new ExerciseData ();
        squatJumps.Init ("Squat Jumps", 90, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (squatJumps);

		ExerciseData lunges = new ExerciseData ();
        lunges.Init ("Lunges", 90, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (lunges);

		ExerciseData calfRaises = new ExerciseData ();
        calfRaises.Init ("Calf Raises", 90, 3, 10, 0, ExerciseType.dips);
        workoutData.exerciseData.Add (calfRaises);

        return workoutData;
	}
}
