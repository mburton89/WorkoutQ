using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FitBoyIlluminator : MonoBehaviour {

	private const float GLOW_DURATION = .5f;
	private const float FADE_OUT_AMOUNT = 0f;
	[HideInInspector] public Sprite glowFrameSprite;
	public Image activeFrame;
	public Image fitBotBase;

	public void Init(Sprite sprite)
	{
		StopCoroutine("playAnimationCo");
		glowFrameSprite = sprite;
		activeFrame.sprite = glowFrameSprite;
		activeFrame.color = ColorManager.Instance.ActiveColor;
		fitBotBase.color = ColorManager.Instance.ActiveColor;
		Play();
	}

	public void Play()
	{
		StartCoroutine("playAnimationCo");
	}

	public void Stop()
	{
		StopCoroutine("playAnimationCo");
	}

	private IEnumerator playAnimationCo()
	{
		GlowIn();
		yield return new WaitForSeconds(GLOW_DURATION);
		GlowOut();
		yield return new WaitForSeconds(GLOW_DURATION);
		StartCoroutine("playAnimationCo");
	}

	void GlowIn()
	{
		activeFrame.DOFade (1, GLOW_DURATION);
	}

	void GlowOut()
	{
		activeFrame.DOFade (FADE_OUT_AMOUNT, GLOW_DURATION);
	}
}
