using System.Collections.Generic;
using UnityEngine;

public class GymAdvancedChestTriceps : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.benchRack;

        workoutData.name = "Advanced Chest & Triceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData pushups = new ExerciseData();
        pushups.Init("Pushups", 60, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add(pushups);

        ExerciseData benchPressWarmup = new ExerciseData();
        benchPressWarmup.Init("Bench Press Warmup", 75, 3, 10, 45, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPressWarmup);

        ExerciseData benchPress = new ExerciseData();
        benchPress.Init("Bench Press", 90, 5, 5, 135, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPress);

        ExerciseData inclineBench = new ExerciseData();
        inclineBench.Init("DB Incline Bench Press", 90, 3, 8, 45, ExerciseType.inclineBench);
        workoutData.exerciseData.Add(inclineBench);

        ExerciseData dips = new ExerciseData();
        dips.Init("Dips", 90, 3, 10, 0, ExerciseType.dips);
        workoutData.exerciseData.Add(dips);

        ExerciseData flies = new ExerciseData();
        flies.Init("Flies", 75, 3, 10, 20, ExerciseType.benchPress); //TODO Update Animation... maybe
        workoutData.exerciseData.Add(flies);

        ExerciseData overheadTricepExtensions = new ExerciseData();
		overheadTricepExtensions.Init("Overhead Tricep Extensions", 75, 3, 10, 20, ExerciseType.overheadTricepExtensions);
        workoutData.exerciseData.Add(overheadTricepExtensions);

        ExerciseData abWheel = new ExerciseData();
        abWheel.Init("Ab Wheel", 60, 3, 5, 0, ExerciseType.abWheel);
        workoutData.exerciseData.Add(abWheel);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
