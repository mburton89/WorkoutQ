using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseSlider : MonoBehaviour {

	public static ExerciseSlider Instance;

	public Slider slider;
	[SerializeField] private Image _handleContiainer;
	[SerializeField] private Image _handleFill;
	[SerializeField] RectTransform _handleSlideArea;

	public UISelectHandler selectHandler;

	void Awake()
	{
		Instance = this;
	}

	public void Init(int totalExercises, int currentIndex)
	{
		Show ();
		slider.maxValue = totalExercises - 1;	
		slider.value = currentIndex;
		RectTransform handleRect = _handleContiainer.GetComponent<RectTransform> ();
		RectTransform sliderRect = slider.GetComponent<RectTransform> ();
		handleRect.sizeDelta = new Vector2 (sliderRect.rect.width / (totalExercises), handleRect.rect.height);
		_handleSlideArea.sizeDelta = new Vector2 (sliderRect.rect.width - handleRect.rect.width , sliderRect.rect.height);
		_handleFill.color = ColorManager.Instance.ActiveColorLight;
	}

	void Show()
	{
		transform.localScale = Vector3.one;
	}

	public void Hide()
	{
		transform.localScale = Vector3.zero;
	}

	void OnEnable()
	{
		slider.onValueChanged.AddListener (HandleSliderMoved);
	}

	void OnDisable()
	{
		slider.onValueChanged.RemoveListener (HandleSliderMoved);
	}

	void HandleSliderMoved(float value)
	{
		if (!selectHandler.pointerIsDown)return;

		int intValue = (int)value;
		//WorkoutHUD.Instance.SetupExerciseToPlay(intValue);
		PlayModeManager.Instance.SetUpExercise(WorkoutManager.Instance.ActiveWorkout, intValue);
		SoundManager.Instance.PlayButtonPressSound ();
	}
}
