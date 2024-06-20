using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarControll : CarMoving
{
    [SerializeField] CarSetScriptOb CarSetting;

    [Header("Controll")]
    [SerializeField] Slider ControllSlider;
    void Start()
    {
        ControllSlider.value = 0;
        ControllSlider.onValueChanged.AddListener(SliderMoving);
        EventSet();
    }

    void EventSet()
    {
        EventTrigger eventTrigger = ControllSlider.transform.GetComponent<EventTrigger>();

        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { SliderValueSet(0); TrigetEvent(true); });
        eventTrigger.triggers.Add(entry_PointerDown);

        EventTrigger.Entry entry_PointerUp = new EventTrigger.Entry();
        entry_PointerUp.eventID = EventTriggerType.PointerUp;
        entry_PointerUp.callback.AddListener((data) => { ControllSlider.value = 0; TrigetEvent(false); });
        eventTrigger.triggers.Add(entry_PointerUp);
    }




    void SliderMoving(float value)
    {
        SliderValueSet(value);
    }

    void init()
    {
        //SetCarInfo(0, 0, null, 0, 0, null);
    }

}
