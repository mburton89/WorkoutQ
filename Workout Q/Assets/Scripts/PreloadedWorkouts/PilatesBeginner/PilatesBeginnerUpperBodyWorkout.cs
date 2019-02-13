using System.Collections.Generic;

public class PilatesBeginnerUpperBodyWorkout : WorkoutData {

	public PilatesBeginnerUpperBodyWorkout GetWorkoutData(){

        name = "Pilates Upper Body - Beginner";
        exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
		exerciseData.Add (jumpingJacks);

		ExerciseData pushups = new ExerciseData ();
		pushups.Init ("Pushups", 90, 3, 10, 0, ExerciseType.pushups);
		exerciseData.Add (pushups);

		ExerciseData frontPlanks = new ExerciseData ();
		frontPlanks.Init ("Front Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		exerciseData.Add (frontPlanks);

		ExerciseData backPlanks = new ExerciseData ();
		backPlanks.Init ("Back Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		exerciseData.Add (backPlanks);

		ExerciseData chairDips = new ExerciseData ();
		chairDips.Init ("Chair Dips", 90, 3, 10, 0, ExerciseType.dips);
		exerciseData.Add (chairDips);

		ExerciseData leftSidePlanks = new ExerciseData ();
		leftSidePlanks.Init ("Left Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		exerciseData.Add (leftSidePlanks);

		ExerciseData rightSidePlanks = new ExerciseData ();
		rightSidePlanks.Init ("Right Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		exerciseData.Add (rightSidePlanks);

		exerciseData.Add (jumpingJacks);
		exerciseData.Add (pushups);
		exerciseData.Add (frontPlanks);
		exerciseData.Add (backPlanks);
		exerciseData.Add (chairDips);
		exerciseData.Add (leftSidePlanks);
		exerciseData.Add (rightSidePlanks);

        return this;
	}
}
