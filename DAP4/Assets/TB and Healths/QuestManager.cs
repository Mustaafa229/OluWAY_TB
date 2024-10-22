using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void StartQuest(Quest quest)
    {
        if (quest.status == QuestStatus.NotStarted)
        {
            quest.status = QuestStatus.InProgress;
            Debug.Log("Quest started: " + quest.questName);
        }
    }

    // Update a quest's progress
    public void UpdateQuest(Quest quest)
    {
        if (quest.status == QuestStatus.InProgress)
        {
            quest.AdvanceQuest();
            Debug.Log("Progress made on quest: " + quest.questName);
        }
    }
    // Check if all quests are completed
    public void CheckQuestCompletion()
    {
        foreach (Quest quest in quests)
        {
            if (quest.status != QuestStatus.Completed)
            {
                Debug.Log("Quests are still in progress.");
                return;
            }
        }
        Debug.Log("All quests completed!");
    }
}
