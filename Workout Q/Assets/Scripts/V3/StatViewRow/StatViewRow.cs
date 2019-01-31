using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatViewRow : MonoBehaviour 
{
	public int value;
	public TextMeshProUGUI label;
	public LineSegmenter lineSegmenter;
	public string labelString;

	public void UpdateLabel(string labelText)
	{
		label.text = labelText;
	}

	public void UpdateView(string labelText, int value)
	{
		label.text = labelText;
		lineSegmenter.Init (value);
	}

	public void UpdateViewCustomLabel(string labelText, int value)
	{
		label.text = labelText;
		lineSegmenter.Init (value);
	}
}
