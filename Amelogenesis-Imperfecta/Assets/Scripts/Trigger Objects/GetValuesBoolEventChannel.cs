using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class GetValuesBoolEventChannel : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _firstBoolEventChannel;
        [SerializeField] private BoolEventChannelSO _secondBoolEventChannel;
        [SerializeField] private UnityEvent _OnBoolIsTrue;
        [SerializeField] private UnityEvent _OnBoolIsFalse;
        
        private bool _firstBool;
        private bool _secondBool;

        private void OnEnable()
        {
            _firstBoolEventChannel.OnBoolRequested += SetFirstBool;
            _secondBoolEventChannel.OnBoolRequested += SetSecondBool;
        }

        private void OnDisable()
        {
            _firstBoolEventChannel.OnBoolRequested -= SetFirstBool;
            _secondBoolEventChannel.OnBoolRequested -= SetSecondBool;
        }

        private void SetFirstBool(bool value)
        {
            _firstBool = value;
            CheckBothBools();
        }

        private void SetSecondBool(bool value)
        {
            _secondBool = value;
            CheckBothBools();
        }

        private void CheckBothBools()
        {
            if (_firstBool && _secondBool)
            {
                _OnBoolIsTrue.Invoke();
            }
            else
            {
                _OnBoolIsFalse.Invoke();
            }
        }
    }
}