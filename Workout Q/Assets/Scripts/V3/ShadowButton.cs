using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShadowButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private Image _buttonShadow;
    private RectTransform _rect;
    private Vector2 _initialPosition;
    [SerializeField] private float _amountToPress;

    public UnityEvent onShortClick;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _initialPosition = _rect.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rect.anchoredPosition = new Vector2(_initialPosition.x, _initialPosition.y - _amountToPress);
        _buttonShadow.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rect.anchoredPosition = _initialPosition;
        _buttonShadow.enabled = true; 
    }

	public void OnPointerClick(PointerEventData eventData)
    {
		if (onShortClick != null) 
        {
            onShortClick.Invoke ();
        }   
    }
}