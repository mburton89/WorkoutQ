using System.Collections.Generic;
using UnityEngine;

public class LegsPM : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.name = "Legs - PM";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData jumpingJacks = new ExerciseData();
        jumpingJacks.Init("Jumping Jacks", 60, 4, 25, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add(jumpingJacks); ;

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 75, 6, 10, 0, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData obliqueSideRaisesLeft = new ExerciseData();
		obliqueSideRaisesLeft.Init("Oblique Side Raises - Left Side", 60, 3, 10, 0, ExerciseType.obliqueSideRaises); 
        workoutData.exerciseData.Add(obliqueSideRaisesLeft);

        ExerciseData obliqueSideRaisesRight = new ExerciseData();
		obliqueSideRaisesRight.Init("Oblique Side Raises - Right Side", 60, 3, 10, 0, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesRight);

        return workoutData;

    }
}
