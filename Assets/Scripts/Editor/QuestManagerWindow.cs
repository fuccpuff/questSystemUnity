using UnityEditor;
using UnityEngine;

public class QuestManagerWindow : EditorWindow
{
    private string newQuestName = "New Quest";

    [MenuItem("Quests/Quest Manager")]
    public static void ShowWindow()
    {
        GetWindow<QuestManagerWindow>("Quest Manager");
    }

    void OnGUI()
    {
        GUILayout.Label("Quest Manager", EditorStyles.boldLabel);

        newQuestName = EditorGUILayout.TextField("New Quest Name", newQuestName);

        if (GUILayout.Button("Create New Quest"))
        {
            if (!string.IsNullOrEmpty(newQuestName))
            {
                QuestCreator.CreateNewQuest(newQuestName);
                newQuestName = "";
            }
            else
            {
                EditorUtility.DisplayDialog("Quest Creation Failed", "Quest name cannot be empty.", "OK");
            }
        }
    }
}
