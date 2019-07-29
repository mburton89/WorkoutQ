using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WorkoutCompletionController : MonoBehaviour 
{
	[SerializeField] private FitBoyAnimator _fitBoy;
	[SerializeField] private TextMeshProUGUI _title;
	[SerializeField] private TextMeshProUGUI _body;
	[SerializeField] private ShadowButton _doneButton;
	[SerializeField] private ShadowButton _reviewButton;
	[SerializeField] private List<Image> _images;
	[SerializeField] private Button _overlay;

	public void Init()
	{
		transform.SetParent (WorkoutHUD.Instance.transform);
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.one;

		_fitBoy.Init (ExerciseType._custom);
		_title.text = GetRandomTitle ();

		foreach (Image colorImage in _images)
		{
			colorImage.color = ColorManager.Instance.ActiveColorLight;
		}

		_body.color = ColorManager.Instance.ActiveColorLight;

		StartCoroutine (playAirhornDelayed());
	}

	void OnEnable()
	{
		_doneButton.onShortClick.AddListener (HandleDonePressed);
		_reviewButton.onShortClick.AddListener (HandleReviewPressed);
		_overlay.onClick.AddListener(Exit);
	}

	void OnDisable()
	{
		_doneButton.onShortClick.RemoveListener (HandleDonePressed);
		_reviewButton.onShortClick.AddListener (HandleReviewPressed);
		_overlay.onClick.AddListener(Exit);
	}

	void HandleDonePressed()
	{
		WorkoutManager.Instance.ActiveWorkout.Reset ();
		WorkoutManager.Instance.Save ();
		FooterV2.Instance.HandleBACKTOWORKOUTButtonPressed ();
		Exit ();
	}

	string GetRandomTitle()
	{
		int phraseInt = Random.Range (0, 7);

		if (phraseInt == 1) {
			return "Booyah";
		} else if (phraseInt == 2) {
			return "Heck yea";
		} else if (phraseInt == 3) {
			return "Woot";
		} else if (phraseInt == 4) {
			return "Got eem!";
		} else if (phraseInt == 5) {
			return "Mad Gainz";
		}else {
			return "Aww yea";
		}
	}

	void Exit()
	{
		Destroy (gameObject);
	}

	private IEnumerator playAirhornDelayed()
	{
		yield return new WaitForSeconds (0.2f);
		SoundManager.Instance.PlayAirHorn ();
	}

	private void HandleReviewPressed()
	{
		#if UNITY_ANDROID
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.matthewburton.workoutq");
		#else
		Application.OpenURL ("https://apps.apple.com/us/app/321FIT/id1435831475");
		#endif
	}
}
