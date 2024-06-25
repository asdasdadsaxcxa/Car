using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
    [SerializeField] Layer TargetLayer;

    internal bool VisControll = true;
    //초기 세팅
    public virtual void Init()
    {

    }

    //Background , SafeArea
    public virtual void Show()
    {
        this.gameObject.SetActive(true);
        SetLayer();
        if (VisControll)
            UIAdmin.Instance.UIViewControll.Showing(this);
    }

    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
        if (VisControll)
            UIAdmin.Instance.UIViewControll.Hide(this);
    }

    void SetLayer()
    {
        if (this.transform.parent != LayerOB(TargetLayer))
        {
            this.transform.parent = LayerOB(TargetLayer);
            this.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            this.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        }
    }

    Transform LayerOB(Layer layer)
    {
        Transform target;

        switch (layer)
        {
            case Layer.Background:
                target = UIAdmin.Instance.Background.transform;
                break;
            case Layer.SafeArea:
                target = UIAdmin.Instance.SafeArea.transform;
                break;
            case Layer.PopUpSafeArea:
                target = UIAdmin.Instance.PopUpSafeArea.transform;
                break;

            default:
                target = null; 
                break;
        }

        return target;
    }
}
