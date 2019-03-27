using System.Collections.Generic;
using UnityEngine;

public class BackBicepPM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Back & Biceps - PM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 60, 4, 25, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks);

        ExerciseData chinUps = new ExerciseData();
        chinUps.Init("Chin Ups", 90, 5, 5, 0, ExerciseType.pullUps);
        workoutData.exerciseData.Add(chinUps);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 0, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

        ExerciseData reverseCurls = new ExerciseData();
        reverseCurls.Init("Reverse Curls", 75, 3, 10, 0, ExerciseType.reverseCurls);
        workoutData.exerciseData.Add(reverseCurls);

        return workoutData;

    }
}
