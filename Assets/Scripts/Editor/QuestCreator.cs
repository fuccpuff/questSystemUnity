using System.Globalization;
using UnityEditor;
using UnityEngine;

public class QuestCreator
{
    private static readonly string questResourcesPath = "Assets/Resources/Quests";

    [MenuItem("Quest System/Create New Quest")]
    public static void CreateNewQuestMenuOption()
    {
        string questName = "New Quest " + System.DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        CreateNewQuest(questName);
    }

    public static void CreateNewQuest(string questName)
    {
        if (!AssetDatabase.IsValidFolder(questResourcesPath))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "Quests");
        }

        QuestObject newQuest = ScriptableObject.CreateInstance<QuestObject>();
        newQuest.questId = GenerateQuestId(questName); 
        newQuest.title = questName;
        string path = AssetDatabase.GenerateUniqueAssetPath($"{questResourcesPath}/{questName}.asset");
        AssetDatabase.CreateAsset(newQuest, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newQuest;
    }

    private static string GenerateQuestId(string title)
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
        string shortTitle = title.Length > 10 ? title.Substring(0, 10) : title;
        return $"{shortTitle}_{date}";
    }
}
