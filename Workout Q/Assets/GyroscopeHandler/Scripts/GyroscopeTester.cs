using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GyroscopeTester : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _variableX;
	[SerializeField] private TextMeshProUGUI _variableY;
	[SerializeField] private TextMeshProUGUI _variableZ;

	void Start () 
	{
		Input.gyro.enabled = true;
	}

	void Update () 
	{
		_variableX.text = Input.acceleration.x.ToString();
		_variableY.text = Input.acceleration.y.ToString();
		_variableZ.text = Input.acceleration.z.ToString();
	}
}
