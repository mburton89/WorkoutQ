using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetsDisplayController : MonoBehaviour 
{
	private WorkoutPlayerController _controller;

	private List<SetsDisplaySegment> _setDisplaySegments;
	private SetsDisplaySegment _activeSetDisplaySegment;

	[SerializeField] SetsDisplaySegment _setDisplaySegmentPrefab;
	[SerializeField] Transform _segmentParent;
    [SerializeField] TextMeshProUGUI _completeLabel;
    [SerializeField] TextMeshProUGUI _introTimerText;
    [SerializeField] GameObject _introTimerContainer;
	[SerializeField] Image _radialFill;
	[SerializeField] Image _radialFillBG;
    [SerializeField] Image _radialFillInner;

    private const string INTRO_TIMER_PREFIX = "Starts in ";

    [HideInInspector] public float secondsRemaining;
    [HideInInspector] public bool isInIntroTimerMode;

    public void Init(WorkoutPlayerController controller, int totalSets)
	{
		_controller = controller;

		Clear ();

		_setDisplaySegments = new List<SetsDisplaySegment> ();

		bool shouldShowWord = false;

		if (totalSets < 6) 
		{
			shouldShowWord = true;
		}

		for (int i = 0; i < totalSets; i++) 
		{
			SetsDisplaySegment newSetDisplaySegment = Instantiate (_setDisplaySegmentPrefab, _segmentParent);
			newSetDisplaySegment.Init (i + 1, shouldShowWord);
			_setDisplaySegments.Add (newSetDisplaySegment);
		}

		_completeLabel.color = ColorManager.Instance.ActiveColorLight;
        _introTimerText.color = ColorManager.Instance.ActiveColorLight;
        _radialFill.color = ColorManager.Instance.ActiveColorLight;
		_radialFillBG.color = ColorManager.Instance.ActiveColorDark;
        _radialFillInner.color = Color.black;
    }

    void Update()
    {
        if (isInIntroTimerMode)
        {
            DeductTime();
        }
    }

    public void Clear()
	{
		if (_setDisplaySegments != null) 
		{
			foreach (SetsDisplaySegment setDisplaySegment in _setDisplaySegments)
			{
				Destroy (setDisplaySegment.gameObject);
			}
			_setDisplaySegments.Clear ();
		}

		HideCompleteTextLabel ();
	}

	public void ShowSetActive(int setNumber)
	{
		if (setNumber > _setDisplaySegments.Count)
		{
			MarkAllSetsComplete ();
			return;
		} 
		else
		{
			HideCompleteTextLabel ();
			foreach (SetsDisplaySegment segment in _setDisplaySegments) 
			{
				segment.ShowTextLabel ();
			}
		}

		for (int i = 0; i < setNumber; i++)
		{
			_setDisplaySegments [i].ShowAsComplete ();
		}

		for (int i = _setDisplaySegments.Count; i > setNumber; i--)
		{
			_setDisplaySegments [i - 1].ShowAsIncomplete ();
		}

		_activeSetDisplaySegment = _setDisplaySegments [setNumber - 1];
		_activeSetDisplaySegment.StartGlowing ();
		_activeSetDisplaySegment.LightUpText ();

        if (_controller.initialSecondsBetweenExercises > 0 && setNumber == 1)
        {
            StartIntroTimer();
        }
        else 
        {
            StopIntroTimer();
        }
    }

	public void MarkAllSetsComplete()
	{
		foreach (SetsDisplaySegment segment in _setDisplaySegments) 
		{
			segment.ShowAsComplete ();
			segment.HideTextLabel ();
		}

		ShowCompleteTextLabel ();
	}

	public void HideCompleteTextLabel()
	{
		_completeLabel.gameObject.SetActive (false);
	}

	public void ShowCompleteTextLabel()
	{
		_completeLabel.gameObject.SetActive (true);
	}

    void StartIntroTimer()
    {
        secondsRemaining = _controller.initialSecondsBetweenExercises;
        _introTimerContainer.SetActive(true);
		_radialFillBG.gameObject.SetActive(true);
		_radialFill.gameObject.SetActive(true);
        isInIntroTimerMode = true;
    }

    public void StopIntroTimer()
    {
        _introTimerContainer.SetActive(false);
        isInIntroTimerMode = false;
		_radialFillBG.gameObject.SetActive(false);
		_radialFill.gameObject.SetActive(false);
        secondsRemaining = _controller.initialSecondsBetweenExercises;
    }

    public void UpdateIntroTimerValue(float timeValue)
    {
        int minutes = (int)timeValue / 60;
        int seconds = (int)timeValue % 60;
        string secondsString;

        if (seconds < 10)
        {
            secondsString = "0" + seconds.ToString();
        }
        else
        {
            secondsString = seconds.ToString();
        }

        _introTimerText.text = INTRO_TIMER_PREFIX + minutes + ":" + secondsString;

		_radialFill.fillAmount = 1 - (timeValue / _controller.initialSecondsBetweenExercises);
    }

    void DeductTime()
    {
        secondsRemaining -= Time.deltaTime;

        UpdateIntroTimerValue(secondsRemaining);

        if (secondsRemaining < 0)
        {
            HandleTimerHittingZero();
        }
    }

    void HandleTimerHittingZero()
    {
        SoundManager.Instance.PlayNewExerciseSound();
        StopIntroTimer();
        _controller.Play();
    }
}
