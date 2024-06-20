using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Car Data", menuName = "Scriptable Object/Car Data", order = int.MaxValue)]
public class CarSetScriptOb : ScriptableObject
{
    [Header("���� ����")]

    [Header("���� ����")]
    [SerializeField] public float MaxSpeed = 10;
    [Tooltip("�ִ� �ӵ� ���� ����(S)")]
    [SerializeField] public float MaxSpeedTime = 3;
    [Tooltip("���� �")]
    [SerializeField] public AnimationCurve VeloCity;


    [Header("ȸ�� ����")]
    [Tooltip("�̵� ����(����)")]
    [Range(5f, 10f)]
    [SerializeField] public float Restriction_Angle = 10;
    [Tooltip("ȸ���� ���� ���ҷ�(%) 1�̸� ����")]
    [Range(0.1f, 1f)]
    [SerializeField] public float AngleForce = 0.7f;
}
