using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarControll : MonoBehaviour
{
    [Header("동작 설정")]

    [Header("가속 설정")]
    [SerializeField] float MaxSpeed = 10;
    [Tooltip("최대 속도 도달 시점(S)")]
    [SerializeField] float MaxSpeedTime = 10;
    [Tooltip("가속 곡선")]
    [SerializeField] AnimationCurve VeloCity;
    AnimationCurve VeloCityInverse;

    float VeloTime = 0;

    [Header("회전 설정")]
    [Tooltip("이동 단위(감도)")]
    [Range(5f , 10f)]
    [SerializeField] float Restriction_Angle = 10;
    float AngleTimeSlope = 10;
    [Tooltip("회전에 따른 감소량(%) 1이면 멈춤")]
    [Range(0.1f, 1f)]
    [SerializeField] float AngleForce = 1;


    [Header("세팅")]
    [SerializeField] CharacterController CharacterController;
    [SerializeField] Slider ControllSlider;

    float OldAngle = 0;
    float AppAngle = 0;
    float SliderValue = 0;
    float AppSpeed = 0;
    float AngleSpeed = 0;
    bool Touching = false;
    void Start()
    {
        ControllSlider.value = 0;
        ControllSlider.onValueChanged.AddListener(SliderMoving);
        EventSet();
        VeloCityInverseSet();
    }


    private void LateUpdate()
    {
        CarMoving();
    }

    void EventSet()
    {
        EventTrigger eventTrigger = ControllSlider.transform.GetComponent<EventTrigger>();

        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { SliderValue = 0; Touching = true; });
        eventTrigger.triggers.Add(entry_PointerDown);

        EventTrigger.Entry entry_PointerUp = new EventTrigger.Entry();
        entry_PointerUp.eventID = EventTriggerType.PointerUp;
        entry_PointerUp.callback.AddListener((data) => { ControllSlider.value = 0; Touching = false; });
        eventTrigger.triggers.Add(entry_PointerUp);
    }

    void VeloCityInverseSet()
    {
        VeloCityInverse = new AnimationCurve();
        for (int i = 0; i < VeloCity.length; i++)
        {
            Keyframe inverseKey = new Keyframe(VeloCity.keys[i].value, VeloCity.keys[i].time);
            VeloCityInverse.AddKey(inverseKey);
        }
    }

    void CarMoving()
    {
        AppAngle = Mathf.LerpAngle(AppAngle, (SliderValue * Restriction_Angle) + AppAngle, Time.deltaTime * AngleTimeSlope);
        float AngleVar = (OldAngle - AppAngle)/ Time.deltaTime; //Maximum = 100
        OldAngle = AppAngle;

        CharacterController.transform.eulerAngles = new Vector3(0,AppAngle,0);

        if (Touching)
        {
            //임의의 값으로 직선에선 영향 X , 최대속도의 0.3속도 일때
            if (Mathf.Abs(AngleVar) > 20 && AppSpeed > MaxSpeed * 0.3f)
            {
                AngleSpeed = (Mathf.Abs(AngleVar) / 100) * (MaxSpeed * AngleForce);
                VeloTime = (VeloCityInverse.Evaluate((MaxSpeed - AngleSpeed)/ MaxSpeed)) * MaxSpeedTime;

                Debug.Log(VeloTime);
            }
            else
            {
                AngleSpeed = 0;
            }
            float TargetSpeed = MaxSpeed - AngleSpeed;

            //Speed
            if (TargetSpeed - AppSpeed > 0.1f)
            {
                AppSpeed = (MaxSpeed * VeloCity.Evaluate(VeloTime / MaxSpeedTime));
                VeloTime += Time.deltaTime;
            }
            else
            {                
                AppSpeed = TargetSpeed;
            }
        }
        else
        {
            if (AppSpeed > 0.1f)
                AppSpeed = Mathf.Lerp(AppSpeed, 0, Time.deltaTime);
            else
                AppSpeed = 0;
            VeloTime = 0;
            AngleSpeed = 0;
        }        

        //Debug.Log("Appspeed : " + AppSpeed + "\r\nAppSpeed - AngleSpeed : " + (AppSpeed - AngleSpeed).ToString());
        //Move
        Vector3 TargetMove = (Quaternion.Euler(0, AppAngle, 0) * new Vector3(0, 0, (AppSpeed) * 0.001f)) + new Vector3(0,-2,0);
        CharacterController.Move(TargetMove);
    }


    void SliderMoving(float value)
    {
        SliderValue = value;
    }

}
