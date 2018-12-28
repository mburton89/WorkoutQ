using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanel : MonoBehaviour {

	[SerializeField] private Image _fill;
	[SerializeField] private TextMeshProUGUI[] _texts;

	[HideInInspector] public bool isOn;

	public Sprite lightSprite;
	public Sprite darkSprite;

	public void Highlight()
	{
		_fill.sprite = lightSprite;
		foreach (TextMeshProUGUI text in _texts) 
		{
			text.color = Color.black;
		}
	}

	public void Unhighlight()
	{
		_fill.sprite = darkSprite;
		foreach (TextMeshProUGUI text in _texts) 
		{
			text.color = ColorManager.Instance.ActiveColor;
		}
	}

	public void Select(){
		WorkoutManager.Instance.workoutHUD.HandlePanelSelected(this);
	}

	public void Deselect(){
		isOn = false;
		Footer.Instance.Hide();
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
}
