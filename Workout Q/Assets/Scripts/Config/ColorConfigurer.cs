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
	public Button nextButton;
	[SerializeField] private TextMeshProUGUI[] _texts;
	[SerializeField] private Image[] _images;

	void OnEnable()
	{
		nextButton.onClick.AddListener (HandleNextButtonPressed);
	}

	void OnDisable()
	{
		nextButton.onClick.RemoveListener(HandleNextButtonPressed);
	}

	void Start()
	{
		m_SliderHue.maxValue = 1;
		m_SliderSaturation.maxValue = 1;

		m_SliderHue.minValue = 0;
		m_SliderSaturation.minValue = 0;

		m_SliderHue.value = PlayerPrefs.GetFloat("hue");
		m_SliderSaturation.value = PlayerPrefs.GetFloat("saturation");
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
