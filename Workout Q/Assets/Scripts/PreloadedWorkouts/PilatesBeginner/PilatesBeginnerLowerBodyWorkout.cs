using System.Collections.Generic;

public class PilatesBeginnerLowerBodyWorkout : WorkoutData {

	public PilatesBeginnerLowerBodyWorkout GetWorkoutData(){

        name = "Pilates Lower Body - Beginner";
        exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
		exerciseData.Add (jumpingJacks);

		ExerciseData bodySquats = new ExerciseData ();
        bodySquats.Init ("Body Squats", 90, 3, 10, 0, ExerciseType.pushups);
		exerciseData.Add (bodySquats);

		ExerciseData squatJumps = new ExerciseData ();
        squatJumps.Init ("Squat Jumps", 90, 3, 10, 0, ExerciseType.planks);
		exerciseData.Add (squatJumps);

		ExerciseData lunges = new ExerciseData ();
        lunges.Init ("Lunges", 90, 3, 10, 0, ExerciseType.planks);
		exerciseData.Add (lunges);

		ExerciseData calfRaises = new ExerciseData ();
        calfRaises.Init ("Calf Raises", 90, 3, 10, 0, ExerciseType.dips);
		exerciseData.Add (calfRaises);

		exerciseData.Add (jumpingJacks);
        exerciseData.Add (bodySquats);
        exerciseData.Add (squatJumps);
        exerciseData.Add (lunges);
        exerciseData.Add (calfRaises);

        return this;
	}
}
