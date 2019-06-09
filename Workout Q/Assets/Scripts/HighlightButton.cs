using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HighlightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	[SerializeField] private Image _background;
	[SerializeField] private Image _icon;
	[SerializeField] private TextMeshProUGUI _label;
	[SerializeField] private bool _isBlack;

	private Color _darkColor;

	public UnityEvent onClick;

	void Start()
	{
		if (_isBlack) 
		{
			_darkColor = Color.clear; //TODO Find out best solution for light mode
		}
		else 
		{
			_darkColor = ColorManager.Instance.ActiveColorDark;
		}

		Unhighlight ();
	}

	public void Highlight()
	{
		_background.color = ColorManager.Instance.ActiveColorLight;
		_icon.color = Color.black; //TODO Find out best solution for light mode
	
		if (_label != null)
		{
			_label.color = Color.black;  //TODO Find out best solution for light mode
		}
	}

	public void Unhighlight()
	{
		_background.color = _darkColor;
		_icon.color = ColorManager.Instance.ActiveColorLight;

		if (_label != null) 
		{
			_label.color = ColorManager.Instance.ActiveColorLight;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Highlight ();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Unhighlight ();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (onClick != null) 
		{
			onClick.Invoke ();
			SoundManager.Instance.PlayButtonPressSound ();
		}	
	}
}
