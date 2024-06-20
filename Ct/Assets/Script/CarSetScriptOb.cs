using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Car Data", menuName = "Scriptable Object/Car Data", order = int.MaxValue)]
public class CarSetScriptOb : ScriptableObject
{
    [Header("동작 설정")]

    [Header("가속 설정")]
    [SerializeField] float MaxSpeed = 10;
    [Tooltip("최대 속도 도달 시점(S)")]
    [SerializeField] float MaxSpeedTime = 3;
    [Tooltip("가속 곡선")]
    [SerializeField] AnimationCurve VeloCity;
    AnimationCurve VeloCityInverse;


    [Header("회전 설정")]
    [Tooltip("이동 단위(감도)")]
    [Range(5f, 10f)]
    [SerializeField] float Restriction_Angle = 10;
    [Tooltip("회전에 따른 감소량(%) 1이면 멈춤")]
    [Range(0.1f, 1f)]
    [SerializeField] float AngleForce = 0.7f;
}
