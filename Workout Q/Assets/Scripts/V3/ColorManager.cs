using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour {

	//Main color: FFD833FF

	public static ColorManager Instance;
	public Color ActiveColorLight;
	public Color ActiveColorMedium;
	public Color ActiveColorDark;

	[SerializeField] private TextMeshProUGUI[] _texts;
	[SerializeField] private Image[] _images;

	//RED
//	private const float DEFAULT_HUE = 356f/359f;
//	private const float DEFAULT_SATURATION = 172f/255f;

	//BLUE
	private const float DEFAULT_HUE = 191f/359f;
	private const float DEFAULT_SATURATION = 115f/255f;

	private const float MEDIUM_DARKENER_DIVIDER = 1.75f;
	private const float DARK_DARKENER_DIVIDER = 3f;

	void Awake()
	{
		if (PlayerPrefs.GetInt ("hasSetColor") != 1) 
		{
			PlayerPrefs.SetFloat ("hue", DEFAULT_HUE);
			PlayerPrefs.SetFloat ("saturation", DEFAULT_SATURATION);
			PlayerPrefs.SetInt ("hasSetColor", 1);
		} 

		ActiveColorLight = Color.HSVToRGB(
			PlayerPrefs.GetFloat("hue"),
			PlayerPrefs.GetFloat("saturation"),
			1);

		ActiveColorMedium = new Color (ActiveColorLight.r / MEDIUM_DARKENER_DIVIDER, ActiveColorLight.g / MEDIUM_DARKENER_DIVIDER, ActiveColorLight.b / MEDIUM_DARKENER_DIVIDER);
		ActiveColorDark = new Color (ActiveColorLight.r / DARK_DARKENER_DIVIDER, ActiveColorLight.g / DARK_DARKENER_DIVIDER, ActiveColorLight.b / DARK_DARKENER_DIVIDER);

		Instance = this;
	}

	void Start()
	{
		UpdateColors ();
	}

	public void UpdateColors(){
		foreach (TextMeshProUGUI text in _texts) {
			text.color = ActiveColorLight;
		}

		foreach (Image image in _images) {
			image.color = ActiveColorLight;
		}
	}
}
