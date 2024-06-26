using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class ClickObject : MonoBehaviour
{
    
    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("ClickObject");

        this.GetComponent<AudioSource>().playOnAwake = false;
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().spatialBlend = 0;
        this.GetComponent<AudioSource>().clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
