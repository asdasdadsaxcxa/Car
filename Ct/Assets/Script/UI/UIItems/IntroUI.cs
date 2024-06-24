using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : UIItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init(GameObject pa)
    {
        
    }

    public override void Show(GameObject pa)
    {
        PlayIntro();
    }

    public void PlayIntro()
    {
        Debug.Log("PlayIntro");
    }
}
