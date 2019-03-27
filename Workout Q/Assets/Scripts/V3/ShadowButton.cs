using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShadowButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	[SerializeField] private Image _buttonTop;
	[SerializeField] private Image _buttonShadow;
    private RectTransform _rect;
	private Vector2 _initialPosition;
	[SerializeField] private float _amountToPress;

	public UnityEvent onPointerDown;
	public UnityEvent onPointerUp;
    public UnityEvent onShortClick;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _initialPosition = _rect.anchoredPosition;
    }

	void Start()
	{
		_buttonTop.color = ColorManager.Instance.ActiveColorLight;
		_buttonShadow.color = ColorManager.Instance.ActiveColorMedium;
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        _rect.anchoredPosition = new Vector2(_initialPosition.x, _initialPosition.y - _amountToPress);
        _buttonShadow.enabled = false;

		if (onPointerDown != null) 
        {
			onPointerDown.Invoke ();
        }   
    }

    public void OnPointerUp(PointerEventData eventData)
    {
		_rect.anchoredPosition = _initialPosition;
        _buttonShadow.enabled = true; 

		if (onPointerUp != null) 
        {
			onPointerUp.Invoke ();
        }   
    }

	public void OnPointerClick(PointerEventData eventData)
    {
		if (onShortClick != null) 
        {
            onShortClick.Invoke ();
        }  
		SoundManager.Instance.PlayButtonPressSound ();
    }
}