using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SafeArea : MonoBehaviour
{
    RectTransform _rectTransform;
    Rect _safeArea;
    Vector2 _minAnchor;
    Vector2 _maxAnchor;

    void Awake()
    {
        AppSafeArea();
    }

    public void AppSafeArea()
    {
        _rectTransform = GetComponent<RectTransform>();
        _safeArea = Screen.safeArea;
        _minAnchor = _safeArea.position;
        _maxAnchor = _minAnchor + _safeArea.size;

        //모바일 타겟으로 창모드가 될일 없음으로 currentResolution로 적용
        _minAnchor.x /= Screen.currentResolution.width;
        _minAnchor.y /= Screen.currentResolution.height;
        _maxAnchor.x /= Screen.currentResolution.width;
        _maxAnchor.y /= Screen.currentResolution.height;

        _rectTransform.anchorMin = _minAnchor;
        _rectTransform.anchorMax = _maxAnchor;
    }
}
