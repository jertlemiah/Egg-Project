using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// using UnityEngine.ed

[CustomEditor(typeof(AudioManager)), CanEditMultipleObjects]
public class Editor_AudioManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector ();
        AudioManager manager = (AudioManager)target;

        if(GUILayout.Button("Next Song"))
        {
            manager.PlayNextTrack();
        }
    }
}
