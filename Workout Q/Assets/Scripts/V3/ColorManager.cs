using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour {

	public static ColorManager Instance;
	public Color ActiveColor;

	[SerializeField] private TextMeshProUGUI[] _texts;
	[SerializeField] private Image[] _images;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		UpdateColors ();
	}

	public void UpdateColors(){
		foreach (TextMeshProUGUI text in _texts) {
			text.color = ActiveColor;
		}

		foreach (Image image in _images) {
			image.color = ActiveColor;
		}
	}
}
