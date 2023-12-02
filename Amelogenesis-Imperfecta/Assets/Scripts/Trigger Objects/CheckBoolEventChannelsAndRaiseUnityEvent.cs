using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class CheckBoolEventChannelsAndRaiseUnityEvent : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _firstBoolEventChannel;
        [SerializeField] private BoolEventChannelSO _secondBoolEventChannel;
        [Space]
        public UnityEvent onBothTrue;
        public UnityEvent onFalse;

        private bool boolValue1;
        private bool boolValue2;

        private void OnEnable()
        {
            _firstBoolEventChannel.OnBoolRequested += HandleBoolEvent1;
            _secondBoolEventChannel.OnBoolRequested += HandleBoolEvent2;
        }

        private void OnDisable()
        {
            _firstBoolEventChannel.OnBoolRequested -= HandleBoolEvent1;
            _secondBoolEventChannel.OnBoolRequested -= HandleBoolEvent2;
        }

        private void HandleBoolEvent1(bool value)
        {
            boolValue1 = value;
            CheckBothBools();
        }

        private void HandleBoolEvent2(bool value)
        {
            boolValue2 = value;
            CheckBothBools();
        }

        private void CheckBothBools()
        {
            if (boolValue1 && boolValue2)
            {
                onBothTrue.Invoke();
            }
            else
            {
                onFalse.Invoke();
            }
        }
    }
}