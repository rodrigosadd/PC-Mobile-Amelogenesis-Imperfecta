using System;
using System.Collections;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace Managers
{
    public class TransitionLoader: MonoBehaviour
    {
        [SerializeField] private Animator _transitionAnimator;
        [SerializeField] private VoidEventChannelSO _endTransitionVoidChannel;
        [SerializeField] private VoidEventChannelSO _startTransitionVoidChannel;
        [SerializeField] private float _transitionDuration;

        private void OnEnable()
        {
            _startTransitionVoidChannel.OnVoidRequested += StartTransition;
        }

        private void OnDisable()
        {
            _startTransitionVoidChannel.OnVoidRequested -= StartTransition;
        }
        
        private void StartTransition()
        {
            StartCoroutine(Transition());
        }
        
        private IEnumerator Transition()
        {
            _transitionAnimator.SetTrigger("Start");

            yield return new WaitForSeconds(_transitionDuration);
            
            _endTransitionVoidChannel.RaiseVoidEvent();
        }
    }
}