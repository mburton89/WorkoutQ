using System.Collections.Generic;
using UnityEngine;

public class HomeGymIntermediateChestTriceps : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    void Awake()
    {
        workoutData.name = "Home Gym - Intermediate - Chest & Triceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData pushups = new ExerciseData();
        pushups.Init("Pushups", 75, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add(pushups);

        ExerciseData dbBenchPress = new ExerciseData();
        dbBenchPress.Init("Dumbell Bench Press", 90, 3, 8, 50, ExerciseType.benchPress);
        workoutData.exerciseData.Add(dbBenchPress);

        ExerciseData chairDips = new ExerciseData();
        chairDips.Init("Chair Dips", 75, 3, 10, 0, ExerciseType.dips); //TODO Update Animation
        workoutData.exerciseData.Add(chairDips);

        ExerciseData flies = new ExerciseData();
        flies.Init("Flies", 75, 3, 10, 20, ExerciseType.benchPress); //TODO Update Animation... maybe
        workoutData.exerciseData.Add(flies);

        ExerciseData overheadTricepExtensions = new ExerciseData();
        overheadTricepExtensions.Init("Overhead Tricep Extensions", 75, 3, 10, 20, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(overheadTricepExtensions);

        ExerciseData crunches = new ExerciseData();
        crunches.Init("Crunches", 60, 3, 10, 0, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(crunches);

        workoutData.exerciseData.Add(cardio);
        workoutData.exerciseData.Add(pushups);
        workoutData.exerciseData.Add(dbBenchPress);
        workoutData.exerciseData.Add(chairDips);
        workoutData.exerciseData.Add(flies);
        workoutData.exerciseData.Add(overheadTricepExtensions);
        workoutData.exerciseData.Add(crunches);
    }
}
