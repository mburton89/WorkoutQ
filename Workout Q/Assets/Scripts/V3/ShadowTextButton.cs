using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ShadowTextButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private RectTransform _rect;
    private Vector2 _initialPosition;
    private float _amountToPress;
	[SerializeField] private TextMeshProUGUI _textShadow;

    public UnityEvent onShortClick;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _initialPosition = _rect.anchoredPosition;
		_amountToPress = 5;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rect.anchoredPosition = new Vector2(_initialPosition.x, _initialPosition.y - _amountToPress);
		_textShadow.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rect.anchoredPosition = _initialPosition;
		_textShadow.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onShortClick != null)
        {
            onShortClick.Invoke();
        }
		SoundManager.Instance.PlayButtonPressSound ();
    }
}