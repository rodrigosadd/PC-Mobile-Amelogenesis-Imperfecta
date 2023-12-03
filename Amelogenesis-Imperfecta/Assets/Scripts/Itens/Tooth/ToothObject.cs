using System;
using Interfaces;
using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Tooth
{
    public class ToothObject : MonoBehaviour
    {
        [SerializeField] private LayerMask _treatmentObject;
        [SerializeField] private VoidEventChannelSO _currentQuestCompleted;
        [SerializeField] private UnityEvent _onQuestCompleted;
        
        private ITreatmentable _treatmentableObject;
        
        private void OnEnable()
        {
            _currentQuestCompleted.OnVoidRequested += QuestCompletedCallback;
        }

        private void OnDisable()
        {
            _currentQuestCompleted.OnVoidRequested -= QuestCompletedCallback;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(((1 << other.gameObject.layer) & _treatmentObject) == 0) return;

            _treatmentableObject = other.GetComponentInParent<ITreatmentable>();
            
            _treatmentableObject.QuestComplete();
        }

        private void QuestCompletedCallback()
        {
            _onQuestCompleted?.Invoke();
        }
    }
}