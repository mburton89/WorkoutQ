using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SetupPanel : MonoBehaviour {

	public static SetupPanel Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private ShadowButton _changeColorButton;
	[SerializeField] private ShadowButton _addWorkoutPlanButton;
	[SerializeField] private ShadowButton _doneButton;
	[SerializeField] private Button _clickOverlay;

	[SerializeField] List<Image> _colorImages;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		foreach (Image colorImage in _colorImages)
		{
			colorImage.color = ColorManager.Instance.ActiveColorLight;	
		}		
	}

	void OnEnable()
	{
		_changeColorButton.onShortClick.AddListener (HandleChangeColorButtonPressed);
		_addWorkoutPlanButton.onShortClick.AddListener (HandleAddWorkoutPlansPressed);
		_doneButton.onShortClick.AddListener (Exit);
		_clickOverlay.onClick.AddListener(Exit);
	}

	void OnDisable()
	{
		_changeColorButton.onShortClick.RemoveListener (HandleChangeColorButtonPressed);
		_addWorkoutPlanButton.onShortClick.RemoveListener (HandleAddWorkoutPlansPressed);
		_doneButton.onShortClick.RemoveListener (Exit);
		_clickOverlay.onClick.RemoveListener(Exit);
	}

	void HandleChangeColorButtonPressed()
	{
		SceneManager.LoadScene (1);
	}

	void HandleAddWorkoutPlansPressed()
	{
		Exit ();
		AddPlanPanel.Instance.ShowPlans ();
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	void Exit()
	{
		_container.SetActive (false);
	}

	void GoToPlayerTestScene()
	{
		SceneManager.LoadScene (2);
	}
}
