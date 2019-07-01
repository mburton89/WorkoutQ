using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ColorConfigurer : MonoBehaviour {

	float m_Hue;
	float m_Saturation;
	float m_Scanlines;
	public Slider m_SliderHue, m_SliderSaturation, m_SliderScanlines;
	public ShadowButton confirmButton;
	[SerializeField] private TextMeshProUGUI[] _texts;
	[SerializeField] private Image[] _images;

	[SerializeField] private TextMeshProUGUI _headerTitle;

	void OnEnable()
	{
		confirmButton.onShortClick.AddListener (HandleNextButtonPressed);
	}

	void OnDisable()
	{
		confirmButton.onShortClick.RemoveListener(HandleNextButtonPressed);
	}

	void Start()
	{
		m_SliderHue.maxValue = 1;
		m_SliderSaturation.maxValue = 1;
		m_SliderScanlines.maxValue = 1;

		m_SliderHue.minValue = 0;
		m_SliderSaturation.minValue = 0;
		m_SliderScanlines.minValue = 0;

		m_SliderHue.value = PlayerPrefs.GetFloat("hue");
		m_SliderSaturation.value = PlayerPrefs.GetFloat("saturation");
		m_SliderScanlines.value = PlayerPrefs.GetFloat("scanlines");

		_headerTitle.text = PlayerPrefs.GetString("userTitle");
	}

	void Update()
	{
		m_Hue = m_SliderHue.value;
		m_Saturation = m_SliderSaturation.value;
		m_Scanlines = m_SliderScanlines.value;
		UpdateColors ();
	}

	void HandleNextButtonPressed()
	{
		PlayerPrefs.SetFloat ("hue", m_Hue);
		PlayerPrefs.SetFloat ("saturation", m_Saturation);
		PlayerPrefs.SetFloat ("scanlines", m_Scanlines);
		SceneManager.LoadScene (1);
	}

	void UpdateColors()
	{
		foreach (TextMeshProUGUI text in _texts) {
			text.color = Color.HSVToRGB(m_Hue, m_Saturation, 1);
		}

		foreach (Image image in _images) {
			image.color = Color.HSVToRGB(m_Hue, m_Saturation, 1);
		}

		ScanlineController.Instance.SetUpScanlines (m_Scanlines);
	}
}
