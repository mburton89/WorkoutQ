using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class SmartCarousel : MonoBehaviour
{
    [SerializeField] private SmartCarouselItem _carouselItemPrefab;
    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
    [SerializeField] private RectTransform _scrollPanel;
    [SerializeField] private RectTransform _center;
    private List<SmartCarouselItem> _carouselItems = new List<SmartCarouselItem>();
    private SmartCarouselItem _centermostCarouselItem;
    private bool _isDragging;
	private int _activeIndex;

	private const float INIT_DURATION = 0.1f;
    private const float SNAP_SPEED = 0.5f;
	private const float FLICK_BUFFER_TIME = .3f;

	public UnityEvent onEndDrag;

#if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            TweenToItemByIndex(0);
        }
    }
#endif

    public void Init(List<List<Sprite>> spriteLists, int currentIndex)
    {
		TryClear ();

        foreach (List<Sprite> sprites in spriteLists)
        {
            SmartCarouselItem newCarouselItem = CreateCarouselItem(sprites);
            _carouselItems.Add(newCarouselItem);
        }

        _centermostCarouselItem = _carouselItems[0];

        StartCoroutine(TweenToItemByIndexCo(currentIndex));
    }

	public void Init(WorkoutData workout, int currentIndex)
	{
		TryClear ();

		foreach (ExerciseData exercise in workout.exerciseData) 
		{
			SmartCarouselItem newCarouselItem = CreateCarouselItem(exercise);
			_carouselItems.Add(newCarouselItem);
		}

		_centermostCarouselItem = _carouselItems[0];

		StartCoroutine(TweenToItemByIndexCo(currentIndex));
	}

    private SmartCarouselItem CreateCarouselItem(List<Sprite> sprites)
    {
        SmartCarouselItem newCarouselItem = Instantiate(_carouselItemPrefab);
        newCarouselItem.Init(sprites, _horizontalLayoutGroup.transform);
        return newCarouselItem;
    }

	private SmartCarouselItem CreateCarouselItem(ExerciseData exercise)
	{
		SmartCarouselItem newCarouselItem = Instantiate(_carouselItemPrefab);
		FitBoyAnimator fitBoyAnimator = newCarouselItem.GetComponent<FitBoyAnimator> ();
		fitBoyAnimator.Init (exercise.exerciseType);
		newCarouselItem.Init(_horizontalLayoutGroup.transform);
		return newCarouselItem;
	}

//    private void DetermineCenterMostItem()
//    {
//        foreach (SmartCarouselItem carouselItem in _carouselItems)
//        {
//			carouselItem.absDistanceToCenter = Mathf.Abs(_center.position.x - carouselItem.selfRect.position.x);
//            carouselItem.distanceToCenter = _center.position.x - carouselItem.selfRect.position.x;
//        }
//
//        foreach (SmartCarouselItem carouselItem in _carouselItems)
//        {
//            if (carouselItem.absDistanceToCenter < _centermostCarouselItem.absDistanceToCenter)
//            {
//                _centermostCarouselItem = carouselItem;
//            }
//        }
//    }

	private void DetermineCenterMostItem()
	{
		for(int i = 0; i < _carouselItems.Count; i++)
		{
			SmartCarouselItem carouselItem = _carouselItems [i];
			carouselItem.absDistanceToCenter = Mathf.Abs(_center.position.x - carouselItem.selfRect.position.x);
			carouselItem.distanceToCenter = _center.position.x - carouselItem.selfRect.position.x;
		}

		for(int i = 0; i < _carouselItems.Count; i++)
		{
			SmartCarouselItem carouselItem = _carouselItems [i];
			if (carouselItem.absDistanceToCenter < _centermostCarouselItem.absDistanceToCenter)
			{
				_centermostCarouselItem = carouselItem;
				_activeIndex = i;
			}
		}
	}

    public void StartDrag()
    {
        _isDragging = true;
    }

	public void EndDrag()
	{
		_isDragging = false;
		DetermineCenterMostItem();
		TweenToCenterMostItem();

		if (onEndDrag != null) 
		{
			onEndDrag.Invoke ();
		}
	}

    public void TweenToItemByIndex(int index)
    {
        _carouselItems[index].distanceToCenter = _center.position.x - _carouselItems[index].selfRect.position.x;
        _scrollPanel.transform.DOMoveX(_scrollPanel.transform.position.x + _carouselItems[index].distanceToCenter, SNAP_SPEED);
    }

    void TweenToCenterMostItem()
    {
        _scrollPanel.transform.DOMoveX(_scrollPanel.transform.position.x + _centermostCarouselItem.distanceToCenter, SNAP_SPEED);
    }

    private IEnumerator TweenToItemByIndexCo(int index)
    {
        yield return new WaitForSeconds(INIT_DURATION);
        TweenToItemByIndex(index);
    }

	public int GetActiveIndex()
	{
		return _activeIndex;
	}

	void TryClear()
	{
		if (_carouselItems != null) 
		{
			foreach (SmartCarouselItem item in _carouselItems)
			{
				Destroy (item.gameObject);
			}
			_carouselItems.Clear ();
		}
	}
}
