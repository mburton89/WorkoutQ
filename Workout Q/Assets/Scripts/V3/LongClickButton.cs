using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	private bool pointerIsDown;
	private bool hasLongPressed;
	private float pointerDownTimer;

	public float requiredHoldTime;

	public UnityEvent onPointerDown;
	public UnityEvent onShortClick;
	public UnityEvent onPointerUp;
	public UnityEvent onLongClick;

	//[SerializeField]
	//private Image fillImage;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerIsDown = true;
		hasLongPressed = false;
		if (onPointerDown != null) 
		{
			onPointerDown.Invoke ();
			Debug.Log ("onPointerDown.Invoke ();");
		}	
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!hasLongPressed) 
		{
			if (onPointerUp != null) 
			{
				onPointerUp.Invoke ();
				Debug.Log ("onPointerUp.Invoke ();");
			}	
		}
		//hasLongPressed = false;
		pointerIsDown = false;
		Reset();
		Debug.Log ("OnPointerUp");
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!hasLongPressed) 
		{
			if (onShortClick != null) 
			{
				onShortClick.Invoke ();
				Debug.Log ("onOnPointerClickClick.Invoke ();");
			}	
		}
		//hasLongPressed = false;
		Reset();
		Debug.Log ("OnPointerClick");
	}

	private void Update()
	{
		if (pointerIsDown) 
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer > requiredHoldTime) 
			{
				if (onLongClick != null) 
				{
					hasLongPressed = true;
					onLongClick.Invoke ();
					Debug.Log ("onLongClick.Invoke ();");
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

