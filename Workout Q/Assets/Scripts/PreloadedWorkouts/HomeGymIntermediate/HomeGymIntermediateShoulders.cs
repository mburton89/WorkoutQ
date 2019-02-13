using System.Collections.Generic;
using UnityEngine;

public class HomeGymIntermediateShoulders : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    void Awake()
    {
        workoutData.name = "Home Gym - Intermediate - Shoulders";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData dbShoulderPress = new ExerciseData();
        dbShoulderPress.Init("DB Shoulder Press", 90, 3, 8, 50, ExerciseType.db_shoulder_press);
        workoutData.exerciseData.Add(dbShoulderPress);

        ExerciseData uprightRows = new ExerciseData();
        uprightRows.Init("Upright Rows", 90, 3, 10, 30, ExerciseType._custom); //TODO Update Animation
        workoutData.exerciseData.Add(uprightRows);

        ExerciseData shrugs = new ExerciseData();
        shrugs.Init("Shrugs", 75, 3, 10, 10, ExerciseType.shrugs);
        workoutData.exerciseData.Add(shrugs);

        ExerciseData frontRaises = new ExerciseData();
        frontRaises.Init("Front Raises", 75, 3, 10, 20, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(frontRaises);

        ExerciseData sideRaises = new ExerciseData();
        sideRaises.Init("Side Raises", 75, 3, 10, 10, ExerciseType.db_side_raises);
        workoutData.exerciseData.Add(sideRaises);

        ExerciseData reverseFlies = new ExerciseData();
        reverseFlies.Init("Reverse Flies", 75, 3, 10, 10, ExerciseType.db_side_raises);
        workoutData.exerciseData.Add(reverseFlies);

        workoutData.exerciseData.Add(cardio);
        workoutData.exerciseData.Add(dbShoulderPress);
        workoutData.exerciseData.Add(uprightRows);
        workoutData.exerciseData.Add(shrugs);
        workoutData.exerciseData.Add(frontRaises);
        workoutData.exerciseData.Add(sideRaises);
        workoutData.exerciseData.Add(reverseFlies);
    }
}
