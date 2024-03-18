using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questId;
    public string title;
    public string description;
    public bool isActive = false;
    public bool isCompleted = false;
    public string targetObjectName;

    public Quest(QuestObject questObject)
    {
        questId = questObject.questId;
        title = questObject.title;
        description = questObject.description;
        targetObjectName = questObject.targetObjectName;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Complete()
    {
        isCompleted = true;
    }
}
