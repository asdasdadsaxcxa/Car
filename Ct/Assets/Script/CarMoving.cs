using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : CarInfo
{
    float OldAngle = 0;
    float AppAngle = 0;
    float AppSpeed = 0;
    float AngleSpeed = 0;
    bool Touching = false;
    float SliderValue = 0;
    float OutSideValue = 0;

    public override void Init()
    {
        base.Init();
        AppAngle = CharacterController.transform.eulerAngles.y;
    }

    private void Update()
    {
        CarMove();
    }
    void CarMove()
    {
        AppAngle = Mathf.LerpAngle(AppAngle, (SliderValue * Restriction_Angle) + AppAngle, Time.deltaTime * AngleTimeSlope);
        float AngleVar = (OldAngle - AppAngle) / Time.deltaTime; //Maximum = 100
        OldAngle = AppAngle;

        CharacterController.transform.eulerAngles = new Vector3(0, AppAngle, 0);

        if (Touching)
        {
            //임의의 값으로 직선에선 영향 X , 최대속도의 0.3속도 일때
            if (Mathf.Abs(AngleVar) > 20 && AppSpeed > MaxSpeed * 0.3f)
            {
                AngleSpeed = (Mathf.Abs(AngleVar) / 100) * (MaxSpeed * AngleForce);
                VeloTime = (VeloCityInverse.Evaluate((MaxSpeed - AngleSpeed) / MaxSpeed)) * MaxSpeedTime;
            }
            else
            {
                AngleSpeed = 0;
            }
            float TargetSpeed = MaxSpeed - AngleSpeed - OutSideValue;
            TargetSpeed = Mathf.Max(TargetSpeed, 0);
            //Speed
            if (TargetSpeed - AppSpeed > 0.1f)
            {
                //Debug.Log(VeloTime);
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
        Vector3 TargetMove = (Quaternion.Euler(0, AppAngle, 0) * new Vector3(0, 0, (AppSpeed) * 0.001f)) + new Vector3(0, -2, 0);
        CharacterController.Move(TargetMove);
    }

    public void SliderValueSet(float value)
    {
        SliderValue = value;
    }

    public void TrigetEvent(bool on)
    {
        Touching = on;
    }

    public void CrashWall()
    {
        OutSideValue = 2;
    }
}
