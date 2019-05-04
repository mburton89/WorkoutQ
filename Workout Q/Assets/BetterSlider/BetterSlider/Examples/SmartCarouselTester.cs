using System.Collections.Generic;
using UnityEngine;

public class SmartCarouselTester : MonoBehaviour
{
    [SerializeField] private SmartCarousel _smartCarousel;
    [SerializeField] private LineSegmenter _lineSegmenter;
    [SerializeField] private SliderScrollBarHandle _sliderHandle;

    public List<Sprite> spriteList1;

    private List<List<Sprite>> _spriteLists;

    public int numberOfSpriteListsToGenerate;

    private void Awake()
    {
        _spriteLists = new List<List<Sprite>>();

        for (int i = 0; i < numberOfSpriteListsToGenerate; i++)
        {
            List<Sprite> newSpriteList = new List<Sprite>();
            newSpriteList = spriteList1;

            _spriteLists.Add(newSpriteList);
        }

        _smartCarousel.Init(_spriteLists, 5);
        _lineSegmenter.Init(_spriteLists.Count);
    }

//    private void Start()
//    {
//        print(_lineSegmenter.lineSegments[0].GetComponent<RectTransform>().sizeDelta.x);
//        print(_lineSegmenter.lineSegments[0].GetComponent<RectTransform>().sizeDelta.y);
//
//        float handleWidth = _lineSegmenter.lineSegments[0].GetComponent<RectTransform>().sizeDelta.x + (_lineSegmenter.GetHorizontalLayoutGroup().spacing * 2);
//        float handleHeight = _lineSegmenter.lineSegments[0].GetComponent<RectTransform>().sizeDelta.y * 3;
//
//        _sliderHandle.Init(handleWidth, handleHeight);
//    }
}
