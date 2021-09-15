using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEditor;
using UnityEditor.Rendering.Universal;

[CustomEditor(typeof(MasterOptionsScript))]
public class OptionsInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MasterOptionsScript mstr = (MasterOptionsScript)target;
        //base.OnInspectorGUI();
        
        EditorGUILayout.Space();
        if (GUILayout.Button("Update Options"))
        {
            mstr.updateOptions();
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Simple Create Element:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Element Name",GUILayout.MaxWidth(85));
        mstr.elementName = EditorGUILayout.TextField(mstr.elementName);

        EditorGUILayout.LabelField("Element Type", GUILayout.MaxWidth(85));
        mstr.elementTypeToRemove = EditorGUILayout.TextField(mstr.elementType);

        EditorGUILayout.LabelField("Element Tab", GUILayout.MaxWidth(77));
        mstr.elementTab = EditorGUILayout.IntField(mstr.elementTab);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Element"))
        {
            mstr.createElement();
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Simple Remove Element:",EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Element Name", GUILayout.MaxWidth(85));
        mstr.elementNameToRemove = EditorGUILayout.TextField(mstr.elementNameToRemove);

        EditorGUILayout.LabelField("Element Type", GUILayout.MaxWidth(80));
        mstr.elementTypeToRemove = EditorGUILayout.TextField(mstr.elementTypeToRemove);

        EditorGUILayout.LabelField("Element Tab", GUILayout.MaxWidth(77));
        mstr.elementTabToRemove = EditorGUILayout.IntField(mstr.elementTabToRemove);

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Remove Element"))
        {
            mstr.removeElement();
        }
    }
}
