using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MasterOptionsScript))]
public class OptionsInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MasterOptionsScript mstr = (MasterOptionsScript)target;
        if(GUILayout.Button("Create Element"))
        {
            mstr.createElement();
        }
    }
}
