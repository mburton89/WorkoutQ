using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeSliderController : MonoBehaviour {

	private WorkoutPlayerController _controller;

	[SerializeField] private Slider _slider;
	[SerializeField] private Image _handle;
	[SerializeField] private Image _fill;
	[SerializeField] private Image _bg;

	public UISelectHandler selectHandler;

	public void Init(WorkoutPlayerController controller)
	{
		_controller = controller;
		_handle.color = ColorManager.Instance.ActiveColorLight;
		_fill.color = ColorManager.Instance.ActiveColorLight;
		_bg.color = ColorManager.Instance.ActiveColorDark;
	}

	void OnEnable()
	{
		_slider.onValueChanged.AddListener (HandleHandleMoved);
	}

	void OnDisable()
	{
		_slider.onValueChanged.RemoveListener (HandleHandleMoved);
	}

	void HandleHandleMoved(float value)
	{
		if (!selectHandler.pointerIsDown)return;
		_controller.UpdateSecondsRemainingViaSlider (_slider.value);
	}

	public void UpdateValue(float value)
	{
		_slider.value = value;
	}

	public void Reset()
	{
		_slider.value = 0f;
	}
}