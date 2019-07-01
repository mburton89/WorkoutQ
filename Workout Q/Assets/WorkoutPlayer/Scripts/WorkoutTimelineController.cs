using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorkoutTimelineController : MonoBehaviour {

	private WorkoutPlayerController _controller;

	private List<WorkoutTimelineSegment> _workoutTimelineSegments;
	private WorkoutTimelineSegment _activeWorkoutTimelineSegment;

	[SerializeField] WorkoutTimelineSegment _workoutTimelineSegmentPrefab;
	[SerializeField] Transform _segmentParent;
	[SerializeField] Image _activeSegmentIndicator;

	private const float INIT_DURATION = 0.1f;
	private const float SNAP_SPEED = 0.5f;

	public void Init(WorkoutPlayerController controller, WorkoutData activeWorkout, int activeExerciseIndex)
	{
		_controller = controller;

		Clear ();

		_workoutTimelineSegments = new List<WorkoutTimelineSegment> ();

		foreach (ExerciseData exercise in activeWorkout.exerciseData) 
		{
			WorkoutTimelineSegment newWorkoutTimelineSegment = Instantiate (_workoutTimelineSegmentPrefab, _segmentParent);
			float amountComplete = ((float)exercise.totalInitialSets - (float)exercise.totalSets) / (float)exercise.totalInitialSets;
			newWorkoutTimelineSegment.Init (this, amountComplete);
			_workoutTimelineSegments.Add (newWorkoutTimelineSegment);
		}

		_activeSegmentIndicator.color = ColorManager.Instance.ActiveColorLight;

		ShowSegmentActiveDelayed (activeExerciseIndex);
	}

	void Clear()
	{
		if (_workoutTimelineSegments != null) 
		{
			foreach (WorkoutTimelineSegment workoutTimelineSegment in _workoutTimelineSegments)
			{
				Destroy (workoutTimelineSegment.gameObject);
			}
			_workoutTimelineSegments.Clear ();
		}
	}

	public void ShowSegmentActive(int index)
	{
		_activeSegmentIndicator.transform.DOMoveX (_workoutTimelineSegments [index].transform.position.x, SNAP_SPEED);
		_activeWorkoutTimelineSegment = _workoutTimelineSegments [index];
	}

	void ShowSegmentActiveDelayed(int index)
	{
		StartCoroutine (TweenToItemByIndexCo (index));
	}

	private IEnumerator TweenToItemByIndexCo(int index)
	{
		yield return new WaitForSeconds(INIT_DURATION);
		ShowSegmentActive(index);
	}

	public void UpdateActiveSegmentProgress(float amountComplete)
	{
		_activeWorkoutTimelineSegment.UpdateFillAmount (amountComplete);
	}

}
