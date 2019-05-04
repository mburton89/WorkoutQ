using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutPlayerController : MonoBehaviour 
{
	private WorkoutData _activeWorkout;
	private ExerciseData _activeExercise;
	private ExerciseData _nextExercise;
	private int _activeExerciseIndex;

	[SerializeField] private WorkoutControlsController _workoutControls;
	[SerializeField] private ExerciseStatsController _exerciseStats;
	[SerializeField] private ExerciseTitlesController _exerciseTitles;
	[SerializeField] private SetsDisplayController _setsDisplayController;
	[SerializeField] private SmartCarousel _carousel;
	[SerializeField] private HighlightButton _previousExerciseButton;
	[SerializeField] private HighlightButton _nextExerciseButton;

	public void Init(WorkoutData workout, int activeExerciseIndex)
	{
		_activeWorkout = workout;
		_activeExerciseIndex = activeExerciseIndex;
		EstablishActiveExercise ();
		EstablishNextExercise ();
		_workoutControls.Init (this);
		_exerciseStats.Init (this);
		_exerciseTitles.Init (this);
		_carousel.Init (_activeWorkout, _activeExerciseIndex);
	}

	void OnEnable()
	{
		_previousExerciseButton.onClick.AddListener (GoToPreviousExercise);
		_nextExerciseButton.onClick.AddListener (GoToNextExercise);
		_carousel.onEndDrag.AddListener (HandleCarouselEndDrag);
	}

	void OnDisable()
	{
		_previousExerciseButton.onClick.RemoveListener (GoToPreviousExercise);
		_nextExerciseButton.onClick.RemoveListener (GoToNextExercise);
		_carousel.onEndDrag.RemoveListener (HandleCarouselEndDrag);
	}

	public void Play()
	{
		
	}

	public void Pause()
	{

	}

	public void RestartSet()
	{

	}

	public void GoToPreviousSet()
	{

	}

	public void GoToNextSet()
	{

	}

	public void HandleBackPressed()
	{
		
	}

	public void GoToPreviousExercise()
	{
		if (_activeExerciseIndex > 0) 
		{
			_activeExerciseIndex--;
			EstablishActiveExercise ();
			EstablishNextExercise ();
		}

		_carousel.TweenToItemByIndex (_activeExerciseIndex);
	}

	public void GoToNextExercise()
	{
		if(_activeExerciseIndex < _activeWorkout.exerciseData.Count - 1)
		{
			_activeExerciseIndex++	;
			EstablishActiveExercise ();
			EstablishNextExercise ();
		}

		_carousel.TweenToItemByIndex (_activeExerciseIndex);
	}

	void EstablishActiveExercise()
	{
		_activeExercise = _activeWorkout.exerciseData[_activeExerciseIndex];
		_exerciseStats.UpdateRepValue (_activeExercise.repsPerSet);
		_exerciseStats.UpdateTimeValue (_activeExercise.secondsToCompleteSet);
		_exerciseStats.UpdateWeightValue (_activeExercise.weight);
		_exerciseTitles.UpdateActiveExerciseTitle (_activeExercise.name);

		int activeSet = (_activeExercise.totalInitialSets - (_activeExercise.totalSets - 1));
		_setsDisplayController.Init (_activeExercise.totalInitialSets);
		_setsDisplayController.ShowSetActive (activeSet); 
	}

	void EstablishNextExercise()
	{
		if (_activeExerciseIndex < _activeWorkout.exerciseData.Count - 1) 
		{
			ExerciseData nextExercise = _activeWorkout.exerciseData [_activeExerciseIndex + 1];
			_exerciseTitles.UpdateNextExerciseTitle (nextExercise.name, nextExercise.weight);
		}
		else 
		{
			_exerciseTitles.HideNextExerciseText ();
		}
	}

	void HandleCarouselEndDrag()
	{
		print ("HandleCarouselEndDrag");
		_activeExerciseIndex = _carousel.GetActiveIndex ();
		EstablishActiveExercise ();
		EstablishNextExercise ();
	}
}
