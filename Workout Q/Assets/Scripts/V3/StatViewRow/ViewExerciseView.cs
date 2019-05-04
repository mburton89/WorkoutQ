using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewExerciseView : MonoBehaviour {

	public static ViewExerciseView Instance;

	[SerializeField] private GameObject _container;
	[SerializeField] private TextMeshProUGUI _setsText;
	[SerializeField] private TextMeshProUGUI _repsText;
	[SerializeField] private TextMeshProUGUI _weightLabel;
	[SerializeField] private TextMeshProUGUI _weightText;
	[SerializeField] private TMP_InputField _exerciseName;

	public StatViewRow exerciseViewRow;
	public StatViewRow setsViewRow;

	public FitBoyAnimator fitBoyAnimator;
	[SerializeField] private Image _previousFitBoy;
	[SerializeField] private Image _nextFitBoy;
//	[SerializeField] private LongClickButton _previousFitBoyButton;
//	[SerializeField] private LongClickButton _nextFitBoyButton;

	void Awake()
	{
		Instance = this;
	}

	public void Init(ExerciseData exercise, int currentExerciseIndex, int totalExercises)
	{
		Show ();
		UpdateExerciseView (exercise.name, currentExerciseIndex, totalExercises);
		fitBoyAnimator.Init(exercise.exerciseType);
		_weightLabel.text = PlayerPrefs.GetString ("weightType") + "s";

		_previousFitBoy.color = ColorManager.Instance.ActiveColorDark;
		_nextFitBoy.color = ColorManager.Instance.ActiveColorDark;
	}

	public void Show()
	{
		_container.SetActive (true);
	}

	public void Hide()
	{
		_container.SetActive (false);
	}

	public void UpdateExerciseView(string label, int currentExerciseIndex, int totalExercises)
	{
		if (string.IsNullOrEmpty (label)) {
			_exerciseName.text = "Enter Exercise Name";
		} else {
			_exerciseName.text = label;
		}
		exerciseViewRow.lineSegmenter.ShowSegmentLit (currentExerciseIndex);
	}

	public void UpdateSetsView(string label, int value)
	{
		setsViewRow.UpdateView (label, value);
	}

	public void ShowActiveSet(string label, int currentExerciseIndex)
	{
		setsViewRow.lineSegmenter.ShowSegmentLit (currentExerciseIndex);
	}

	public void UpdateSetsView(int currentSet, int totalSets)
	{
		if (currentSet > totalSets) {
			_setsText.text = "COMPLETE";
		} else {
			_setsText.text = currentSet + " of " + totalSets;
		}
	}

	public void UpdateRepsView(int reps)
	{
		_repsText.text = "x " + reps;
	}

	public void UpdateWeightView(int weight)
	{
		_weightText.text = weight + PlayerPrefs.GetString ("weightType");
	}

	public void UpdateExerciseName(string exerciseName)
	{
		_exerciseName.text = exerciseName;
	}

	public void SetupPreviousFitBoy(Sprite sprite)
	{
		_previousFitBoy.gameObject.SetActive (true);
		_previousFitBoy.sprite = sprite;
	}

	public void HidePreviousFitBoy()
	{
		_previousFitBoy.gameObject.SetActive (false);
	}

	public void SetupNextFitBoy(Sprite sprite)
	{
		_nextFitBoy.gameObject.SetActive (true);
		_nextFitBoy.sprite = sprite;
	}

	public void HideNextFitBoy()
	{
		_nextFitBoy.gameObject.SetActive (false);
	}

	public void HandlePreviousFitBoyPointerDown(){
		if (PlayModeManager.Instance.isPaused) {
			_previousFitBoy.color = ColorManager.Instance.ActiveColorLight;
		}
	}

	public void HandlePreviousFitBoyPointerUp(){
		if (PlayModeManager.Instance.isPaused) {
			_previousFitBoy.color = ColorManager.Instance.ActiveColorDark;
		}
	}

	public void HandlePreviousFitBoyClicked(){
		if (PlayModeManager.Instance.isPaused) {
			Footer.Instance.WorkoutControlsContatiner.HandlePreviousExercisePressed ();
		}
	}

	public void HandleNextFitBoyPointerDown(){
		if (PlayModeManager.Instance.isPaused) {
			_nextFitBoy.color = ColorManager.Instance.ActiveColorLight;
		}
	}

	public void HandleNextFitBoyPointerUp(){
		if (PlayModeManager.Instance.isPaused) {
			_nextFitBoy.color = ColorManager.Instance.ActiveColorDark;
		}
	}

	public void HandleNextFitBoyClicked(){
		if (PlayModeManager.Instance.isPaused) {
			Footer.Instance.WorkoutControlsContatiner.HandleNextExercisePressed ();
		}
	}

	public void Refresh()
	{
		_exerciseName.text = WorkoutManager.Instance.ActiveExercise.name;
		PlayModeManager.Instance.EstablishActiveExercise ();
	}
}
