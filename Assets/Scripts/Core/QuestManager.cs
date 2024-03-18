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
        Quest quest = GetQuest(questId);
        if (quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            QuestUIManager.instance.UpdateQuestDisplay();
        }
    }

    public void ActivateAllQuests()
    {
        foreach (var quest in quests)
        {
            quest.isActive = true;
        }
    }
}
