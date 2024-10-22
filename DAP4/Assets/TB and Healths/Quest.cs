
using UnityEngine;

public enum QuestStatus { NotStarted, InProgress, Completed }
[System.Serializable]

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest:ScriptableObject
{
    public string questName;
    public string description;
    public QuestStatus status = QuestStatus.NotStarted;
    public string[] objectives;  // Tasks to complete (e.g., "Collect 5 items")
    public int currentObjective = 0; // Track objective progress

    public int rewardXP;
    public string rewardItem;

    public void AdvanceQuest()
    {
        if (status == QuestStatus.InProgress && currentObjective < objectives.Length - 1)
        {
            currentObjective++;
        }
        else if (currentObjective == objectives.Length - 1)
        {
            status = QuestStatus.Completed;
            GiveRewards();
        }
    }
    private void GiveRewards()
    {
        Debug.Log("Rewards given: XP - " + rewardXP + ", Item - " + rewardItem);
        // Here you'd actually give the player the XP and item in your game logic
    }





}
