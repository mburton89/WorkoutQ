using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour {

	public static ColorManager Instance;
	public Color ActiveColor;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
//		Image[] AllImages = FindObjectsOfType<Image> ();
//		foreach (Image image in AllImages) 
//		{
//			image.color = ActiveColor;
//		}
//
//		TextMeshProUGUI[] AllText = FindObjectsOfType<TextMeshProUGUI> ();
//		foreach (TextMeshProUGUI text in AllText) 
//		{
//			text.color = ActiveColor;
//		}
	}
}
