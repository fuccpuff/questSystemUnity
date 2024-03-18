using UnityEngine;

public class Quest : ScriptableObject
{
    public string questId;
    public string title;
    public string description;
    public bool isActive = false;
    public bool isCompleted = false;
    public GameObject targetObject;

    public Quest(QuestObject questObject)
    {
        questId = questObject.questId;
        title = questObject.title;
        description = questObject.description;
        targetObject = questObject.targetObject; 
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
