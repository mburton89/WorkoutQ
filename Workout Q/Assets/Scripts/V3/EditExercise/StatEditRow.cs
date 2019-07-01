using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatEditRow : MonoBehaviour 
{
	public int value;
	public TMP_InputField numberInput;
	public ShadowButton lessButton;
	public ShadowButton moreButton;
	[HideInInspector] public string labelString;
	[HideInInspector] public EditExerciseView controller;

	void Start()
	{
		#if UNITY_ANDROID
		//Do nothing
		#else
		numberInput.shouldHideMobileInput = false;
		#endif
	}
}
