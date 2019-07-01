using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour 
{
	int index;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			string screenshotFileName = "_321FITScreenshot_" + index + ".PNG";
			print (screenshotFileName + " Captured");
			ScreenCapture.CaptureScreenshot(screenshotFileName);
			index++;
		}	
	}
}
