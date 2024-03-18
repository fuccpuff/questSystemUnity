using UnityEngine;

public class QuestInteractionObject : MonoBehaviour
{
    public string questId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Активация или завершение квеста
            QuestManager.instance.CompleteQuest(questId);
        }
    }
}
