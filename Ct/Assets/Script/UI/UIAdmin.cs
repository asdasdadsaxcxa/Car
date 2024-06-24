using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIAdmin : MonoBehaviour
{
    [Header("Base Object")]
    [SerializeField] GameObject Background;
    [SerializeField] GameObject SafeArea;
    [SerializeField] GameObject PopUpSafeArea;

    [Header("Items")]
    [SerializeField] List<UIItem> Items;

    // Start is called before the first frame update
    void Start()
    {
        Items[0].Show(SafeArea);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
