using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutGenerator : MonoBehaviour {

	public static WorkoutGenerator Instance;

	//WORKOUTS FOR PLANS
	[HideInInspector] public WorkoutData PilatesBeginner1;
	[HideInInspector] public WorkoutData PilatesBeginner2;
	[HideInInspector] public WorkoutData PilatesBeginner3;

	[HideInInspector] public WorkoutData PilatesIntermediate1;
	[HideInInspector] public WorkoutData PilatesIntermediate2;
	[HideInInspector] public WorkoutData PilatesIntermediate3;

	[HideInInspector] public WorkoutData GymBeginner1;
	[HideInInspector] public WorkoutData GymBeginner2;
	[HideInInspector] public WorkoutData GymBeginner3;

	[HideInInspector] public WorkoutData GymIntermediate1;
	[HideInInspector] public WorkoutData GymIntermediate2;
	[HideInInspector] public WorkoutData GymIntermediate3;
	[HideInInspector] public WorkoutData GymIntermediate4;

	[HideInInspector] public WorkoutData FiveFiveFiveAdvanced1;
	[HideInInspector] public WorkoutData FiveFiveFiveAdvanced2;
	[HideInInspector] public WorkoutData FiveFiveFiveAdvanced3;

//	//THE BURTON
//	[HideInInspector] public WorkoutData TheBurton1;
//	[HideInInspector] public WorkoutData TheBurton2;
//	[HideInInspector] public WorkoutData TheBurton3;
//	[HideInInspector] public WorkoutData TheBurton4;
//	[HideInInspector] public WorkoutData TheBurton5;
//	[HideInInspector] public WorkoutData TheBurton6;
//	[HideInInspector] public WorkoutData TheBurton7;
//	[HideInInspector] public WorkoutData TheBurton8;
//	[HideInInspector] public WorkoutData TheBurton9;
//	[HideInInspector] public WorkoutData TheBurton10;

    //PRELOADED STUFF
	public List<PlanData> preloadedPlans;
	public List<WorkoutData> preloadedWorkouts;
	public List<ExerciseData> preloadedExercises;

	//PRELOADED PLANS
	PlanData pilatesTemplate = new PlanData();
//	PlanData pilatesIntermediate = new PlanData();
//	PlanData pilatesAdvanced = new PlanData();

	PlanData homeGymTemplate = new PlanData();
//	PlanData homeIntermediate = new PlanData();
//	PlanData homeAdvanced = new PlanData();

	PlanData gymTemplate = new PlanData();
//	PlanData gymIntermediate = new PlanData();
//	PlanData gymAdvanced = new PlanData();

	//PRELOADED WORKOUTS
	WorkoutData pilatesBeginnerLowerBody = new WorkoutData ();
	WorkoutData pilatesBeginnerUpperBody = new WorkoutData ();
//	WorkoutData pilatesIntermediateLowerBody = new WorkoutData ();
//	WorkoutData pilatesIntermediateUpperBody = new WorkoutData ();
//	WorkoutData pilatesAdvancedLowerBody = new WorkoutData ();
//	WorkoutData pilatesAdvancedUpperBody = new WorkoutData ();
//	WorkoutData pilatesFullBody = new WorkoutData ();

	WorkoutData homeBeginnerPush = new WorkoutData ();
	WorkoutData homeBeginnerPull = new WorkoutData ();
	WorkoutData homeBeginnerLegs = new WorkoutData ();
//	WorkoutData homeIntermediatePush = new WorkoutData ();
//	WorkoutData homeIntermediatePull = new WorkoutData ();
//	WorkoutData homeIntermediateLegs = new WorkoutData ();
//	WorkoutData homeIntermediateShoulders = new WorkoutData ();
//	WorkoutData homeAdvancedPush = new WorkoutData ();
//	WorkoutData homeAdvancedPull = new WorkoutData ();
//	WorkoutData homeAdvancedLegs = new WorkoutData ();
//	WorkoutData homeAdvancedShoulders = new WorkoutData ();
//	WorkoutData homeAdvancedCoreArms = new WorkoutData ();

	WorkoutData gymBeginnerPush = new WorkoutData ();
	WorkoutData gymBeginnerPull = new WorkoutData ();
	WorkoutData gymBeginnerLegs = new WorkoutData ();
//	WorkoutData gymIntermediatePush = new WorkoutData ();
//	WorkoutData gymIntermediatePull = new WorkoutData ();
//	WorkoutData gymIntermediateLegs = new WorkoutData ();
//	WorkoutData gymIntermediateShoulders = new WorkoutData ();
//	WorkoutData gymAdvancedPush = new WorkoutData ();
//	WorkoutData gymAdvancedPull = new WorkoutData ();
//	WorkoutData gymAdvancedLegs = new WorkoutData ();
//	WorkoutData gymAdvancedShoulders = new WorkoutData ();
//	WorkoutData gymAdvancedCoreArms = new WorkoutData ();

	//PRELOADED EXERCISES
	ExerciseData abWheelExercise = new ExerciseData();
	ExerciseData benchPressExercise = new ExerciseData();
	ExerciseData bentOverRowExercise = new ExerciseData();
	ExerciseData boxJumpsExercise = new ExerciseData();
	ExerciseData calfRaisesExercise = new ExerciseData();
	ExerciseData cleansExercise = new ExerciseData();
	ExerciseData curlsExercise = new ExerciseData();
	ExerciseData dbFrontRaisesExercise = new ExerciseData();
	ExerciseData dbRowsExercise = new ExerciseData();
	ExerciseData dbShoulderPressExercise = new ExerciseData();
	ExerciseData dbSideRaisesExercise = new ExerciseData();
	ExerciseData deadliftsExercise = new ExerciseData();
	ExerciseData dipsExercise = new ExerciseData();
	ExerciseData inclineBenchExercise = new ExerciseData();
	ExerciseData jumpingJacksExercise = new ExerciseData();
	ExerciseData lungesExercise = new ExerciseData();
	ExerciseData planksExercise = new ExerciseData();
	ExerciseData pullUpsExercise = new ExerciseData();
	ExerciseData pushupsExercise = new ExerciseData();
	ExerciseData runningExercise = new ExerciseData();
	ExerciseData shrugsExercise = new ExerciseData();
	ExerciseData squatsExercise = new ExerciseData();
	ExerciseData tricepKickBackExercise = new ExerciseData();

	//SPRITES FOR FITBOY ANIMATIONS 
	public List<Sprite> 
	_generic,
    abWheel,
    benchPress,
    bentOverRow,
    boxJumps,
    calfRaises,
    cleans,
    curls,
    dbFrontRaises,
    dbRows,
    db_shoulder_press,
    db_side_raises,
    deadlifts,
    dips,
    inclineBench,
    jumpingJacks,
    lunges,
    planks,
    pullUps,
    pushups,
    running,
    shrugs,
    squats,
    tricepKickBack;

	[HideInInspector]public List<List<Sprite>> listOfSpriteLists = new List<List<Sprite>>();
    
	void Awake()
	{
		AddSpritesListsToSpriteListList();
		AddExercisesToPreloadedExercisesList();
		AddWorkoutsToPreloadedWorkoutsList();
		AddPlansToPreloadedPlansList ();
		Instance = this;
	}

	public List<Sprite> GetSpritesForExercise(ExerciseType exerciseType)
	{
		return listOfSpriteLists[(int)exerciseType];
	}

	void AddPlansToPreloadedPlansList()
	{
		PlanData plan1 = new PlanData();
		plan1.name = "Gym Intermediate";
		plan1.workoutData = new List<WorkoutData>();
		plan1.workoutData.Add (GymIntermediate1);
		plan1.workoutData.Add (GymIntermediate2);
		plan1.workoutData.Add (GymIntermediate3);
		plan1.workoutData.Add (GymIntermediate4);

		PlanData plan2 = new PlanData();
		plan2.name = "Gym Intermediate 2";
		plan2.workoutData = new List<WorkoutData>();
		plan2.workoutData.Add (GymIntermediate1);
		plan2.workoutData.Add (GymIntermediate2);
		plan2.workoutData.Add (GymIntermediate3);
		plan2.workoutData.Add (GymIntermediate4);

		preloadedPlans.Add(plan1);
		preloadedPlans.Add(plan2);
	}

    void AddWorkoutsToPreloadedWorkoutsList()
	{
		WorkoutData ChestAndTriceps1 = new WorkoutData();
		ChestAndTriceps1.name = "Chest and Triceps";
		ChestAndTriceps1.exerciseData = new List<ExerciseData>();
		ChestAndTriceps1.exerciseData.Add(pushupsExercise);
		ChestAndTriceps1.exerciseData.Add(benchPressExercise);
		ChestAndTriceps1.exerciseData.Add(dipsExercise);

		WorkoutData BackAndBiceps1 = new WorkoutData();
		BackAndBiceps1.name = "Back and Biceps";
		BackAndBiceps1.exerciseData = new List<ExerciseData>();
		BackAndBiceps1.exerciseData.Add(pullUpsExercise);
		BackAndBiceps1.exerciseData.Add(bentOverRowExercise);
		BackAndBiceps1.exerciseData.Add(curlsExercise);

		WorkoutData Legs1 = new WorkoutData();
		Legs1.name = "Legs";
		Legs1.exerciseData = new List<ExerciseData>();
		Legs1.exerciseData.Add(boxJumpsExercise);
		Legs1.exerciseData.Add(squatsExercise);
		Legs1.exerciseData.Add(deadliftsExercise);

		WorkoutData Shoulders1 = new WorkoutData();
		Shoulders1.name = "Shoulders";
		Shoulders1.exerciseData = new List<ExerciseData>();
		Shoulders1.exerciseData.Add(dbShoulderPressExercise);
		Shoulders1.exerciseData.Add(dbFrontRaisesExercise);
		Shoulders1.exerciseData.Add(dbSideRaisesExercise);

		WorkoutData Core1 = new WorkoutData();
		Core1.name = "Core";
		Core1.exerciseData = new List<ExerciseData>();
		Core1.exerciseData.Add(jumpingJacksExercise);
		Core1.exerciseData.Add(abWheelExercise);
		Core1.exerciseData.Add(planksExercise);

		preloadedWorkouts.Add(ChestAndTriceps1);
		preloadedWorkouts.Add(BackAndBiceps1);
		preloadedWorkouts.Add(Legs1);
		preloadedWorkouts.Add(Shoulders1);
		preloadedWorkouts.Add(Core1);

		GymIntermediate1 = ChestAndTriceps1;
		GymIntermediate2 = BackAndBiceps1;
		GymIntermediate3 = Legs1;
		GymIntermediate4 = Shoulders1;
	}

	void AddExercisesToPreloadedExercisesList()
	{
		abWheelExercise.Init("Ab Wheel", 60, 3, 10, 0, ExerciseType.abWheel);
		benchPressExercise.Init("Bench Press", 90, 3, 10, 45, ExerciseType.benchPress);
		bentOverRowExercise.Init("Bent Over Rows", 90, 3, 10, 45, ExerciseType.bentOverRow);
		boxJumpsExercise.Init("Box Jumps", 60, 3, 10, 0, ExerciseType.boxJumps);
		calfRaisesExercise.Init("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
		cleansExercise.Init("Cleans", 90, 3, 10, 45, ExerciseType.cleans);
		curlsExercise.Init("Curls", 60, 3, 10, 5, ExerciseType.curls);
		dbFrontRaisesExercise.Init("DB Front Raises", 60, 3, 10, 5, ExerciseType.dbFrontRaises);
		dbRowsExercise.Init("DB Rows", 60, 3, 10, 5, ExerciseType.dbRows);
		dbShoulderPressExercise.Init("DB Shoulder Press", 60, 3, 10, 5, ExerciseType.db_shoulder_press);
		dbSideRaisesExercise.Init("DB Side Raises", 60, 3, 10, 5, ExerciseType.db_side_raises);
		deadliftsExercise.Init("Deadlifts", 90, 3, 10, 45, ExerciseType.deadlifts);
		dipsExercise.Init("Dips", 90, 3, 10, 0, ExerciseType.dips);
		inclineBenchExercise.Init("Incline Bench", 90, 3, 10, 45, ExerciseType.inclineBench);
		jumpingJacksExercise.Init("Jumping Jacks", 60, 3, 10, 0, ExerciseType.jumpingJacks);
		lungesExercise.Init("Lunges", 60, 3, 10, 0, ExerciseType.lunges);
		planksExercise.Init("Planks", 60, 3, 10, 0, ExerciseType.planks);
		pullUpsExercise.Init("Pullups", 90, 3, 5, 0, ExerciseType.pullUps);
		pushupsExercise.Init("Pushups", 60, 3, 10, 0, ExerciseType.pushups);
		runningExercise.Init("Run!", 300, 1, 1, 0, ExerciseType.running);
		shrugsExercise.Init("Shrugs", 60, 3, 10, 5, ExerciseType.shrugs);
		squatsExercise.Init("Squats", 90, 3, 10, 45, ExerciseType.squats);
		tricepKickBackExercise.Init("Tricep Kick Backs", 60, 3, 10, 5, ExerciseType.tricepKickBack);

		preloadedExercises.Add(abWheelExercise);
		preloadedExercises.Add(benchPressExercise);
		preloadedExercises.Add(bentOverRowExercise);
		preloadedExercises.Add(boxJumpsExercise);
		preloadedExercises.Add(calfRaisesExercise);
		preloadedExercises.Add(cleansExercise);
		preloadedExercises.Add(curlsExercise);
		preloadedExercises.Add(dbFrontRaisesExercise);
		preloadedExercises.Add(dbRowsExercise);
		preloadedExercises.Add(dbShoulderPressExercise);
		preloadedExercises.Add(dbSideRaisesExercise);
		preloadedExercises.Add(deadliftsExercise);
		preloadedExercises.Add(dipsExercise);
		preloadedExercises.Add(inclineBenchExercise);
		preloadedExercises.Add(jumpingJacksExercise);
		preloadedExercises.Add(lungesExercise);
		preloadedExercises.Add(planksExercise);
		preloadedExercises.Add(pullUpsExercise);
		preloadedExercises.Add(pushupsExercise);
		preloadedExercises.Add(runningExercise);
		preloadedExercises.Add(shrugsExercise);
		preloadedExercises.Add(squatsExercise);
		preloadedExercises.Add(tricepKickBackExercise);
	}

    void AddSpritesListsToSpriteListList()
	{
		listOfSpriteLists.Add(_generic);
        listOfSpriteLists.Add(abWheel);
        listOfSpriteLists.Add(benchPress);
        listOfSpriteLists.Add(bentOverRow);
		listOfSpriteLists.Add(boxJumps);
        listOfSpriteLists.Add(calfRaises);
        listOfSpriteLists.Add(cleans);
        listOfSpriteLists.Add(curls);
		listOfSpriteLists.Add(dbFrontRaises);
        listOfSpriteLists.Add(dbRows);
        listOfSpriteLists.Add(db_shoulder_press);
        listOfSpriteLists.Add(db_side_raises);
        listOfSpriteLists.Add(deadlifts);
        listOfSpriteLists.Add(dips);
        listOfSpriteLists.Add(inclineBench);
        listOfSpriteLists.Add(jumpingJacks);
        listOfSpriteLists.Add(lunges);
        listOfSpriteLists.Add(planks);
        listOfSpriteLists.Add(pullUps);
        listOfSpriteLists.Add(pushups);
        listOfSpriteLists.Add(running);
        listOfSpriteLists.Add(shrugs);
        listOfSpriteLists.Add(squats);
        listOfSpriteLists.Add(tricepKickBack);
	}

	void EstablishPilatesBeginnerLowerBodyWorkout()
	{
		pilatesBeginnerLowerBody.name = "Pilates Lower Body";
		pilatesBeginnerLowerBody.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
		pilatesBeginnerLowerBody.exerciseData.Add (jumpingJacks);

		ExerciseData bodySquats = new ExerciseData ();
		bodySquats.Init ("Body Squats", 90, 3, 10, 0, ExerciseType.squats);
		pilatesBeginnerLowerBody.exerciseData.Add (bodySquats);

		ExerciseData squatJumps = new ExerciseData ();
		squatJumps.Init ("Squat Jumps", 90, 3, 10, 0, ExerciseType.squats);
		pilatesBeginnerLowerBody.exerciseData.Add (squatJumps);

		ExerciseData lunges = new ExerciseData ();
		lunges.Init ("Lunges", 90, 3, 10, 0, ExerciseType.lunges);
		pilatesBeginnerLowerBody.exerciseData.Add (lunges);

		ExerciseData calfRaises = new ExerciseData ();
		calfRaises.Init ("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
		pilatesBeginnerLowerBody.exerciseData.Add (calfRaises);

		pilatesBeginnerLowerBody.exerciseData.Add (jumpingJacks);
		pilatesBeginnerLowerBody.exerciseData.Add (bodySquats);
		pilatesBeginnerLowerBody.exerciseData.Add (squatJumps);
		pilatesBeginnerLowerBody.exerciseData.Add (lunges);
		pilatesBeginnerLowerBody.exerciseData.Add (calfRaises);
	}

	void EstablishPilatesBeginnerUpperBodyWorkout()
	{
		pilatesBeginnerLowerBody.name = "Pilates Upper Body";
		pilatesBeginnerLowerBody.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
		pilatesBeginnerUpperBody.exerciseData.Add (jumpingJacks);

		ExerciseData pushups = new ExerciseData ();
		pushups.Init ("Pushups", 90, 3, 10, 0, ExerciseType.pushups);
		pilatesBeginnerUpperBody.exerciseData.Add (pushups);

		ExerciseData frontPlanks = new ExerciseData ();
		frontPlanks.Init ("Front Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (frontPlanks);

		ExerciseData backPlanks = new ExerciseData ();
		backPlanks.Init ("Back Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (backPlanks);

		ExerciseData chairDips = new ExerciseData ();
		chairDips.Init ("Chair Dips", 90, 3, 10, 0, ExerciseType.dips);
		pilatesBeginnerUpperBody.exerciseData.Add (chairDips);

		ExerciseData leftSidePlanks = new ExerciseData ();
		leftSidePlanks.Init ("Left Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (leftSidePlanks);

		ExerciseData rightSidePlanks = new ExerciseData ();
		rightSidePlanks.Init ("Right Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (rightSidePlanks);

		pilatesBeginnerLowerBody.exerciseData.Add (jumpingJacks);
		pilatesBeginnerLowerBody.exerciseData.Add (pushups);
		pilatesBeginnerLowerBody.exerciseData.Add (frontPlanks);
		pilatesBeginnerLowerBody.exerciseData.Add (backPlanks);
		pilatesBeginnerLowerBody.exerciseData.Add (chairDips);
		pilatesBeginnerLowerBody.exerciseData.Add (leftSidePlanks);
		pilatesBeginnerLowerBody.exerciseData.Add (rightSidePlanks);
	}

	void EstablishHomePushWorkout()
	{
		pilatesBeginnerLowerBody.name = "Pilates Upper Body";
		pilatesBeginnerLowerBody.exerciseData = new List<ExerciseData>();

		ExerciseData jumpingJacks = new ExerciseData ();
		jumpingJacks.Init ("Jumping Jacks", 75, 5, 20, 0, ExerciseType.jumpingJacks);
		pilatesBeginnerUpperBody.exerciseData.Add (jumpingJacks);

		ExerciseData pushups = new ExerciseData ();
		pushups.Init ("Pushups", 90, 3, 10, 0, ExerciseType.pushups);
		pilatesBeginnerUpperBody.exerciseData.Add (pushups);

		ExerciseData frontPlanks = new ExerciseData ();
		frontPlanks.Init ("Front Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (frontPlanks);

		ExerciseData backPlanks = new ExerciseData ();
		backPlanks.Init ("Back Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (backPlanks);

		ExerciseData chairDips = new ExerciseData ();
		chairDips.Init ("Chair Dips", 90, 3, 10, 0, ExerciseType.dips);
		pilatesBeginnerUpperBody.exerciseData.Add (chairDips);

		ExerciseData leftSidePlanks = new ExerciseData ();
		leftSidePlanks.Init ("Left Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (leftSidePlanks);

		ExerciseData rightSidePlanks = new ExerciseData ();
		rightSidePlanks.Init ("Right Side Planks - 15sec", 60, 3, 10, 0, ExerciseType.planks);
		pilatesBeginnerUpperBody.exerciseData.Add (rightSidePlanks);

		pilatesBeginnerLowerBody.exerciseData.Add (jumpingJacks);
		pilatesBeginnerLowerBody.exerciseData.Add (pushups);
		pilatesBeginnerLowerBody.exerciseData.Add (frontPlanks);
		pilatesBeginnerLowerBody.exerciseData.Add (backPlanks);
		pilatesBeginnerLowerBody.exerciseData.Add (chairDips);
		pilatesBeginnerLowerBody.exerciseData.Add (leftSidePlanks);
		pilatesBeginnerLowerBody.exerciseData.Add (rightSidePlanks);
	}

	void EstablishIntermediatePlan()
	{

	}

	void EstablishPilatesAdvancedPlan()
	{

	}

	void EstablishHomeBeginnerPlan()
	{

	}

	void EstablishHomeIntermediatePlan()
	{

	}

	void EstablishHomeAdvancedPlan()
	{

	}

	void EstablishGymBeginnerPlan()
	{

	}

	void EstablishGymIntermediatePlan()
	{

	}

	void EstablishGymAdvancedPlan()
	{

	}

	void EstablishBurtonsPlan()
	{

	}
}
