using System.Collections.Generic;
using UnityEngine;

public class HomeGymBeginnerPush : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    void Awake()
    {
        workoutData.name = "Home Gym - Beginner - Push";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 75, 3, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData modifiedPushups = new ExerciseData();
        modifiedPushups.Init("Pushups", 90, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add(modifiedPushups);

        ExerciseData shoulderPress = new ExerciseData();
        shoulderPress.Init("Dumbbell Shoulder Press", 90, 3, 10, 5, ExerciseType.db_shoulder_press);
        workoutData.exerciseData.Add(shoulderPress);

        ExerciseData chairDips = new ExerciseData();
        chairDips.Init("Chair Dips", 90, 3, 10, 0, ExerciseType.dips); //TODO Update Animation
        workoutData.exerciseData.Add(chairDips);

        ExerciseData frontRaises = new ExerciseData();
        frontRaises.Init("Left Side Planks - 15sec", 75, 3, 10, 5, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(frontRaises);

        ExerciseData overheadTricepExtensions = new ExerciseData();
        overheadTricepExtensions.Init("Right Side Planks - 15sec", 75, 3, 10, 5, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(overheadTricepExtensions);

        ExerciseData crunches = new ExerciseData();
        crunches.Init("Pushups", 75, 3, 10, 0, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(crunches);

        workoutData.exerciseData.Add(jumpingJacks);
        workoutData.exerciseData.Add(modifiedPushups);
        workoutData.exerciseData.Add(shoulderPress);
        workoutData.exerciseData.Add(chairDips);
        workoutData.exerciseData.Add(frontRaises);
        workoutData.exerciseData.Add(overheadTricepExtensions);
        workoutData.exerciseData.Add(crunches);
    }
}
