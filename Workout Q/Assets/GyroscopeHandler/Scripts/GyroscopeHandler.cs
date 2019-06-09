using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroscopeHandler : MonoBehaviour {

	[SerializeField] private Image _overlay;

	void Start()
	{
		Input.gyro.enabled = true;	
	}

	void Update () 
	{
		if (Input.acceleration.y > 0.5f) 
		{
			_overlay.gameObject.SetActive (true);
		} 
		else 
		{
			_overlay.gameObject.SetActive (false);
		}
	}
}
