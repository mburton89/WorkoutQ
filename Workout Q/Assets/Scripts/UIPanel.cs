using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanel : MonoBehaviour {

	[SerializeField] private Image _fill;
	[SerializeField] private Image _lineSeperator;
	[SerializeField] private TextMeshProUGUI[] _texts;
	[SerializeField] private Image[] _images;

	[HideInInspector] public bool isOn;

	public Sprite lightSprite;
	public Sprite darkSprite;
	public Sprite blackSprite;
	public GameObject fakeLine;

	public void Highlight()
	{
		_fill.sprite = lightSprite;
		_lineSeperator.sprite = lightSprite;
		foreach (TextMeshProUGUI text in _texts) 
		{
			text.color = Color.black;
		}
		fakeLine.SetActive (true);
	}

	public void Unhighlight()
	{
		_fill.sprite = blackSprite;
		_lineSeperator.sprite = darkSprite;
		foreach (TextMeshProUGUI text in _texts) 
		{
			text.color = ColorManager.Instance.ActiveColor;
		}
		fakeLine.SetActive (false);
	}

	public void Select(){
		WorkoutManager.Instance.workoutHUD.HandlePanelSelected(this);
	}

	public void Deselect(){
		isOn = false;
		Footer.Instance.Hide();
		Unhighlight ();
	}

	public void HandleTogglePressed(){
		if(isOn)
		{
			Select();
		}
		else{
			Deselect();
		}
	}

	public void UpdateColor(){

		Color ActiveColor = ColorManager.Instance.ActiveColor;

		foreach (TextMeshProUGUI text in _texts) {
			text.color = ActiveColor;
		}

		foreach (Image image in _images) {
			image.color = ActiveColor;
		}
	}
}
