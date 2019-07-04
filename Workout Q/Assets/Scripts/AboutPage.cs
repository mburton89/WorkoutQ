using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AboutPage : MonoBehaviour 
{
	[SerializeField] private GameObject _container;
	[SerializeField] private Button _d10Button;
	[SerializeField] private ShadowButton _reviewButton;
	[SerializeField] private ShadowButton _instagramButton;
	[SerializeField] private GameObject _buttonsContainer;
	[SerializeField] private TextMeshProUGUI _textBody;

	void Start()
	{
		_textBody.color = ColorManager.Instance.ActiveColorLight;	
	}

	public void Open()
	{
		_container.SetActive (true);
		_buttonsContainer.SetActive (true);
		_d10Button.onClick.AddListener (HandleD10ButtonPressed);
		_reviewButton.onShortClick.AddListener (HandleReviewButtonPressed);
		_instagramButton.onShortClick.AddListener (HandleInstagramButtonPressed);
	}

	public void Close()
	{
		_container.SetActive (false);
		_buttonsContainer.SetActive (false);
		_d10Button.onClick.RemoveListener (HandleD10ButtonPressed);
		_reviewButton.onShortClick.RemoveListener (HandleReviewButtonPressed);
		_instagramButton.onShortClick.RemoveListener (HandleInstagramButtonPressed);
	}

	void HandleD10ButtonPressed()
	{
		//Application.OpenURL ("https://chicago.thed10.com/competitors/1222");
		Application.OpenURL ("https://www.instagram.com/321FITapp/");
	}

	void HandleReviewButtonPressed()
	{
		#if UNITY_ANDROID
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.MatthewBurton.WorkoutQ");
		#else
		Application.OpenURL ("https://apps.apple.com/us/app/321FIT/id1435831475");
		#endif
	}

	void HandleInstagramButtonPressed()
	{
		Application.OpenURL ("https://www.instagram.com/thundersneeze/");
	}
}
