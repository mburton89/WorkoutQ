using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorkoutTimelineSegment : MonoBehaviour 
{
	private WorkoutTimelineController _controller;

	[SerializeField] private Image _bg;
	[SerializeField] private Image _fill;

	[HideInInspector] public bool isComplete;

	public void Init(WorkoutTimelineController controller, float amountComplete)
	{
		_controller = controller;
		_bg.color = ColorManager.Instance.ActiveColorDark;
		_fill.color = ColorManager.Instance.ActiveColorLight;
		UpdateFillAmount (amountComplete);
	}

	public void UpdateFillAmount(float amountComplete)
	{
		_fill.fillAmount = amountComplete;
	}
}
