using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questId;
    public string title;
    public string description;
    public bool isActive = false;
    public bool isCompleted = false;

    // Конструктор для создания квеста из QuestObject
    public Quest(QuestObject questObject)
    {
        this.questId = questObject.questId;
        this.title = questObject.title;
        this.description = questObject.description;
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
