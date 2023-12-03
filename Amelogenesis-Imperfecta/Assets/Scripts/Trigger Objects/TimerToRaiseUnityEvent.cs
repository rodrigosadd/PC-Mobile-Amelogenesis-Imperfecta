using System;
using System.Collections;
using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class TimerToRaiseUnityEvent : MonoBehaviour
    {
        [SerializeField] private FloatEventChannelSO _setTimerFloatEventChannelSO;
        [SerializeField] private UnityEvent _onRaiseUnityEvent;

        private void OnEnable()
        {
            _setTimerFloatEventChannelSO.OnFloatRequested += StartTimer;
        }

        private void OnDisable()
        {
            _setTimerFloatEventChannelSO.OnFloatRequested -= StartTimer;
        }

        private void StartTimer(float time)
        {
            StartCoroutine(TimerCoroutine(time));
        }

        private IEnumerator TimerCoroutine(float time)
        {
            yield return new WaitForSeconds(time);
            
            _onRaiseUnityEvent?.Invoke();
        }
    }
}