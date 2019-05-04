using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelectHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[HideInInspector] public bool pointerIsDown;
	[SerializeField] private Image _handle;
	private RectTransform _handleRect;
	private Vector2 _handleInitialPosition;
	[SerializeField] private float _amountToPress;
	[SerializeField] private Image _handleShadow;

	void Awake()
	{
		_handleRect = _handle.GetComponent<RectTransform>();
		_handleInitialPosition = _handleRect.anchoredPosition;
	}

	void OnEnable()
	{
		//_handleShadow.color = ColorManager.Instance.ActiveColorMedium;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//pause playmode
		pointerIsDown = true;
		Debug.Log ("OnPointerDown");

		//_handleRect.anchoredPosition = new Vector2(_handleInitialPosition.x, _handleInitialPosition.y - _amountToPress);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pointerIsDown = false;
		Debug.Log ("OnPointerUp");

		//_handleRect.anchoredPosition = _handleInitialPosition;
	}
}
