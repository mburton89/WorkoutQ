using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSegment : MonoBehaviour {

	public Image lineImage;
	[SerializeField] private Sprite _lightSprite;
	[SerializeField] private Sprite _darkSprite;

	public void StartBlinking () {
		StartCoroutine ("blinkCo");
	}

	public void StopBlinking () {
		StopCoroutine ("blinkCo");
	}

	private IEnumerator blinkCo(){
		LightUp ();
		yield return new WaitForSeconds (.5f);
		Darken ();
		yield return new WaitForSeconds (.5f);
		StartBlinking ();
	}

	public void LightUp(){
		lineImage.sprite = _lightSprite;
	}

	public void Darken(){
		lineImage.sprite = _darkSprite;
	}
}
