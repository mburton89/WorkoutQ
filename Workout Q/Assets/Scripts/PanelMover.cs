using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour 
{
	private UIPanel _panel;
	private GridLayoutGroup _activeGridLayoutGroup;

	[SerializeField]private Button deleteButton;
	[SerializeField]private Button moveUpButton;
	[SerializeField]private Button moveDownButton;
	[SerializeField]private Button dismissButton;

	void Start()
	{
		_panel = FindObjectOfType<UIPanel>(); //TODO Make this work
		_activeGridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
	}

	void OnEnable()
	{
		moveUpButton.onClick.AddListener(MovePanelUp);
		deleteButton.onClick.AddListener(DeletePanel);
		moveDownButton.onClick.AddListener(MovePanelDown);
		//dismissButton.onClick.AddListener(Hide); //TODO remove the PanelMover object from the panels themselves
	}

	void OnDisable()
	{
		moveUpButton.onClick.RemoveListener(MovePanelUp);
		deleteButton.onClick.RemoveListener(DeletePanel);
		moveDownButton.onClick.RemoveListener(MovePanelDown);
		dismissButton.onClick.RemoveListener(Hide);
	}

	void DeletePanel()
	{
		Destroy(_panel.gameObject);
		WorkoutManager.Instance.Save();
	}

	void MovePanelUp()
	{
		int siblingIndex = _panel.transform.GetSiblingIndex();

		if(siblingIndex > 0)
		{
			_panel.transform.SetSiblingIndex(siblingIndex - 1);
		}
		WorkoutManager.Instance.Save();
	}

	void MovePanelDown()
	{
		int siblingIndex = _panel.transform.GetSiblingIndex();
		int childrenCount = _activeGridLayoutGroup.transform.childCount;

		if(siblingIndex < childrenCount)
		{
			_panel.transform.SetSiblingIndex(siblingIndex + 1);
		}
		WorkoutManager.Instance.Save();
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}
}
