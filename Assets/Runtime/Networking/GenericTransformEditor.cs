using Unity;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenericTransformSync))]
[CanEditMultipleObjects]
public class GenericTransformEditor : Editor 
{
    SerializedProperty body;
    SerializedProperty hasBody;
    SerializedProperty syncBody;
    void OnEnable() 
    {
        body = serializedObject.FindProperty("body");
        syncBody = serializedObject.FindProperty("syncBody");
        hasBody = serializedObject.FindProperty("hasBody");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        if (hasBody.boolValue)
        {
            EditorGUILayout.PropertyField(body);
            EditorGUILayout.PropertyField(syncBody);
        }
        serializedObject.ApplyModifiedProperties();
    }
}