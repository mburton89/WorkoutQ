using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExercisePanelV2 : MonoBehaviour {

	public TMP_InputField title;
	public TMP_InputField timeAmount;
	public TMP_InputField setsAmount;
	public TMP_InputField repsAmount;
	public TMP_InputField weightAmount;

	public Button titleButton;
	public Button timeButton;
	public Button setsButton;
	public Button repsButton;
	public Button weightButton;

	public void Init(string title, int seconds, int reps, float sets)
	{
	
	}

	void OnEnable()
	{
		titleButton.onClick.AddListener (HandleTitleButtonPressed);
		timeButton.onClick.AddListener (HandleTitleButtonPressed);
		setsButton.onClick.AddListener (HandleTitleButtonPressed);
		repsButton.onClick.AddListener (HandleTitleButtonPressed);
		weightButton.onClick.AddListener (HandleTitleButtonPressed);
	}

	void OnDisable()
	{
		titleButton.onClick.RemoveAllListeners ();
	}

	void HandleTitleButtonPressed()
	{
		title.Select ();
	}

	void HandleTimeButtonPressed()
	{
		timeAmount.Select ();
	}

	void HandleSetsButtonPressed()
	{
		setsAmount.Select ();
	}

	void HandleRepsButtonPressed()
	{
		repsAmount.Select ();
	}

	void HandleWeightButtonPressed()
	{
		weightAmount.Select ();
	}
}
