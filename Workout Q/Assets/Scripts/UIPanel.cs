using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {

	[SerializeField]private Image _outline;
	public Toggle toggle;

	public void Select(){
		_outline.gameObject.SetActive(true);
		WorkoutManager.Instance.workoutHUD.HandlePanelSelected(this);
	}

	public void Deselect(){
		toggle.isOn = false;
		_outline.gameObject.SetActive(false);
		Footer.Instance.Hide();
	}

	public void HandleTogglePressed(){
		if(toggle.isOn)
		{
			Select();
		}
		else{
			Deselect();
		}
	}
}
