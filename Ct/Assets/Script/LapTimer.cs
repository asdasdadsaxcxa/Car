using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    [SerializeField] Text Text;

    float TimeRec;
    bool Playing = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Playing)
            TimeRec += Time.deltaTime;
        ShowingTimer();
    }

    public void LapStart()
    {
        TimeRec = 0;
        Playing = true;
    }

    public void LapFinish()
    {
        Playing = false;
    }

    void ShowingTimer()
    {
        int Ms = (int)((TimeRec - (int)TimeRec)*1000);
        int Sec = (int)TimeRec % 60;
        int Min = (int)TimeRec / 60;
        Text.text = string.Format("{0:D2} : {1:D2} : {2:D3}", Min , Sec , Ms);
    }
}
