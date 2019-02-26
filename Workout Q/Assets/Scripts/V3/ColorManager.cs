using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour {

	//Main color: FFD833FF

	public static ColorManager Instance;
	public Color ActiveColor;
	public Color ActiveColorDark;

	[SerializeField] private TextMeshProUGUI[] _texts;
	[SerializeField] private Image[] _images;

	private const float DEFAULT_HUE = 48f/359f;
	private const float DEFAULT_SATURATION = 204f/255f;

	private const float DARKENER_DIVIDER = 1.75f;

	void Awake()
	{
		if (PlayerPrefs.GetInt ("hasSetColor") != 1) 
		{
			PlayerPrefs.SetFloat ("hue", DEFAULT_HUE);
			PlayerPrefs.SetFloat ("saturation", DEFAULT_SATURATION);
			PlayerPrefs.SetInt ("hasSetColor", 1);
		} 

		ActiveColor = Color.HSVToRGB(
			PlayerPrefs.GetFloat("hue"),
			PlayerPrefs.GetFloat("saturation"),
			1);

		ActiveColorDark = new Color (ActiveColor.r / DARKENER_DIVIDER, ActiveColor.g / DARKENER_DIVIDER, ActiveColor.b / DARKENER_DIVIDER);

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
