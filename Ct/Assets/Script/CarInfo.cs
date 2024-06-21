using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfo : MonoBehaviour
{
    [Header("���� ����")]

    [Header("���� ����")]
    [SerializeField] public float MaxSpeed = 10;
    [Tooltip("�ִ� �ӵ� ���� ����(S)")]
    [SerializeField] public float MaxSpeedTime = 10;
    [Tooltip("���� �")]
    [SerializeField] public AnimationCurve VeloCity;
    [HideInInspector] public AnimationCurve VeloCityInverse;

    [HideInInspector] public float VeloTime = 0;

    [Header("ȸ�� ����")]
    [Tooltip("�̵� ����(����)")]
    [Range(5f, 10f)]
    [SerializeField] public float Restriction_Angle = 10;
    [HideInInspector] public float AngleTimeSlope = 10;
    [Tooltip("ȸ���� ���� ���ҷ�(%) 1�̸� ����")]
    [Range(0.1f, 1f)]
    [SerializeField] public float AngleForce = 1;

    [Header("����")]
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