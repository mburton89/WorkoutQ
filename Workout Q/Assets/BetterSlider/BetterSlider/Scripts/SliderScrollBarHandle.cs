using UnityEngine;

public class SliderScrollBarHandle : MonoBehaviour
{
    private RectTransform _handleRect;

    public void Init(float width, float height)
    {
        _handleRect = GetComponent<RectTransform>();
        Vector2 handleSize = new Vector2(width, height);
        _handleRect.sizeDelta = handleSize;
    }
}
