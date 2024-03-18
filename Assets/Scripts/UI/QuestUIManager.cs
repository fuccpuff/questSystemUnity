using TMPro;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager instance;
    public TMP_Text questListText;

    private void Awake()
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
        QuestManager.instance.LoadQuests();
        UpdateQuestDisplay();
    }

    public void UpdateQuestDisplay()
    {
        questListText.text = "";
        foreach (Quest quest in QuestManager.instance.quests)
        {
            string colorHex = quest.isCompleted ? "#00FF00" : quest.isActive ? "#FFFF00" : "#808080";
            questListText.text += $"<color={colorHex}>{quest.title}</color>: {quest.description}\n";
        }
    }
}