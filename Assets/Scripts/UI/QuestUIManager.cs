using UnityEngine;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager instance;
    public TMP_Text questListText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // QuestManager.instance.LoadQuests(); // Убедитесь, что этот метод публичный или вызывается внутри QuestManager
        QuestUIManager.instance.UpdateQuestDisplay();
    }

    public void UpdateQuestDisplay()
    {
        questListText.text = "";
        foreach (Quest quest in QuestManager.instance.quests)
        {
            string colorHex = quest.isCompleted ? "#00FF00" : quest.isActive ? "#FFFF00" : "#808080"; // зелёный, жёлтый, серый
            questListText.text += $"<color={colorHex}>{quest.title}</color>: {quest.description}\n";
        }
    }
}
