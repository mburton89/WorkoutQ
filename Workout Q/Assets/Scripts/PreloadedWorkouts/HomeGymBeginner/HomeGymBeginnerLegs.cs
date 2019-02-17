using System.Collections.Generic;
using UnityEngine;

public class HomeGymBeginnerLegs : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.legsCore;

        workoutData.name = "Beginner Legs Workout";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 75, 3, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData bodySquats = new ExerciseData();
        bodySquats.Init("Body Squats", 90, 3, 10, 0, ExerciseType.squats); //TODO Update Animation
        workoutData.exerciseData.Add(bodySquats);

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 90, 3, 10, 0, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData frontPlanks = new ExerciseData();
        frontPlanks.Init("Front Planks - 15 sec", 75, 3, 10, 0, ExerciseType.planks);
        workoutData.exerciseData.Add(frontPlanks);

        ExerciseData backPlanks = new ExerciseData();
        backPlanks.Init("Back Plank - 15 sec", 75, 3, 10, 0, ExerciseType.planks); //TODO Update Animation
        workoutData.exerciseData.Add(backPlanks);

		return workoutData;
    }
}
