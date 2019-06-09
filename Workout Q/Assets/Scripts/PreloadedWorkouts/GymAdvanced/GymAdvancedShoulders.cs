using System.Collections.Generic;
using UnityEngine;

public class GymAdvancedShoulders : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

	public WorkoutData GetWorkoutData()
	{
		workoutData.workoutType = WorkoutType.doubleDumbell;

        workoutData.name = "Advanced Shoulders";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 480, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData militaryPressWarmup = new ExerciseData();
		militaryPressWarmup.Init("Clean Press Warmup", 60, 3, 10, 45, ExerciseType.militaryPress);
        workoutData.exerciseData.Add(militaryPressWarmup);

        ExerciseData militaryPress = new ExerciseData();
		militaryPress.Init("Clean Press", 90, 5, 5, 95, ExerciseType.militaryPress);
        workoutData.exerciseData.Add(militaryPress);

        ExerciseData dbShoulderPress = new ExerciseData();
        dbShoulderPress.Init("DB Shoulder Press", 90, 3, 8, 50, ExerciseType.db_shoulder_press);
        workoutData.exerciseData.Add(dbShoulderPress);

        ExerciseData uprightRows = new ExerciseData();
		uprightRows.Init("Upright Rows", 90 , 3, 10, 30, ExerciseType.uprightRows);
        workoutData.exerciseData.Add(uprightRows);

        ExerciseData shrugs = new ExerciseData();
        shrugs.Init("Shrugs", 75, 3, 10, 50, ExerciseType.shrugs);
        workoutData.exerciseData.Add(shrugs);

        ExerciseData frontRaises = new ExerciseData();
        frontRaises.Init("Front Raises", 75, 3, 10, 20, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(frontRaises);

        ExerciseData sideRaises = new ExerciseData();
        sideRaises.Init("Side Raises", 75, 3, 10, 10, ExerciseType.db_side_raises);
        workoutData.exerciseData.Add(sideRaises);

        ExerciseData reverseFlies = new ExerciseData();
		reverseFlies.Init("Reverse Flies", 75, 3, 10, 10, ExerciseType.reverseFlies);
        workoutData.exerciseData.Add(reverseFlies);

		workoutData.secondsBetweenExercises = 60;

		return workoutData;
    }
}
