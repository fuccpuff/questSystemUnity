using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class QuestObject : ScriptableObject
{
    public string questId;
    public string title;
    public string description;
    // Можете добавить другие поля, такие как требования квеста
}
