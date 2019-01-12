﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSegmenter : MonoBehaviour {

	[SerializeField] private LineSegment _lineSegmentPrefab;
	private List<LineSegment> _lineSegments;

	private LineSegment _activeLine;

	public void Init(int numberOfSegments){

		if (_lineSegments != null) {
			foreach (LineSegment line in _lineSegments) {
				Destroy (line.gameObject);
			}
		}

		_lineSegments = new List<LineSegment>();

		for (int i = 0; i < numberOfSegments; i++) {
			LineSegment newLine = Instantiate (_lineSegmentPrefab, this.transform);
			newLine.lineImage.color = ColorManager.Instance.ActiveColor;
			_lineSegments.Add (newLine);
		}
	}

	public void ShowSegmentBlinking(int setNumber){

		if (_activeLine != null) {
			_activeLine.StopBlinking ();
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
		_activeLine.StartBlinking ();
	}

	public void ShowSegmentLit(int segmentIndex)
	{
		if (_activeLine != null) {
			_activeLine.Darken ();
		}

		_activeLine = _lineSegments [segmentIndex];
		_activeLine.LightUp ();
	}
}
