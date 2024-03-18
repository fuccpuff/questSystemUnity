using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests = new List<Quest>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadQuests();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadQuests()
    {
        quests.Clear();
        var questObjects = Resources.LoadAll<QuestObject>("Quests");
        foreach (var questObject in questObjects)
        {
            quests.Add(new Quest(questObject));
        }
    }

    public Quest GetQuest(string questId)
    {
        return quests.FirstOrDefault(q => q.questId == questId);
    }

    public void ActivateQuest(string questId)
    {
        Quest quest = GetQuest(questId);
        if (quest != null && !quest.isActive)
        {
            quest.isActive = true;
            QuestUIManager.instance.UpdateQuestDisplay();
        }
    }

    public void CompleteQuest(string questId)
    {
        Quest quest = quests.FirstOrDefault(q => q.questId == questId);
        if (quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            QuestUIManager.instance.UpdateQuestDisplay();
            Debug.Log($"Quest '{quest.title}' completed!");
        }
    }

    public void CheckQuestCompletion(QuestObject questObject)
    {
        GameObject targetObject = GameObject.Find(questObject.targetObjectName);
        if (targetObject != null)
        {
            targetObject.SetActive(false);
            CompleteQuest(questObject.questId);
        }
        else
        {
            Debug.LogWarning($"Target object '{questObject.targetObjectName}' not found.");
        }
    }
}
