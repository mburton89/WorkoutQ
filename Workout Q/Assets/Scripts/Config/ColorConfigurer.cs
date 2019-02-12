using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ColorConfigurer : MonoBehaviour {

	float m_Hue;
	float m_Saturation;
	public Slider m_SliderHue, m_SliderSaturation;
	public ShadowTextButton confirmButton;
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

		m_SliderHue.minValue = 0;
		m_SliderSaturation.minValue = 0;

		m_SliderHue.value = PlayerPrefs.GetFloat("hue");
		m_SliderSaturation.value = PlayerPrefs.GetFloat("saturation");

		_headerTitle.text = PlayerPrefs.GetString("userTitle");
	}

	void Update()
	{
		m_Hue = m_SliderHue.value;
		m_Saturation = m_SliderSaturation.value;
		UpdateColors ();
	}

	void HandleNextButtonPressed()
	{
		PlayerPrefs.SetFloat ("hue", m_Hue);
		PlayerPrefs.SetFloat ("saturation", m_Saturation);
		SceneManager.LoadScene (0);
	}

	void UpdateColors(){
		foreach (TextMeshProUGUI text in _texts) {
			text.color = Color.HSVToRGB(m_Hue, m_Saturation, 1);
		}

		foreach (Image image in _images) {
			image.color = Color.HSVToRGB(m_Hue, m_Saturation, 1);
		}
	}
}
