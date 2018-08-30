using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour 
{
	private UIPanel _panel;
	private GridLayoutGroup _activeGridLayoutGroup;

	[SerializeField]private Button moveUpButton;
	[SerializeField]private Button deleteButton;
	[SerializeField]private Button moveDownButton;

	void Start()
	{
		_panel = GetComponentInParent<UIPanel>();
		_activeGridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
	}

	void OnEnable()
	{
		moveUpButton.onClick.AddListener(MovePanelUp);
		deleteButton.onClick.AddListener(DeletePanel);
		moveDownButton.onClick.AddListener(MovePanelDown);
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

	void DeletePanel()
	{
		Destroy(_panel.gameObject);
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
}
