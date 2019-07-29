using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SplashAnimationController : MonoBehaviour 
{
	[SerializeField] private GameObject _container;

	[SerializeField] private TextMeshProUGUI _text3;
	[SerializeField] private TextMeshProUGUI _text2;
	[SerializeField] private TextMeshProUGUI _text1;
	[SerializeField] private TextMeshProUGUI _textF;
	[SerializeField] private TextMeshProUGUI _textI;
	[SerializeField] private TextMeshProUGUI _textT;

	[SerializeField] private Image _outerClockBG;
	[SerializeField] private Image _outerClock;
	[SerializeField] private Image _squatDudeBG;
	[SerializeField] private Image _squatDude;
	[SerializeField] private Image _blackFadeOverlay;

	public float NUMBER_LIGHTUP_DURATION;
	public float NUMBER_TO_LETTER_DURATION;

	public Color _initialColor;
	public Color _selectedColor;

	[SerializeField] private FitBoyAnimator _fitBoy;

	private const string PHRASE_1 = "Loading all the fitness...";
	private const string PHRASE_2 = "Optimizing for mad gainz...";
	private const string PHRASE_3 = "SUCCESS...";
	private const string PHRASE_4 = "Have a kick butt workout! :D...";

	[SerializeField] private TextMeshProUGUI _loadingText;

	void Start()
	{
//		_initialColor = ColorManager.Instance.ActiveColorDark;
//		_selectedColor = ColorManager.Instance.ActiveColorLight;
		ResetAnimation ();
		PlayWholeShebang ();
	}

//	void Update () 
//	{
//		if (Input.GetKeyDown (KeyCode.R)) 
//		{
//			ResetAnimation ();
//		}	
//
//		if (Input.GetKeyDown (KeyCode.P)) 
//		{
//			PlayWholeShebang ();
//		}	
//	}

	void Play321FITTextSequence()
	{
		StartCoroutine (Play321FITTextSequenceCo());
	}

	private IEnumerator Play321FITTextSequenceCo()
	{
		_text3.color = _selectedColor;
		//SoundManager.Instance.PlayCountDownBeep ();
		SoundManager.Instance.PlaySplashIntro();
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION);
		_text2.color = _selectedColor;
		//SoundManager.Instance.PlayCountDownBeep ();
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION);
		_text1.color = _selectedColor;
		//SoundManager.Instance.PlayCountDownBeep ();
		_loadingText.text = PHRASE_2;
		yield return new WaitForSeconds (NUMBER_TO_LETTER_DURATION);
		SoundManager.Instance.PlayLevelUpSound ();
		_textF.color = _selectedColor;
		_squatDude.fillAmount = 0.3435f;
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION);
		_textI.color = _selectedColor;
		_squatDude.fillAmount = 0.687f;
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION);
		_textT.color = _selectedColor;
		_squatDude.fillAmount = 1f;
		_squatDudeBG.gameObject.SetActive (false);
		KickOffSquatDude ();
		_loadingText.text = PHRASE_3;
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION);
		_loadingText.text = PHRASE_4;
		yield return new WaitForSeconds (1);
		//_container.SetActive (false);
		SceneManager.LoadScene (1);
	}

	void Play321FITLogoSequence()
	{
		StartCoroutine (Play321FITLogoSequenceCo());
	}

	private IEnumerator Play321FITLogoSequenceCo()
	{
		_outerClock.DOFillAmount (1, NUMBER_LIGHTUP_DURATION * 3);
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION);
	}

	void KickOffSquatDude()
	{
		//_squatDude.color = _selectedColor;
		_fitBoy.PlayOnce ();
	}

	void ResetAnimation()
	{
		_container.SetActive (true);

		_text3.color = _initialColor;
		_text2.color = _initialColor;
		_text1.color = _initialColor;
		_textF.color = _initialColor;
		_textI.color = _initialColor;
		_textT.color = _initialColor;
		_squatDudeBG.gameObject.SetActive (true);
		_outerClock.fillAmount = 0;
		_squatDude.fillAmount = 0;
		_fitBoy.Stop ();
		_blackFadeOverlay.color = Color.black;

		_squatDudeBG.color = _initialColor;
		_squatDude.color = _selectedColor;
		_outerClockBG.color = _initialColor;
		_outerClock.color = _selectedColor;
		_loadingText.color = _selectedColor;
		_loadingText.text = PHRASE_1;
	}

	void PlayWholeShebang()
	{
		StartCoroutine (PlayWholeShebangCo());
	}

	private IEnumerator PlayWholeShebangCo()
	{
		_blackFadeOverlay.DOFade (0, NUMBER_TO_LETTER_DURATION);
		yield return new WaitForSeconds (NUMBER_LIGHTUP_DURATION * 2);
		Play321FITTextSequence ();
		Play321FITLogoSequence ();
	}
}
