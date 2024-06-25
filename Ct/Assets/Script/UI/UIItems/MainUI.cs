using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIItem
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {
        VisControll = false;
    }

    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
}


[Serializable]
public class MainUIItems
{
    public Button Btn_Start;
    
}
