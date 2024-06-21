using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BoxTriger : MonoBehaviour
{
    [SerializeField] LayerMask EnterOB;
    [SerializeField] UnityEvent EnterTriger;

    [SerializeField] UnityEvent CollisionEnterTriger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (EnterTriger != null && ((EnterOB & (1 << other.gameObject.layer)) != 0))
            EnterTriger.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (CollisionEnterTriger != null && ((EnterOB & (1 << other.gameObject.layer)) != 0))
            CollisionEnterTriger.Invoke();
    }
}
