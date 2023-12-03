using System;
using System.Collections.Generic;
using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Quest_System
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests = new List<Quest>();
        [SerializeField] private StringEventChannelSO _completeQuestStringEventChannel;
        [SerializeField] private StringEventChannelSO _uncompleteQuestStringEventChannel;
        [SerializeField] private VoidEventChannelSO _currentQuestCompleted;
        [Space]
        [SerializeField] private UnityEvent _OnAreAllQuestsCompleted;

        private void OnEnable()
        {
            _completeQuestStringEventChannel.OnStringRequested += CompleteQuest;
            _uncompleteQuestStringEventChannel.OnStringRequested += UncompleteQuest;
        }

        private void OnDisable()
        {
            _completeQuestStringEventChannel.OnStringRequested -= CompleteQuest;
            _uncompleteQuestStringEventChannel.OnStringRequested -= UncompleteQuest;
        }

        private void Start()
        {
            ResetAllQuests();
        }

        private void ResetAllQuests()
        {
            foreach (var quest in _quests)
            {
                quest.isCompleted = false;
            }
        }
            
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
            _currentQuestCompleted.RaiseVoidEvent();

            if (!AreAllQuestsCompleted()) return;
            
            Debug.Log("Todas as missões foram concluídas!");
            _OnAreAllQuestsCompleted?.Invoke();
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