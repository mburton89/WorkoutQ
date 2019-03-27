using System.Collections.Generic;
using UnityEngine;

public class ChestTricepPM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Chest & Triceps - PM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 60, 4, 25, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData pushups = new ExerciseData();
        pushups.Init("Pushups", 60, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add(pushups);

        ExerciseData dips = new ExerciseData();
        dips.Init("Dips", 90, 4, 5, 0, ExerciseType.dips);
        workoutData.exerciseData.Add(dips);

        ExerciseData palmOutFrontRaises = new ExerciseData();
        palmOutFrontRaises.Init("Palm-Out Front Raises", 75, 3, 10, 0, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(palmOutFrontRaises);

        ExerciseData overheadTricepExtensions = new ExerciseData();
		overheadTricepExtensions.Init("Overhead Tricep Extensions", 75, 3, 10, 0, ExerciseType.overheadTricepExtensions);
        workoutData.exerciseData.Add(overheadTricepExtensions);

        ExerciseData tricepKickBacks = new ExerciseData();
        tricepKickBacks.Init("Tricep Kick-backs", 90, 3, 10, 0, ExerciseType.tricepKickBack); 
        workoutData.exerciseData.Add(tricepKickBacks);

        ExerciseData abWheel = new ExerciseData();
        abWheel.Init("Ab Wheel", 75, 3, 5, 0, ExerciseType.abWheel);
        workoutData.exerciseData.Add(abWheel);

        return workoutData;
    }
}
