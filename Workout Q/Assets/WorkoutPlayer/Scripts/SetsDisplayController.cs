using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetsDisplayController : MonoBehaviour 
{
	private WorkoutPlayerController _controller;

	private List<SetsDisplaySegment> _setDisplaySegments;
	private SetsDisplaySegment _activeSetDisplaySegment;

	[SerializeField] SetsDisplaySegment _setDisplaySegmentPrefab;
	[SerializeField] Transform _segmentParent;
	[SerializeField] TextMeshProUGUI _completeLabel;

	public void Init(WorkoutPlayerController controller, int totalSets)
	{
		_controller = controller;

		Clear ();

		_setDisplaySegments = new List<SetsDisplaySegment> ();

		bool shouldShowWord = false;

		if (totalSets < 6) 
		{
			shouldShowWord = true;
		}

		for (int i = 0; i < totalSets; i++) 
		{
			SetsDisplaySegment newSetDisplaySegment = Instantiate (_setDisplaySegmentPrefab, _segmentParent);
			newSetDisplaySegment.Init (i + 1, shouldShowWord);
			_setDisplaySegments.Add (newSetDisplaySegment);
		}

		_completeLabel.color = ColorManager.Instance.ActiveColorLight;
	}

	public void Clear()
	{
		if (_setDisplaySegments != null) 
		{
			foreach (SetsDisplaySegment setDisplaySegment in _setDisplaySegments)
			{
				Destroy (setDisplaySegment.gameObject);
			}
			_setDisplaySegments.Clear ();
		}

		HideCompleteTextLabel ();
	}

	public void ShowSetActive(int setNumber)
	{
		if (setNumber > _setDisplaySegments.Count)
		{
			MarkAllSetsComplete ();
			return;
		} 
		else
		{
			HideCompleteTextLabel ();
			foreach (SetsDisplaySegment segment in _setDisplaySegments) 
			{
				segment.ShowTextLabel ();
			}
		}

		for (int i = 0; i < setNumber; i++)
		{
			_setDisplaySegments [i].ShowAsComplete ();
		}

		for (int i = _setDisplaySegments.Count; i > setNumber; i--)
		{
			_setDisplaySegments [i - 1].ShowAsIncomplete ();
		}

		_activeSetDisplaySegment = _setDisplaySegments [setNumber - 1];
		_activeSetDisplaySegment.StartGlowing ();
		_activeSetDisplaySegment.LightUpText ();
	}

	public void MarkAllSetsComplete()
	{
		foreach (SetsDisplaySegment segment in _setDisplaySegments) 
		{
			segment.ShowAsComplete ();
			segment.HideTextLabel ();
		}

		ShowCompleteTextLabel ();
	}

	public void HideCompleteTextLabel()
	{
		_completeLabel.gameObject.SetActive (false);
	}

	public void ShowCompleteTextLabel()
	{
		_completeLabel.gameObject.SetActive (true);
	}
}
