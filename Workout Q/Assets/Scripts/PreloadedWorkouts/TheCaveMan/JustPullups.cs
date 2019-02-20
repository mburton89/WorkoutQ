using System.Collections.Generic;
using UnityEngine;

public class JustPullUps : MonoBehaviour 
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData(){

        name = "Just Pull-Ups";
        workoutData.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add (jumpingJacks);

        ExerciseData chinUps = new ExerciseData ();
		chinUps.Init ("Pushups", 90, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add (chinUps);

        ExerciseData pullUps = new ExerciseData ();
		pullUps.Init ("Front Planks - 15sec", 60, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (pullUps);

        return workoutData;
	}
}
