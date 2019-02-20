using System.Collections.Generic;
using UnityEngine;

public class PilatesBeginnerUpperBodyWorkout : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        name = "Upper Body Pilates";
        workoutData.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
        workoutData.exerciseData.Add (jumpingJacks);

		ExerciseData pushups = new ExerciseData ();
		pushups.Init ("Pushups", 90, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add (pushups);

		ExerciseData frontPlanks = new ExerciseData ();
		frontPlanks.Init ("Front Planks - 15sec", 60, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (frontPlanks);

		ExerciseData backPlanks = new ExerciseData ();
		backPlanks.Init ("Back Planks - 15sec", 60, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (backPlanks);

		ExerciseData chairDips = new ExerciseData ();
		chairDips.Init ("Chair Dips", 90, 3, 10, 0, ExerciseType.dips);
        workoutData.exerciseData.Add (chairDips);

		ExerciseData leftSidePlanks = new ExerciseData ();
		leftSidePlanks.Init ("Left Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (leftSidePlanks);

		ExerciseData rightSidePlanks = new ExerciseData ();
		rightSidePlanks.Init ("Right Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planksFront);
        workoutData.exerciseData.Add (rightSidePlanks);

        return workoutData;
	}
}
