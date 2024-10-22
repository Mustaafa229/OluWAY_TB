using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    public QuestManager questManager;
    public TextMeshProUGUI questLogText;
    void Update()
    {
        UpdateQuestLog();
    }
    void UpdateQuestLog()
    {
        questLogText.text = ""; // Clear text

        foreach (Quest quest in questManager.quests)
        {
            string questStatus = quest.status == QuestStatus.Completed ? "Completed" : "In Progress";
            questLogText.text += quest.questName + " - " + questStatus + "\n";
            questLogText.text += "Objective: " + quest.objectives[quest.currentObjective] + "\n\n";
        }
    }
}
