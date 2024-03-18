using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestObject))]
public class QuestObjectEditor : Editor
{
    SerializedProperty questIdProp;
    SerializedProperty titleProp;
    SerializedProperty descriptionProp;
    // Другие поля...

    string[] questTypes = new string[] { "Сбор предметов", "Исследование местности" }; // Примеры типов квестов
    int selectedQuestTypeIndex = 0; // Индекс выбранного типа квеста

    private void OnEnable()
    {
        // Связываем SerializedProperty с полями в QuestObject
        questIdProp = serializedObject.FindProperty("questId");
        titleProp = serializedObject.FindProperty("title");
        descriptionProp = serializedObject.FindProperty("description");
        // Другие поля...
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update(); // Обновляем объект

        EditorGUILayout.PropertyField(questIdProp);
        EditorGUILayout.PropertyField(titleProp);
        EditorGUILayout.PropertyField(descriptionProp);
        // Отображение других полей...

        // Выбор шаблона квеста
        selectedQuestTypeIndex = EditorGUILayout.Popup("Quest Type", selectedQuestTypeIndex, questTypes);
        if (GUILayout.Button("Apply Quest Type Template"))
        {
            ApplyQuestTypeTemplate(selectedQuestTypeIndex);
        }

        // Связывание с элементами игры
        EditorGUILayout.ObjectField("Quest Target Object", null, typeof(GameObject), true);

        if (serializedObject.ApplyModifiedProperties()) // Применяем изменения
        {
            // Здесь можно добавить дополнительную валидацию
        }

        // Сохранить изменения объекта
        if (GUILayout.Button("Save Quest"))
        {
            SaveQuest();
        }
    }

    void ApplyQuestTypeTemplate(int index)
    {
        // Применить шаблон квеста в зависимости от выбранного типа
        // Здесь могут быть заданы стандартные значения или логика для разных типов квестов
    }

    void SaveQuest()
    {
        // Дополнительная валидация перед сохранением, если нужно
        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
    }
}
