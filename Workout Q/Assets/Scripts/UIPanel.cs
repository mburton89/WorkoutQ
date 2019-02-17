using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanel : MonoBehaviour {

	[SerializeField] private Image _fill;
	[SerializeField] private Image _lineSeperator;
	[SerializeField] private TextMeshProUGUI _mainText;
	[SerializeField] private TextMeshProUGUI _placeHolderText;
	[SerializeField] private TextMeshProUGUI _secondaryText;
	[SerializeField] private Image[] _images;

	[HideInInspector] public bool isOn;

	public Sprite lightSprite;
	public Sprite darkSprite;
	public Sprite blackSprite;
	public GameObject fakeLine;

	private const float DARKENER_DIVIDER = 1.75f;

	public void Highlight()
	{
		_fill.sprite = lightSprite;
		_lineSeperator.sprite = lightSprite;
		_mainText.color = Color.black;
		_secondaryText.color = Color.black;
		fakeLine.SetActive (true);
	}

	public void Unhighlight()
	{
		Color primaryColor = ColorManager.Instance.ActiveColor;
		Color secondaryColor = new Color (primaryColor.r / DARKENER_DIVIDER, primaryColor.g / DARKENER_DIVIDER, primaryColor.b / DARKENER_DIVIDER);

		_fill.sprite = blackSprite;
		_lineSeperator.sprite = darkSprite;
		_mainText.color = primaryColor;
		_placeHolderText.color = primaryColor;
		_secondaryText.color = secondaryColor;
		fakeLine.SetActive (false);
	}

	public void Select()
	{
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

		Color primaryColor = ColorManager.Instance.ActiveColor;
		Color secondaryColor = new Color (primaryColor.r / DARKENER_DIVIDER, primaryColor.g / DARKENER_DIVIDER, primaryColor.b / DARKENER_DIVIDER);

		_mainText.color = primaryColor;
		_placeHolderText.color = primaryColor;
		_secondaryText.color = secondaryColor;

		foreach (Image image in _images) {
			image.color = primaryColor;
		}
	}
}
