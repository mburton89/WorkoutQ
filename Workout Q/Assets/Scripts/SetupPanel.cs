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
	[SerializeField] private ShadowButton _aboutButton;
	[SerializeField] private Button _doneButton;
	[SerializeField] private Button _clickOverlay;
	[SerializeField] private TextMeshProUGUI _title;

	[SerializeField] List<Image> _colorImages;

	[SerializeField] private AboutPage _aboutPage;

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
		_aboutButton.onShortClick.AddListener (HandleAboutButtonPressed);
		_doneButton.onClick.AddListener (Exit);
		_clickOverlay.onClick.AddListener(Exit);
	}

	void OnDisable()
	{
		_changeColorButton.onShortClick.RemoveListener (HandleChangeColorButtonPressed);
		_addWorkoutPlanButton.onShortClick.RemoveListener (HandleAddWorkoutPlansPressed);
		_aboutButton.onShortClick.AddListener (HandleAboutButtonPressed);
		_doneButton.onClick.RemoveListener (Exit);
		_clickOverlay.onClick.RemoveListener(Exit);
	}

	void HandleChangeColorButtonPressed()
	{
		SceneManager.LoadScene (2);
	}

	void HandleAddWorkoutPlansPressed()
	{
		Exit ();
		AddPlanPanel.Instance.ShowPlans ();
	}

	public void Show()
	{
		_container.SetActive (true);
		_title.text = "Options";
	}

	void Exit()
	{
		_container.SetActive (false);
		_aboutPage.Close ();
	}

	void GoToPlayerTestScene()
	{
		SceneManager.LoadScene (2);
	}

	void HandleAboutButtonPressed()
	{
		_title.text = "About";
		_aboutPage.Open ();
	}
}
