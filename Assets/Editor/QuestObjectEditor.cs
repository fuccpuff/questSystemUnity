using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestObject))]
public class QuestObjectEditor : Editor
{
    SerializedProperty questIdProp;
    SerializedProperty titleProp;
    SerializedProperty descriptionProp;
    SerializedProperty targetObjectNameProp;

    string[] questTypes = new string[] { "�������� ���", "���� ���������", "������������ ���������" };
    int selectedQuestTypeIndex = 0;

    private void OnEnable()
    {
        questIdProp = serializedObject.FindProperty("questId");
        titleProp = serializedObject.FindProperty("title");
        descriptionProp = serializedObject.FindProperty("description");
        targetObjectNameProp = serializedObject.FindProperty("targetObjectName");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(questIdProp);
        EditorGUILayout.PropertyField(titleProp);
        EditorGUILayout.PropertyField(descriptionProp);
        EditorGUILayout.PropertyField(targetObjectNameProp, new GUIContent("Target Object Name"));

        selectedQuestTypeIndex = EditorGUILayout.Popup("Quest Type", selectedQuestTypeIndex, questTypes);
        if (selectedQuestTypeIndex != 0)
        {
            ApplyQuestTypeTemplate(selectedQuestTypeIndex);
        }

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Save Quest"))
        {
            SaveQuest();
        }
    }

    private void ApplyQuestTypeTemplate(int index)
    {
        switch (index)
        {
            case 1:
                titleProp.stringValue = "����� ����� �� ���� ���������";
                descriptionProp.stringValue = "�������� ��� ����������� ��������.";

                break;
            case 2:
                titleProp.stringValue = "����� ����� �� ������������ ���������";
                descriptionProp.stringValue = "���������� ��������� �������.";
                break;
            default:
                ClearQuestProperties();
                break;
        }
    }

    private void ClearQuestProperties()
    {
        titleProp.stringValue = "";
        descriptionProp.stringValue = "";
    }

    private void SaveQuest()
    {
        if (string.IsNullOrEmpty(titleProp.stringValue))
        {
            EditorUtility.DisplayDialog("Validation Failed", "Title cannot be empty", "OK");
            return;
        }

        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
