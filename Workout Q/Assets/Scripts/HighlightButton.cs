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

	public UnityEvent onClick;

	void Start()
	{
		Unhighlight ();
	}

	public void Highlight()
	{
		_background.color = ColorManager.Instance.ActiveColorLight;
		_icon.color = ColorManager.Instance.ActiveColorDark;
	
		if (_label != null)
		{
			_label.color = ColorManager.Instance.ActiveColorDark;
		}
	}

	public void Unhighlight()
	{
		_background.color = ColorManager.Instance.ActiveColorDark;
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
		}	
	}
}
