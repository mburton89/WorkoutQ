using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetsDisplayController : MonoBehaviour 
{
	private List<SetsDisplaySegment> _setDisplaySegments;
	private SetsDisplaySegment _activeSetDisplaySegment;

	[SerializeField] SetsDisplaySegment _setDisplaySegmentPrefab;
	[SerializeField] Transform _segmentParent;

	public void Init(int totalSets)
	{
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
	}

	public void ShowSetActive(int setNumber)
	{
		for (int i = 0; i < setNumber; i++)
		{
			_setDisplaySegments [i].ShowAsComplete ();
		}

		_activeSetDisplaySegment = _setDisplaySegments [setNumber - 1];
		_activeSetDisplaySegment.StartGlowing ();
		_activeSetDisplaySegment.LightUpText ();
	}

	public void CompleteSet(int setNumber)
	{
		_setDisplaySegments [setNumber - 1].UpdateFillValue (1f);
	}
}
