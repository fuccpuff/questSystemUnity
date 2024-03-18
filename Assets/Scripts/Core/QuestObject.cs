using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class QuestObject : ScriptableObject
{
    public string questId;
    public string title;
    public string description;
    public string targetObjectName;
}
