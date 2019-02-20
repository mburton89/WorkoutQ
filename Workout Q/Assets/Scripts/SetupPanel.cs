using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetupPanel : MonoBehaviour {

	public static SetupPanel Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private ShadowTextButton _changeColorButton;
	[SerializeField] private ShadowTextButton _addWorkoutPlanButton;
	[SerializeField] private ShadowTextButton _doneButton;
	[SerializeField] private Button _clickOverlay;

	void Awake()
	{
		Instance = this;
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
}
