using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmartCarouselItem : MonoBehaviour
{
    [HideInInspector] public RectTransform selfRect;
    [HideInInspector] public float absDistanceToCenter;
    [HideInInspector] public float distanceToCenter;
    private List<Sprite> _frames;
    [SerializeField] private Image _activeFrame;

    public void Init(List<Sprite> sprites, Transform parent)
    {
        selfRect = GetComponent<RectTransform>();
        _frames = sprites;

        if(_frames != null)
        {
            _activeFrame.sprite = _frames[0];
        }

        transform.SetParent(parent);
        transform.localScale = Vector3.one;
    }

	public void Init(Transform parent)
	{
		selfRect = GetComponent<RectTransform>();
		transform.SetParent(parent);
		transform.localScale = Vector3.one;
	}
}

