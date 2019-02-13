using System.Collections.Generic;
using UnityEngine;

public class HomeGymIntermediateBackBiceps : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    void Awake()
    {
        workoutData.name = "Home Gym - Intermediate - Back & Biceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 300, 1, 1, 0, ExerciseType.running);
        workoutData.exerciseData.Add(cardio);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 3, 8, 50, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData dbRowsLeft = new ExerciseData();
        dbRowsLeft.Init("Dumbell Rows - Left Arm", 75, 3, 10, 20, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeft);

        ExerciseData dbRowsRight = new ExerciseData();
        dbRowsRight.Init("Dumbell Rows - Right Arm", 75, 3, 10, 20, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRight);

        ExerciseData straightLegDeadlift = new ExerciseData();
        straightLegDeadlift.Init("Straight Leg Deadlift", 90, 3, 10, 50, ExerciseType.deadlifts); //TODO Update Animation... maybe
        workoutData.exerciseData.Add(straightLegDeadlift);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 20, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

        ExerciseData reverseCurls = new ExerciseData();
        reverseCurls.Init("Reverse Curls", 75, 3, 10, 10, ExerciseType.curls); //TODO Update Animation... maybe
        workoutData.exerciseData.Add(reverseCurls);

        workoutData.exerciseData.Add(cardio);
        workoutData.exerciseData.Add(bentOverRows);
        workoutData.exerciseData.Add(dbRowsLeft);
        workoutData.exerciseData.Add(dbRowsRight);
        workoutData.exerciseData.Add(straightLegDeadlift);
        workoutData.exerciseData.Add(curls);
        workoutData.exerciseData.Add(reverseCurls);
    }
}
