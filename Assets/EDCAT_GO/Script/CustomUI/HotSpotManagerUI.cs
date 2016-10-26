/*
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HotSpotDatabase))]
public class HotSpotManagerUI : Editor
{

    private static GUIContent createbutton = new GUIContent("핫스팟 생성", "생성합니다."),
        deletebutton = new GUIContent("요소 삭제", "삭제합니다.");


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("업적 설정");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inID"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inContent"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inPos"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inTime"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inItemID"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inIcon"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("inMarker"));
        DrawSeperator(Color.gray);

        HotSpotDatabase script = target as HotSpotDatabase;
        if (GUILayout.Button(createbutton))
        {
            script.Add();
        }

        DrawSeperator(Color.gray);
        EditorGUILayout.LabelField("핫스팟 데이터베이스");
        showlist(serializedObject.FindProperty("hotspots"));
        serializedObject.ApplyModifiedProperties();
    }

    private static void showlist(SerializedProperty list)
    {
        EditorGUILayout.PropertyField(list, false);
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