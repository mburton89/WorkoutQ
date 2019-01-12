using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatEditRow : MonoBehaviour 
{
	public int value;
	public TMP_InputField numberInput;
	public Button lessButton;
	public Button moreButton;
	[HideInInspector] public string labelString;
	[HideInInspector] public EditExerciseView controller;
}
