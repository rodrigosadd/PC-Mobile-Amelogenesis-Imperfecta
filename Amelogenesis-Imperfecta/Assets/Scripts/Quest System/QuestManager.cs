using System.Collections.Generic;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace Quest_System
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests = new List<Quest>();

        private bool AreAllQuestsCompleted()
        {
            foreach (var quest in _quests)
            {
                if (!quest.isCompleted)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        private void CompleteQuest(string questName)
        {
            Quest quest = _quests.Find(q => q.questName == questName);

            if (quest == null) return;

            quest.isCompleted = true;
            
            Debug.Log("Missão concluída: " + questName);
            
            if (AreAllQuestsCompleted())
            {
                Debug.Log("Todas as missões foram concluídas!");
            }
        }
        
        private void UncompleteQuest(string questName)
        {
            Quest quest = _quests.Find(q => q.questName == questName);

            if (quest == null) return;

            quest.isCompleted = false;
            
            Debug.Log("Missão concluída: " + questName);
        }
    }
}