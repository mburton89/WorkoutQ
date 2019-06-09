using System.Collections.Generic;
using UnityEngine;

public class HomeGymBeginnerPush : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
    {
		workoutData.workoutType = WorkoutType._singleDumbell;

        workoutData.name = "Beginner Push Workout";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 75, 3, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData modifiedPushups = new ExerciseData();
		modifiedPushups.Init("Modified Pushups", 90, 3, 10, 0, ExerciseType.modifiedPushups);
        workoutData.exerciseData.Add(modifiedPushups);

        ExerciseData shoulderPress = new ExerciseData();
        shoulderPress.Init("Dumbbell Shoulder Press", 90, 3, 10, 0, ExerciseType.db_shoulder_press);
        workoutData.exerciseData.Add(shoulderPress);

        ExerciseData chairDips = new ExerciseData();
		chairDips.Init("Chair Dips", 90, 3, 10, 0, ExerciseType.chairDips); 
        workoutData.exerciseData.Add(chairDips);

        ExerciseData frontRaises = new ExerciseData();
        frontRaises.Init("DB Front Raises", 75, 3, 10, 0, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(frontRaises);

        ExerciseData overheadTricepExtensions = new ExerciseData();
		overheadTricepExtensions.Init("Overhead Tricep Extensions", 75, 3, 10, 0, ExerciseType.overheadTricepExtensions); 
        workoutData.exerciseData.Add(overheadTricepExtensions);

        ExerciseData crunches = new ExerciseData();
		crunches.Init("Crunches", 75, 3, 10, 0, ExerciseType.crunches); 
        workoutData.exerciseData.Add(crunches);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
