using Interfaces;
using Quest_System;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace Tooth
{
    public class TreatmentableObject : MonoBehaviour, ITreatmentable
    {
        [SerializeField] private Quest _questToComplete;
        [SerializeField] private StringEventChannelSO _completeQuestStringEventChannel;

        public void QuestComplete()
        {
            _completeQuestStringEventChannel.RaiseStrigEvent(_questToComplete.questName);
            gameObject.SetActive(false);
        }

        public string GetQuestName()
        {
            return _questToComplete.questName;
        }
    }
}