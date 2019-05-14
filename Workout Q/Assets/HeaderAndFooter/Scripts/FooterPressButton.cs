using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FooterPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private RectTransform _rect;
	private Vector2 _initialPosition;
	private float _amountToPress = 10f;

	void Awake()
	{
		_rect = GetComponent<RectTransform>();
		_initialPosition = _rect.anchoredPosition;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_rect.anchoredPosition = new Vector2(_initialPosition.x, _initialPosition.y - _amountToPress);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_rect.anchoredPosition = _initialPosition;
	}
}