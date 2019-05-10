using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelectHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[HideInInspector] public bool pointerIsDown;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerIsDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pointerIsDown = false;
	}
}
