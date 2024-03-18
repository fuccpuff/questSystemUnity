using UnityEngine;

public class QuestInteractionObject : MonoBehaviour
{
    public string questId;
    public string targetObjectName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.name == targetObjectName)
        {
            QuestManager.instance.CompleteQuest(questId);
        }
    }
}
