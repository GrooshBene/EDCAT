/*
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CatDatabase))]
public class CatManagerUI : Editor
{

    private static GUIContent createbutton = new GUIContent("고양이 생성", "생성합니다."),
        deletebutton = new GUIContent("요소 삭제", "삭제합니다.");


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("고양이 설정");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InID"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InContent"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InIcon"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InImg"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InPoint"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InPercent"));
        DrawSeperator(Color.gray);

        CatDatabase script = target as CatDatabase;
        if (GUILayout.Button(createbutton))
        {
            script.Add();
        }

        DrawSeperator(Color.gray);
        EditorGUILayout.LabelField("고양이 데이터베이스");
        showlist(serializedObject.FindProperty("cats"));
        serializedObject.ApplyModifiedProperties();
    }

    private static void showlist(SerializedProperty list)
    {
        EditorGUILayout.PropertyField(list,false);
        EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        EditorGUI.indentLevel += 1;
        for (int i = 0; i < list.arraySize; i++)
        {
            EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), true);
            if (GUILayout.Button(deletebutton))
            {
                list.DeleteArrayElementAtIndex(i);
            }
        }
        EditorGUI.indentLevel -= 1;
    }

    void DrawSeperator(Color color)
    {
        EditorGUILayout.Space();

        Texture2D tex = new Texture2D(1, 1);
        GUI.color = color;
        float y = GUILayoutUtility.GetLastRect().yMax;
        GUI.DrawTexture(new Rect(0.0f, y, Screen.width, 1.0f), tex);
        tex.hideFlags = HideFlags.DontSave;
        GUI.color = Color.white;

        EditorGUILayout.Space();
    }
}
*/