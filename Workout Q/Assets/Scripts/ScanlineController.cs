using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScanlineController : MonoBehaviour 
{
	public static ScanlineController Instance;

	[SerializeField] private List<Image> _scanlines;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		SetUpScanlines (PlayerPrefs.GetFloat("scanlines"));

		if (SceneManager.GetActiveScene().buildIndex == 1 && PlayerPrefs.GetFloat("scanlines") == 0f) 
		{
			gameObject.SetActive (false);
		}
	}

	public void SetUpScanlines(float amount)
	{
		Color updatedColor = _scanlines[0].color;

		foreach (Image scanline in _scanlines)
		{
			scanline.color = new Color (updatedColor.r, updatedColor.g, updatedColor.b, amount);
		}
	}
}
