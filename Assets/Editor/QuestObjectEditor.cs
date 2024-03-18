using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestObject))]
public class QuestObjectEditor : Editor
{
    SerializedProperty questIdProp;
    SerializedProperty titleProp;
    SerializedProperty descriptionProp;
    SerializedProperty targetObjectProp;

    string[] questTypes = new string[] { "Выберите тип", "Сбор предметов", "Исследование местности" };
    int selectedQuestTypeIndex = 0;

    private void OnEnable()
    {
        questIdProp = serializedObject.FindProperty("questId");
        titleProp = serializedObject.FindProperty("title");
        descriptionProp = serializedObject.FindProperty("description");
        targetObjectProp = serializedObject.FindProperty("targetObject");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(questIdProp);
        EditorGUILayout.PropertyField(titleProp);
        EditorGUILayout.PropertyField(descriptionProp);

        selectedQuestTypeIndex = EditorGUILayout.Popup("Quest Type", selectedQuestTypeIndex, questTypes);
        if (selectedQuestTypeIndex != 0)
        {
            ApplyQuestTypeTemplate(selectedQuestTypeIndex);
        }

        EditorGUILayout.PropertyField(targetObjectProp, new GUIContent("Quest Target Transform"));

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
                titleProp.stringValue = "Новый квест на сбор предметов";
                descriptionProp.stringValue = "Соберите все необходимые предметы.";

                break;
            case 2:
                titleProp.stringValue = "Новый квест на исследование местности";
                descriptionProp.stringValue = "Исследуйте указанные области.";
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
