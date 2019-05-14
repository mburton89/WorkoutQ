using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler//, IEndDragHandler, IDragHandler, IBeginDragHandler 
{
	public bool pointerIsDown;
	private bool hasLongPressed;
	private float pointerDownTimer;

	public float requiredHoldTime;

	public UnityEvent onPointerDown;
	public UnityEvent onShortClick;
	public UnityEvent onPointerUp;
	public UnityEvent onLongClick;

	//[SerializeField]
	//private Image fillImage;

	//[SerializeField]private ScrollRect ScrollRectParent;

//	public void Start()
//	{
//		// find our ScrollRect parent
//		//ScrollRectParent = GetComponentInParent<ScrollRect>();
//	}


	public void OnPointerDown(PointerEventData eventData)
	{
		pointerIsDown = true;
		hasLongPressed = false;
		if (onPointerDown != null) 
		{
			onPointerDown.Invoke ();
		}	
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!hasLongPressed) 
		{
			if (onPointerUp != null) 
			{
				onPointerUp.Invoke ();
			}	
		}
		//hasLongPressed = false;
		pointerIsDown = false;
		Reset();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!hasLongPressed) 
		{
			if (onShortClick != null) 
			{
				onShortClick.Invoke ();
			}	
		}
		//hasLongPressed = false;
		Reset();
	}

//	public void OnDrag(PointerEventData eventData)
//	{
//		if(ScrollRectParent != null)
//			ScrollRectParent.OnDrag(eventData);
//	}
//	public void OnEndDrag(PointerEventData eventData)
//	{
//		if(ScrollRectParent != null)
//			ScrollRectParent.OnEndDrag(eventData);
//
//		Debug.Log ("OnEndDrag");
//
//	}
//	public void OnBeginDrag(PointerEventData eventData)
//	{
//		if(ScrollRectParent != null)
//			ScrollRectParent.OnBeginDrag(eventData);
//	}

	private void Update()
	{
		if (pointerIsDown) 
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer > requiredHoldTime && !hasLongPressed) 
			{
				if (onLongClick != null) 
				{
					hasLongPressed = true;
					onLongClick.Invoke ();
					SoundManager.Instance.PlayButtonPressSound ();
				}
				//Reset();
			}
			//fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
		}
	}

	private void Reset()
	{
		pointerDownTimer = 0f;
		//fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
	}
}

