using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LineSegment : MonoBehaviour {

	public Image lineImage;
	[SerializeField] private Sprite _lightSprite;
	[SerializeField] private Sprite _darkSprite;

	private const float GLOW_DURATION = .5f;
	private const float FADE_OUT_AMOUNT = 0.5f;

	private Color mediumColor;
	private Color lightColor;

	void OnEnable()
	{
		mediumColor = ColorManager.Instance.ActiveColorMedium;
		lightColor = ColorManager.Instance.ActiveColorLight;
	}

	public void StartBlinking () {
		StartCoroutine ("blinkCo");
	}

	public void StopBlinking () {
		StopCoroutine ("blinkCo");
	}

	public void StartGlowing () {
		StartCoroutine ("GlowCo");
	}

	public void StopGlowing () {
		StopCoroutine ("GlowCo");
	}

	private IEnumerator blinkCo(){
		LightUp ();
		yield return new WaitForSeconds (.5f);
		Darken ();
		yield return new WaitForSeconds (.5f);
		StartBlinking ();
	}

	private IEnumerator GlowCo(){
		GlowIn ();
		yield return new WaitForSeconds (GLOW_DURATION);
		GlowOut ();
		yield return new WaitForSeconds (GLOW_DURATION);
		StartGlowing ();
	}

	public void LightUp(){
		lineImage.sprite = _lightSprite;
		GlowIn ();
	}

	public void Darken(){
		lineImage.sprite = _darkSprite;
	}
		
	void GlowIn()
	{
		lineImage.DOColor (lightColor, GLOW_DURATION);
	}

	void GlowOut()
	{
		lineImage.DOColor (mediumColor, GLOW_DURATION);
	}

	public void UpdateSpriteToWhite()
	{
		lineImage.sprite = _lightSprite;
	}
}
