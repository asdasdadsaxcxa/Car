using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : UIItem
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
        PlayIntro();
        StartCoroutine(Wait(2 , Hide));
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void PlayIntro()
    {
        Debug.Log("PlayIntro");

    }

    IEnumerator Wait(float time , Action action)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
