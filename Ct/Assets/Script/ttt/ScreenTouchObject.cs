using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouchObject : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // 싱글 터치.
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos;
            Ray ray;
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // 터치 시작 시.
                    Vector3 touchPosToVector3 = new Vector3(touch.position.x, touch.position.y, 100);
                    touchPos = Camera.main.ScreenToWorldPoint(touchPosToVector3);
                    ray = Camera.main.ScreenPointToRay(touchPosToVector3);
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.red, 1.5f);

                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ClickObject"))
                        {
                            if (hit.collider.TryGetComponent<AudioSource>(out AudioSource source))
                            {
                                source.time = 0;
                                source.Play();
                            }
                        }
                    }
                    else
                    {
                        Debug.DrawLine(ray.origin, touchPos, Color.yellow, 1.5f);
                    }

                    break;
                case TouchPhase.Moved:
                    // 터치 이동 시.
                    // Debug.Log("터치 이동");
                    break;

                case TouchPhase.Stationary:
                    // 터치 고정 시.
                    // Debug.Log("터치 고정");
                    break;

                case TouchPhase.Ended:
                    // 터치 종료 시. ( 손을 뗐을 시 )
                    // Debug.Log("터치 종료");
                    break;

                case TouchPhase.Canceled:
                    // 터치 취소 시. ( 시스템에 의해서 터치가 취소된 경우 (ex: 전화가 왔을 경우 등) )
                    // Debug.Log("터치 취소");
                    break;
            }
        }
    }
}
