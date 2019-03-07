using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitBoyDifficulty : MonoBehaviour {

	public Image activeFrame;

	public void Init(Sprite sprite)
	{
		activeFrame.sprite = sprite;
		activeFrame.color = ColorManager.Instance.ActiveColorLight;
	}
}
