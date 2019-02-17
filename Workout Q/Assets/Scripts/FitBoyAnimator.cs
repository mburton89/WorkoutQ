using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitBoyAnimator : MonoBehaviour {

	private const float FRAME_RATE = 0.18f;
	public List<Sprite> frames;
	public Image activeFrame;
	private int _frameIndex;

	public void Init(List<Sprite> sprites)
	{
		frames = sprites;
		activeFrame.color = ColorManager.Instance.ActiveColor;
		Play();
	}

	public void Play()
	{
		_frameIndex = 0;
		StopCoroutine("playAnimationCo");
		StartCoroutine("playAnimationCo");
	}
    
    public void Stop()
	{
		StopCoroutine("playAnimationCo");
	}

	private IEnumerator playAnimationCo()
	{
		ShowNextFrame();
		yield return new WaitForSeconds(FRAME_RATE);
		StartCoroutine("playAnimationCo");
	}

	void ShowNextFrame()
	{
		if (_frameIndex >= frames.Count)
		{
			_frameIndex = 0;
		}

		activeFrame.sprite = frames[_frameIndex];
		_frameIndex++;
	}
}
   