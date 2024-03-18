using UnityEngine;

public class QuestInteractionObject : MonoBehaviour
{
    public string questId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��������� ��� ���������� ������
            QuestManager.instance.CompleteQuest(questId);
        }
    }
}
