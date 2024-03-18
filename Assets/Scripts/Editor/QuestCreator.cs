using UnityEditor;
using UnityEngine;

public class QuestCreator
{
    private static readonly string questResourcesPath = "Assets/Resources/Quests";

    public static void CreateNewQuest(string questName)
    {
        // ���������, ��� ���� � ����� 'Resources/Quests' ����������
        if (!AssetDatabase.IsValidFolder($"{questResourcesPath}"))
        {
            // 'CreateFolder' ��������� ������������� ���� �� ������������ �����
            AssetDatabase.CreateFolder("Assets/Resources", "Quests");
        }

        QuestObject newQuest = ScriptableObject.CreateInstance<QuestObject>();
        string path = AssetDatabase.GenerateUniqueAssetPath($"{questResourcesPath}/{questName}.asset");
        AssetDatabase.CreateAsset(newQuest, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newQuest;
    }
}
