using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutGenerator : MonoBehaviour {

	public static WorkoutGenerator Instance;

    //PRELOADED STUFF
	public List<PlanData> preloadedPlans;
	public List<WorkoutData> preloadedWorkouts;
	public List<ExerciseData> preloadedExercises;

	public HomeBeginnerPlan homeBeginnerPlan;
	public HomeIntermediatePlan homeIntermediatePlan;
	public GymAdvancedPlan gymAdvancedPlan;

	//STANDALONE WORKOUTS;
	public PilatesBeginnerLowerBodyWorkout pilatesLowerBody;
	public PilatesBeginnerUpperBodyWorkout pilatesUpperBody;

	//PRELOADED EXERCISES
	ExerciseData abWheelExercise = new ExerciseData();
	ExerciseData bandsExternalExercise = new ExerciseData(); //2/19/2019
	ExerciseData bandsInternalExercise = new ExerciseData(); //2/19/2019
	ExerciseData benchPressExercise = new ExerciseData();
	ExerciseData bentOverRowExercise = new ExerciseData();
	ExerciseData bodySquatsExercise = new ExerciseData(); //2/19/2019
	ExerciseData boxJumpsExercise = new ExerciseData();
	ExerciseData calfRaisesExercise = new ExerciseData();
	ExerciseData chairDipsExercise = new ExerciseData(); //2/19/2019
	ExerciseData chinUpsExercise = new ExerciseData(); //2/19/2019
	ExerciseData cleansExercise = new ExerciseData();
	ExerciseData cleanPressExercise = new ExerciseData(); //2/19/2019
	ExerciseData crunchesExercise = new ExerciseData(); //2/19/2019
	ExerciseData curlsExercise = new ExerciseData();
	ExerciseData dbFrontRaisesExercise = new ExerciseData();
	ExerciseData dbRowsExercise = new ExerciseData();
	ExerciseData dbShoulderPressExercise = new ExerciseData();
	ExerciseData dbSideRaisesExercise = new ExerciseData();
	ExerciseData dbToeTouchesExercise = new ExerciseData(); //2/19/2019
	ExerciseData deadliftsExercise = new ExerciseData();
	ExerciseData dipsExercise = new ExerciseData();
	ExerciseData hammerCurlsExercise = new ExerciseData(); //2/19/2019
	ExerciseData hangingKneeRaisesExercise = new ExerciseData(); //2/19/2019
	ExerciseData inclineBenchExercise = new ExerciseData();
	ExerciseData jumpingJacksExercise = new ExerciseData();
	ExerciseData lungesExercise = new ExerciseData();
	ExerciseData militaryPressExercise = new ExerciseData(); //2/19/2019
	ExerciseData modifiedPushupsExercise = new ExerciseData(); //2/19/2019
	ExerciseData obliqueSideRaisesExercise = new ExerciseData(); //2/19/2019
	ExerciseData overheadTricepExtensionsExercise = new ExerciseData(); //2/19/2019
	ExerciseData reverseCurlsExercise = new ExerciseData(); //2/19/2019
	ExerciseData reverseFliesExercise = new ExerciseData(); //2/19/2019
	ExerciseData rowMachineExercise = new ExerciseData(); //2/19/2019
	ExerciseData planksBackExercise = new ExerciseData(); //2/19/2019
	ExerciseData planksFrontExercise = new ExerciseData();
	ExerciseData planksSideExercise = new ExerciseData(); //2/19/2019
	ExerciseData pullUpsExercise = new ExerciseData();
	ExerciseData pushupsExercise = new ExerciseData();
	ExerciseData runningExercise = new ExerciseData();
	ExerciseData shrugsExercise = new ExerciseData();
	ExerciseData skullCrushersExercise = new ExerciseData(); //2/19/2019
	ExerciseData squatsExercise = new ExerciseData();
	ExerciseData squatJumpsExercise = new ExerciseData(); //2/19/2019
	ExerciseData straightLegDeadliftExercise = new ExerciseData(); //2/19/2019
	ExerciseData tricepKickBackExercise = new ExerciseData();
	ExerciseData uprightRowsExercise = new ExerciseData(); //2/19/2019
	ExerciseData windmillsExercise = new ExerciseData(); //2/19/2019


	//SPRITES FOR FITBOY ANIMATIONS 
	public List<Sprite> 
	_generic,
    abWheel,
	bandsExternal,
	bandsInternal,
    benchPress,
    bentOverRow,
	bodySquats,
    boxJumps,
    calfRaises,
	chairDips,
	chinUps,
    cleans,
	cleanPress,
	crunches,
    curls,
    dbFrontRaises,
    dbRows,
    db_shoulder_press,
    db_side_raises,
	dbToeTouches,
    deadlifts,
    dips,
	hammerCurls,
	hangingKneeRaises,
    inclineBench,
    jumpingJacks,
    lunges,
	militaryPress,
	modifiedPushups,
	obliqueSideRaises,
	overheadTricepExtensions,
	reverseCurls,
	reverseFlies,
	rowMachine,
	planksBack,
    planksFront,
	planksSide,
    pullUps,
    pushups,
    running,
    shrugs,
	skullCrushers,
	squats,
	squatJumps,
	straightLegDeadlift,
	tricepKickBack,
	uprightRows,
	windmills;
   
	[HideInInspector]public List<List<Sprite>> listOfExerciseSpriteLists = new List<List<Sprite>>();

	//SPRITES FOR FITBOY ILLUMINATIONS 
	public Sprite 
		_singleDumbell,
		doubleDumbell,
		dumbellsOnBench,
		benchRack,
		squatRack,
		pullupBar,
		barbell,
		kettleBell,
		noWeights,
		stopWatch,
		heartRate,
		mon,
		tue,
		wed,
		thu,
		fri,
		sat,
		sun,
		day1,
		day2,
		day3,
		day4,
		day5,
		day6,
		day7;

	[HideInInspector]public List<Sprite> listOfWorktoutSprites = new List<Sprite>();

	//SPRITES FOR PLAN DIFFICULTIES
	public Sprite 
	easy,
	medium,
	hard;

	[HideInInspector]public List<Sprite> listOfDifficultySprites = new List<Sprite>();
    
	void Awake()
	{
		AddExerciseSpritesListsToExerciseSpriteListList();
		AddWorkoutSpriteToWorkoutSpriteList ();
		AddPlanSpriteToPlanSpriteList ();
		AddExercisesToPreloadedExercisesList();
		AddPlansToPreloadedPlansList ();
		Instance = this;
	}

	void Start()
	{
		AddWorkoutsToPreloadedWorkoutsList();
	}

	public List<Sprite> GetSpritesForExercise(ExerciseType exerciseType)
	{
		return listOfExerciseSpriteLists[(int)exerciseType];
	}

	public Sprite GetSpriteForWorkout(WorkoutType workoutType)
	{
		return listOfWorktoutSprites[(int)workoutType];
	}

	public Sprite GetSpriteForDifficulty(PlanDifficulty planDifficulty)
	{
		return listOfDifficultySprites[(int)planDifficulty];
	}

	void AddPlansToPreloadedPlansList()
	{
		preloadedPlans.Add (homeBeginnerPlan.planData);
		preloadedPlans.Add (homeIntermediatePlan.planData);
		preloadedPlans.Add (gymAdvancedPlan.planData);
	}

    void AddWorkoutsToPreloadedWorkoutsList()
	{
		preloadedWorkouts.Add (pilatesLowerBody.GetWorkoutData());
		preloadedWorkouts.Add (pilatesUpperBody.GetWorkoutData());

		foreach (WorkoutData workout in homeBeginnerPlan.planData.workoutData) 
		{
			preloadedWorkouts.Add (workout);
		}

		foreach (WorkoutData workout in homeIntermediatePlan.planData.workoutData) 
		{
			preloadedWorkouts.Add (workout);
		}

		foreach (WorkoutData workout in gymAdvancedPlan.planData.workoutData) 
		{
			preloadedWorkouts.Add (workout);
		}
	}

	void AddExercisesToPreloadedExercisesList()
	{
		abWheelExercise.Init("Ab Wheel", 60, 3, 10, 0, ExerciseType.abWheel);
		bandsExternalExercise.Init ("Bands - External", 90, 3, 10, 0, ExerciseType.bandsExternal);
		bandsInternalExercise.Init ("Bands - Internal", 90, 3, 10, 0, ExerciseType.bandsInternal);
		benchPressExercise.Init("Bench Press", 90, 3, 10, 45, ExerciseType.benchPress);
		bentOverRowExercise.Init("Bent Over Rows", 90, 3, 10, 45, ExerciseType.bentOverRow);
		bodySquatsExercise.Init ("Body Squats", 90, 3, 10, 0, ExerciseType.bodySquats);
		boxJumpsExercise.Init("Box Jumps", 60, 3, 10, 0, ExerciseType.boxJumps);
		calfRaisesExercise.Init("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
		chairDipsExercise.Init("Chair Dips", 90, 3, 10, 0, ExerciseType.chairDips);
		chinUpsExercise.Init("Chin Ups", 90, 3, 10, 0, ExerciseType.chinUps);
		cleansExercise.Init("Cleans", 90, 3, 10, 45, ExerciseType.cleans);
		cleanPressExercise.Init("Clean Press", 90, 3, 10, 0, ExerciseType.cleanPress);
		crunchesExercise.Init("Crunches", 90, 3, 10, 0, ExerciseType.crunches);
		curlsExercise.Init("Curls", 60, 3, 10, 5, ExerciseType.curls);
		dbFrontRaisesExercise.Init("DB Front Raises", 60, 3, 10, 5, ExerciseType.dbFrontRaises);
		dbRowsExercise.Init("DB Rows", 60, 3, 10, 5, ExerciseType.dbRows);
		dbShoulderPressExercise.Init("DB Shoulder Press", 60, 3, 10, 5, ExerciseType.db_shoulder_press);
		dbSideRaisesExercise.Init("DB Side Raises", 60, 3, 10, 5, ExerciseType.db_side_raises);
		dbToeTouchesExercise.Init("DB Toe Touches", 90, 3, 10, 0, ExerciseType.dbToeTouches);
		deadliftsExercise.Init("Deadlifts", 90, 3, 10, 45, ExerciseType.deadlifts);
		dipsExercise.Init("Dips", 90, 3, 10, 0, ExerciseType.dips);
		hammerCurlsExercise.Init("Hammer Curls", 90, 3, 10, 0, ExerciseType.hammerCurls);
		hangingKneeRaisesExercise.Init("Hanging Knee Raises", 90, 3, 10, 0, ExerciseType.hangingKneeRaises);
		inclineBenchExercise.Init("Incline Bench", 90, 3, 10, 45, ExerciseType.inclineBench);
		jumpingJacksExercise.Init("Jumping Jacks", 60, 3, 10, 0, ExerciseType.jumpingJacks);
		lungesExercise.Init("Lunges", 60, 3, 10, 0, ExerciseType.lunges);
		militaryPressExercise.Init("Military Press", 90, 3, 10, 0, ExerciseType.militaryPress);
		modifiedPushupsExercise.Init("Modified Pushups", 90, 3, 10, 0, ExerciseType.modifiedPushups);
		obliqueSideRaisesExercise.Init("Oblique Side Raises", 90, 3, 10, 0, ExerciseType.obliqueSideRaises);
		overheadTricepExtensionsExercise.Init("Overhead Tricep Extensions", 90, 3, 10, 0, ExerciseType.overheadTricepExtensions);
		reverseCurlsExercise.Init("Reverse Curls", 90, 3, 10, 0, ExerciseType.reverseCurls);
		reverseFliesExercise.Init("Reverse Flies", 90, 3, 10, 0, ExerciseType.reverseFlies);
		rowMachineExercise.Init("Row Machine", 90, 3, 10, 0, ExerciseType.rowMachine);
		planksBackExercise.Init("Planks - Back", 90, 3, 10, 0, ExerciseType.planksBack);
		planksFrontExercise.Init("Planks - Front", 60, 3, 10, 0, ExerciseType.planksFront);
		planksSideExercise.Init("Planks - Side", 90, 3, 10, 0, ExerciseType.planksSide);
		pullUpsExercise.Init("Pullups", 90, 3, 5, 0, ExerciseType.pullUps);
		pushupsExercise.Init("Pushups", 60, 3, 10, 0, ExerciseType.pushups);
		runningExercise.Init("Run!", 300, 1, 1, 0, ExerciseType.running);
		shrugsExercise.Init("Shrugs", 60, 3, 10, 5, ExerciseType.shrugs);
		skullCrushersExercise.Init("Skull Crushers", 90, 3, 10, 0, ExerciseType.skullCrushers);
		squatsExercise.Init("Squats", 90, 3, 10, 45, ExerciseType.squats);
		squatJumpsExercise.Init("Squat Jumps", 90, 3, 10, 0, ExerciseType.squatJumps);
		straightLegDeadliftExercise.Init("Straight Leg Deadlift", 90, 3, 10, 0, ExerciseType.straightLegDeadlift);
		tricepKickBackExercise.Init("Tricep Kick Backs", 60, 3, 10, 5, ExerciseType.tricepKickBack);
		uprightRowsExercise.Init("Upright Rows", 90, 3, 10, 0, ExerciseType.uprightRows);
		windmillsExercise.Init("Windmills", 90, 3, 10, 0, ExerciseType.windmills);

		preloadedExercises.Add(abWheelExercise);
		preloadedExercises.Add (bandsExternalExercise);
		preloadedExercises.Add (bandsInternalExercise);
		preloadedExercises.Add(benchPressExercise);
		preloadedExercises.Add(bentOverRowExercise);
		preloadedExercises.Add (bodySquatsExercise);
		preloadedExercises.Add(boxJumpsExercise);
		preloadedExercises.Add(calfRaisesExercise);
		preloadedExercises.Add (chairDipsExercise);
		preloadedExercises.Add (chinUpsExercise);
		preloadedExercises.Add(cleansExercise);
		preloadedExercises.Add (cleanPressExercise);
		preloadedExercises.Add (crunchesExercise);
		preloadedExercises.Add(curlsExercise);
		preloadedExercises.Add(dbFrontRaisesExercise);
		preloadedExercises.Add(dbRowsExercise);
		preloadedExercises.Add(dbShoulderPressExercise);
		preloadedExercises.Add(dbSideRaisesExercise);
		preloadedExercises.Add (dbToeTouchesExercise);
		preloadedExercises.Add(deadliftsExercise);
		preloadedExercises.Add(dipsExercise);
		preloadedExercises.Add (hammerCurlsExercise);
		preloadedExercises.Add (hangingKneeRaisesExercise);
		preloadedExercises.Add(inclineBenchExercise);
		preloadedExercises.Add(jumpingJacksExercise);
		preloadedExercises.Add(lungesExercise);
		preloadedExercises.Add (militaryPressExercise);
		preloadedExercises.Add (modifiedPushupsExercise);
		preloadedExercises.Add (obliqueSideRaisesExercise);
		preloadedExercises.Add (overheadTricepExtensionsExercise);
		preloadedExercises.Add (reverseCurlsExercise);
		preloadedExercises.Add (reverseFliesExercise);
		preloadedExercises.Add (rowMachineExercise);
		preloadedExercises.Add (planksBackExercise);
		preloadedExercises.Add(planksFrontExercise);
		preloadedExercises.Add(planksSideExercise);
		preloadedExercises.Add(pullUpsExercise);
		preloadedExercises.Add(pushupsExercise);
		preloadedExercises.Add(runningExercise);
		preloadedExercises.Add(shrugsExercise);
		preloadedExercises.Add (skullCrushersExercise);
		preloadedExercises.Add(squatsExercise);
		preloadedExercises.Add(squatJumpsExercise);
		preloadedExercises.Add(straightLegDeadliftExercise);
		preloadedExercises.Add(tricepKickBackExercise);
		preloadedExercises.Add(uprightRowsExercise);
		preloadedExercises.Add(windmillsExercise);
	}

    void AddExerciseSpritesListsToExerciseSpriteListList()
	{
		listOfExerciseSpriteLists.Add(_generic);
        listOfExerciseSpriteLists.Add(abWheel);
		listOfExerciseSpriteLists.Add (bandsExternal);
		listOfExerciseSpriteLists.Add (bandsInternal);
        listOfExerciseSpriteLists.Add(benchPress);
        listOfExerciseSpriteLists.Add(bentOverRow);
		listOfExerciseSpriteLists.Add (bodySquats);
		listOfExerciseSpriteLists.Add(boxJumps);
		listOfExerciseSpriteLists.Add(calfRaises);
		listOfExerciseSpriteLists.Add(chairDips);
		listOfExerciseSpriteLists.Add(chinUps);
        listOfExerciseSpriteLists.Add(cleans);
		listOfExerciseSpriteLists.Add(cleanPress);
		listOfExerciseSpriteLists.Add(crunches);
        listOfExerciseSpriteLists.Add(curls);
		listOfExerciseSpriteLists.Add(dbFrontRaises);
        listOfExerciseSpriteLists.Add(dbRows);
        listOfExerciseSpriteLists.Add(db_shoulder_press);
        listOfExerciseSpriteLists.Add(db_side_raises);
		listOfExerciseSpriteLists.Add(dbToeTouches);
        listOfExerciseSpriteLists.Add(deadlifts);
        listOfExerciseSpriteLists.Add(dips);
		listOfExerciseSpriteLists.Add(hammerCurls);
		listOfExerciseSpriteLists.Add(hangingKneeRaises);
        listOfExerciseSpriteLists.Add(inclineBench);
        listOfExerciseSpriteLists.Add(jumpingJacks);
        listOfExerciseSpriteLists.Add(lunges);
		listOfExerciseSpriteLists.Add (militaryPress);
		listOfExerciseSpriteLists.Add (modifiedPushups);
		listOfExerciseSpriteLists.Add (obliqueSideRaises);
		listOfExerciseSpriteLists.Add (overheadTricepExtensions);
		listOfExerciseSpriteLists.Add (reverseCurls);
		listOfExerciseSpriteLists.Add (reverseFlies);
		listOfExerciseSpriteLists.Add (rowMachine);
		listOfExerciseSpriteLists.Add (planksBack);
        listOfExerciseSpriteLists.Add(planksFront);
		listOfExerciseSpriteLists.Add (planksSide);
        listOfExerciseSpriteLists.Add(pullUps);
        listOfExerciseSpriteLists.Add(pushups);
        listOfExerciseSpriteLists.Add(running);
        listOfExerciseSpriteLists.Add(shrugs);
		listOfExerciseSpriteLists.Add (skullCrushers);
        listOfExerciseSpriteLists.Add(squats);
		listOfExerciseSpriteLists.Add (squatJumps);
		listOfExerciseSpriteLists.Add (straightLegDeadlift);
        listOfExerciseSpriteLists.Add(tricepKickBack);
		listOfExerciseSpriteLists.Add (uprightRows);
		listOfExerciseSpriteLists.Add (windmills);
	}

	void AddWorkoutSpriteToWorkoutSpriteList()
	{
		listOfWorktoutSprites.Add(_singleDumbell);
		listOfWorktoutSprites.Add(doubleDumbell);
		listOfWorktoutSprites.Add(dumbellsOnBench);
		listOfWorktoutSprites.Add(benchRack);
		listOfWorktoutSprites.Add(squatRack);
		listOfWorktoutSprites.Add(pullupBar);
		listOfWorktoutSprites.Add(barbell);
		listOfWorktoutSprites.Add(kettleBell);
		listOfWorktoutSprites.Add(noWeights);
		listOfWorktoutSprites.Add(stopWatch);
		listOfWorktoutSprites.Add(heartRate);
		listOfWorktoutSprites.Add(mon);
		listOfWorktoutSprites.Add(tue);
		listOfWorktoutSprites.Add(wed);
		listOfWorktoutSprites.Add(thu);
		listOfWorktoutSprites.Add(fri);
		listOfWorktoutSprites.Add(sat);
		listOfWorktoutSprites.Add(sun);
		listOfWorktoutSprites.Add(day1);
		listOfWorktoutSprites.Add(day2);
		listOfWorktoutSprites.Add(day3);
		listOfWorktoutSprites.Add(day4);
		listOfWorktoutSprites.Add(day5);
		listOfWorktoutSprites.Add(day6);
		listOfWorktoutSprites.Add(day7);
	}

	void AddPlanSpriteToPlanSpriteList()
	{
		listOfDifficultySprites.Add(easy);
		listOfDifficultySprites.Add(medium);
		listOfDifficultySprites.Add(hard);
	}
}
