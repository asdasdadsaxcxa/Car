using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SafeArea))]
public class SafeAreaInspector : Editor
{
    public override void OnInspectorGUI() 
    {
        base.OnInspectorGUI();
        SafeArea Safe = (SafeArea)target;
        if (GUILayout.Button("SafeArea"))
        {
            Safe.AppSafeArea(); 
        }
    }
}
