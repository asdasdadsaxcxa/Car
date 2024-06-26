using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdmin : MonoBehaviour
{


    public SceneAdmin UIViewControll;

    CarInfo SelectCarInfo = new CarInfo();

    private static SceneAdmin instance = null;
    public static SceneAdmin Instance
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
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }


    public void SceneChange(SceneList target)
    {
        SceneManager.LoadScene((int)target);
    }


    public void SeletCar(float maxSpeed , float maxSpeedTime , float restrictionAngle , float angleForce)
    {
        SelectCarInfo.MaxSpeed = maxSpeed;
        SelectCarInfo.MaxSpeedTime = maxSpeedTime;
        SelectCarInfo.Restriction_Angle = restrictionAngle;
        SelectCarInfo.AngleForce = angleForce;

        Debug.Log("Car Setting\r\n MaxSpeed : " + maxSpeed +
            "\r\nMaxSpeedTime : " + maxSpeedTime +
            "\r\nRestrictionAngle : " + restrictionAngle +
            "\r\nAngleForce : " + angleForce);
    }
}


public enum SceneList
{
    UIScene = 0,
    GameScene,
}