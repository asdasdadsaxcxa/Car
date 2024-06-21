using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedoMeter : MonoBehaviour
{
    [SerializeField] CarInfo carInfo;
    [SerializeField] RectTransform Needle;

    Vector3 OldPos = Vector3.zero;
    Vector3 NewPos = Vector3.zero;
    float Km = 0;


    float NeedleAngle;
    void Start()
    {
        OldPos = carInfo.CharacterController.transform.position;
        NeedleAngle = Needle.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        GetHourVelo();
    }


    void GetHourVelo()
    {
        NewPos = new Vector3(carInfo.CharacterController.transform.position.x, 0, carInfo.CharacterController.transform.position.z);
        Km = Vector3.Distance(OldPos ,NewPos) * 10000f; // = MaxSpeed *10 수준의 수치가 나옴.
        OldPos = NewPos;
        //Debug.Log(Km);
        //Debug.Log((((Km / 10) / carInfo.MaxSpeed) * 300));

        Needle.eulerAngles = new Vector3(0, 0,
            Mathf.LerpAngle(Needle.eulerAngles.z , NeedleAngle - (((Km/10)/carInfo.MaxSpeed)*300), Time.deltaTime * 10));
    }
}
