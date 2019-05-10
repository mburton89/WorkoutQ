using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SetsDisplaySegment : MonoBehaviour 
{
	[SerializeField] private TextMeshProUGUI _label;
	[SerializeField] private Image _fillLine;

	private const float GLOW_DURATION = .5f;

	public void Init(int setNumber, bool shouldShowWord)
	{
		if (shouldShowWord) 
		{
			_label.text = "Set " + setNumber;
		}
		else 
		{
			_label.text = setNumber.ToString();
		}
			
		DarkenText ();
		_fillLine.color = ColorManager.Instance.ActiveColorDark;
	}

	public void UpdateFillValue(float fillValue)
	{
		_fillLine.fillAmount = fillValue;
	}

	public void StartGlowing () 
	{
		UpdateFillValue (1f);
		StartCoroutine ("GlowCo");
	}

	public void StopGlowing () 
	{
		StopCoroutine ("GlowCo");
	}

	private IEnumerator GlowCo()
	{
		GlowIn ();
		yield return new WaitForSeconds (GLOW_DURATION);
		GlowOut ();
		yield return new WaitForSeconds (GLOW_DURATION);
		StartGlowing ();
	}

	void GlowIn()
	{
		_fillLine.DOColor (ColorManager.Instance.ActiveColorLight, GLOW_DURATION);
	}

	void GlowOut()
	{
		_fillLine.DOColor (ColorManager.Instance.ActiveColorDark, GLOW_DURATION);
	}

	public void LightUpText()
	{
		_label.color = ColorManager.Instance.ActiveColorLight;
	}

	public void DarkenText()
	{
		_label.color = ColorManager.Instance.ActiveColorDark;
	}

	public void ShowAsActive()
	{
		StartGlowing ();
		LightUpText ();
	}

	public void ShowAsComplete()
	{
		StopGlowing ();
		DarkenText ();
		GlowIn ();
	}

	public void ShowAsIncomplete()
	{
		StopGlowing ();
		DarkenText ();
		GlowOut ();
	}

	public void HideTextLabel()
	{
		_label.gameObject.SetActive (false);
	}

	public void ShowTextLabel()
	{
		_label.gameObject.SetActive (true);
	}
}
