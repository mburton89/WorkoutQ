using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitBoyAnimator : MonoBehaviour {

	private const float FRAME_RATE = 0.18f;
	public List<Sprite> frames;
	public Image activeFrame;
	//public Image bg;
	private int _frameIndex;
	public ExerciseType exerciseType;

	public void Init(ExerciseType exerciseType)
	{
		this.exerciseType = exerciseType;
		frames = WorkoutGenerator.Instance.GetSpritesForExercise(exerciseType);
		Image[] images = GetComponentsInChildren<Image> ();
		foreach (Image image in images) {
			image.color =  ColorManager.Instance.ActiveColorLight;
		}

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

	public void PlayOnce()
	{
		StartCoroutine("playOnceCo");
	}

	private IEnumerator playOnceCo()
	{
		foreach (Sprite frame in frames) 
		{
			ShowNextFrame();
			yield return new WaitForSeconds(FRAME_RATE);
		}
	}
}
   