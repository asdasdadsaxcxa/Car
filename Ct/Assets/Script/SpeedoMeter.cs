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


    float AppAngle = 0;

    void Start()
    {
        OldPos = carInfo.CharacterController.transform.position;
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
            Mathf.LerpAngle(Needle.eulerAngles.z, ((Km / 10) / carInfo.MaxSpeed) * -300, Time.deltaTime * 10));
        Debug.Log(Mathf.LerpAngle(Needle.eulerAngles.z, ((Km / 10) / carInfo.MaxSpeed) * -300, Time.deltaTime * 10));
        //Debug.Log("Needle : " + Needle.eulerAngles.z +
        //    "\r\nTargetNedle : " + (NeedleAngle - (((Km / 10) / carInfo.MaxSpeed) * 300)) +
        //    "\r\n Value : " + (Needle.eulerAngles.z - (NeedleAngle - (((Km / 10) / carInfo.MaxSpeed) * 300))));

        //if (AppAngle - (((Km / 10) / carInfo.MaxSpeed) * 300) > 1)
        //{
        //    AppAngle += Time.deltaTime * 10;
        //}
        //else if (AppAngle - (((Km / 10) / carInfo.MaxSpeed) * 300) < -1)
        //{
        //    AppAngle -= Time.deltaTime * 10;
        //}

        //Needle.eulerAngles = new Vector3(0, 0, AppAngle);
    }
}
