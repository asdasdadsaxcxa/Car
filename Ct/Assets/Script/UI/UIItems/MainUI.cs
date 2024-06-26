using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIItem
{
    [SerializeField] MainUIItems UIItem;
    void Start()
    {
        UIEventSetting();
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

    void UIEventSetting()
    {
        UIItem.Btn_Start.onClick.AddListener(Btn_Start_Click);
    }

    #region UI Event Func

    void Btn_Start_Click()
    {
        SceneAdmin.Instance.SeletCar(
            float.Parse(UIItem.MaxSpeed.text),
            float.Parse(UIItem.MaxSpeedTime.text),
            float.Parse(UIItem.RestricitionAngle.text),
            float.Parse(UIItem.AngleForce.text));

        SceneAdmin.Instance.SceneChange(SceneList.GameScene);
    }


    #endregion
}


[Serializable]
public class MainUIItems
{
    public Button Btn_Start;
    public TMP_InputField MaxSpeed;
    public TMP_InputField MaxSpeedTime;
    public TMP_InputField RestricitionAngle;
    public TMP_InputField AngleForce;
}

