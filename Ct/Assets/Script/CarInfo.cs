using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfo : MonoBehaviour
{
    [Header("동작 설정")]

    [Header("가속 설정")]
    [SerializeField] public float MaxSpeed = 10;
    [Tooltip("최대 속도 도달 시점(S)")]
    [SerializeField] public float MaxSpeedTime = 10;
    [Tooltip("가속 곡선")]
    [SerializeField] public AnimationCurve VeloCity;
    [HideInInspector] public AnimationCurve VeloCityInverse;

    [HideInInspector] public float VeloTime = 0;

    [Header("회전 설정")]
    [Tooltip("이동 단위(감도)")]
    [Range(5f, 10f)]
    [SerializeField] public float Restriction_Angle = 10;
    [HideInInspector] public float AngleTimeSlope = 10;
    [Tooltip("회전에 따른 감소량(%) 1이면 멈춤")]
    [Range(0.1f, 1f)]
    [SerializeField] public float AngleForce = 1;

    [Header("세팅")]
    [SerializeField] public CharacterController CharacterController;


    
    void Awake()
    {
        Init();
        //VeloCityInverseSet();
    }

    public virtual void Init()
    {
        VeloCityInverseSet();
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

    public void SetCarInfo(float maxspeed , float maxSpeedTime , AnimationCurve curve , float resAngle , float anglefor)
    {
        MaxSpeed = maxspeed;
        MaxSpeedTime = maxSpeedTime;
        VeloCity = curve;
        Restriction_Angle = resAngle;
        AngleForce = anglefor;
        //CharacterController = cha;
        VeloCityInverseSet();
    }
}