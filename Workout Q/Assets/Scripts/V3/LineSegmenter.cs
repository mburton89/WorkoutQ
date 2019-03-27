using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSegmenter : MonoBehaviour {

	[SerializeField] private Image _bg;
	[SerializeField] private LineSegment _lineSegmentPrefab;
	private List<LineSegment> _lineSegments;
	private LineSegment _activeLine;

	public void Init(int numberOfSegments){

		Clear ();

		_lineSegments = new List<LineSegment>();

		for (int i = 0; i < numberOfSegments; i++) {
			LineSegment newLine = Instantiate (_lineSegmentPrefab, this.transform);
			newLine.lineImage.color = ColorManager.Instance.ActiveColorLight;
			_lineSegments.Add (newLine);
		}

		if (_lineSegments.Count > 0) 
		{
			_bg.enabled = false;		
		}
	}

	public void ShowSegmentBlinking(int setNumber){

		if (_activeLine != null) {
			_activeLine.StopGlowing ();
		}

		for (int i = 0; i < setNumber; i++) {
			_lineSegments [i].LightUp ();
		}

		for (int i = 0; i < _lineSegments.Count; i++) {
			if (i > setNumber && i <= _lineSegments.Count){
				_lineSegments [i].Darken ();
			}
		}

		_activeLine = _lineSegments [setNumber];
		_activeLine.UpdateSpriteToWhite ();
		_activeLine.StartGlowing ();
	}

	public void ShowSegmentLit(int segmentIndex)
	{
		if (_activeLine != null) {
			_activeLine.Darken ();
		}

		_activeLine = _lineSegments [segmentIndex];
		_activeLine.LightUp ();
	}

	public void ShowSegmentCummulativelyLit(int segmentIndex)
	{
		for (int i = 0; i < segmentIndex; i++) {
			_lineSegments [i].LightUp ();
		}

		for (int i = 0; i < _lineSegments.Count; i++) {
			if (i > segmentIndex && i <= _lineSegments.Count) {
				_lineSegments [i].Darken ();
			}
		}

		_activeLine = _lineSegments [segmentIndex];
		_activeLine.LightUp ();
	}

	public void Clear()
	{
		if (_lineSegments != null) {
			foreach (LineSegment line in _lineSegments) {
				Destroy (line.gameObject);
			}
			_lineSegments.Clear ();
		}

		_bg.enabled = true;
	}
}
