using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIAdmin : MonoBehaviour
{
    [Header("Base Object")]
    [SerializeField] public GameObject Background;
    [SerializeField] public GameObject SafeArea;
    [SerializeField] public GameObject PopUpSafeArea;

    [Header("Items")]
    [SerializeField] List<UIItem> Items;

    public UIViewControll UIViewControll;


    private static UIAdmin instance = null;
    public static UIAdmin Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Items[0].Show(SafeArea);
        Init();
    }

    void Init()
    {
        foreach (var item in Items)
        {
            if (item.TryGetComponent<IntroUI>(out IntroUI Intro))
            {
                Intro.Init();
                Intro.Show();
            }
            else if (item.TryGetComponent<MainUI>(out MainUI Main))
            {
                Main.Init();
                Main.Show();
            }
        }
    }


    void Update()
    {
        
    }


}

[Serializable]
public enum Layer
{
    Background = 0,
    SafeArea = 1,
    PopUpSafeArea = 2
}
public class UIViewControll
{
    List<UIItem> ShowItems = new List<UIItem>();

    public void Showing(UIItem item)
    {
        ShowItems.Add(item);
    }

    public void Hide(UIItem item)
    {
        if (ShowItems.FindIndex(x => x == item) != -1)
        {
            ShowItems.Remove(item);
        }
        else
        {
            Debug.LogError("UI가 제대로 닫히지 않음");
        }
    }
    public void Hide()
    {
        if (ShowItems.Count > 0)
        {
            ShowItems[ShowItems.Count - 1].Hide();
            ShowItems.RemoveAt(ShowItems.Count - 1);
        }
    }
}
