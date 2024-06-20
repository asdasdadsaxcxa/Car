using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Car Data", menuName = "Scriptable Object/Car Data", order = int.MaxValue)]
public class CarSetScriptOb : ScriptableObject
{
    [Header("���� ����")]

    [Header("���� ����")]
    [SerializeField] float MaxSpeed = 10;
    [Tooltip("�ִ� �ӵ� ���� ����(S)")]
    [SerializeField] float MaxSpeedTime = 3;
    [Tooltip("���� �")]
    [SerializeField] AnimationCurve VeloCity;
    AnimationCurve VeloCityInverse;


    [Header("ȸ�� ����")]
    [Tooltip("�̵� ����(����)")]
    [Range(5f, 10f)]
    [SerializeField] float Restriction_Angle = 10;
    [Tooltip("ȸ���� ���� ���ҷ�(%) 1�̸� ����")]
    [Range(0.1f, 1f)]
    [SerializeField] float AngleForce = 0.7f;
}
