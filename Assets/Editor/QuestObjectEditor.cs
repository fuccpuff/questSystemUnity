using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestObject))]
public class QuestObjectEditor : Editor
{
    SerializedProperty questIdProp;
    SerializedProperty titleProp;
    SerializedProperty descriptionProp;
    // ������ ����...

    string[] questTypes = new string[] { "���� ���������", "������������ ���������" }; // ������� ����� �������
    int selectedQuestTypeIndex = 0; // ������ ���������� ���� ������

    private void OnEnable()
    {
        // ��������� SerializedProperty � ������ � QuestObject
        questIdProp = serializedObject.FindProperty("questId");
        titleProp = serializedObject.FindProperty("title");
        descriptionProp = serializedObject.FindProperty("description");
        // ������ ����...
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update(); // ��������� ������

        EditorGUILayout.PropertyField(questIdProp);
        EditorGUILayout.PropertyField(titleProp);
        EditorGUILayout.PropertyField(descriptionProp);
        // ����������� ������ �����...

        // ����� ������� ������
        selectedQuestTypeIndex = EditorGUILayout.Popup("Quest Type", selectedQuestTypeIndex, questTypes);
        if (GUILayout.Button("Apply Quest Type Template"))
        {
            ApplyQuestTypeTemplate(selectedQuestTypeIndex);
        }

        // ���������� � ���������� ����
        EditorGUILayout.ObjectField("Quest Target Object", null, typeof(GameObject), true);

        if (serializedObject.ApplyModifiedProperties()) // ��������� ���������
        {
            // ����� ����� �������� �������������� ���������
        }

        // ��������� ��������� �������
        if (GUILayout.Button("Save Quest"))
        {
            SaveQuest();
        }
    }

    void ApplyQuestTypeTemplate(int index)
    {
        // ��������� ������ ������ � ����������� �� ���������� ����
        // ����� ����� ���� ������ ����������� �������� ��� ������ ��� ������ ����� �������
    }

    void SaveQuest()
    {
        // �������������� ��������� ����� �����������, ���� �����
        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
    }
}
