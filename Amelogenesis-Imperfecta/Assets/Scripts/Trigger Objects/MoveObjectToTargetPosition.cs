using DG.Tweening;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace Trigger_Objects
{
    public class MoveObjectToTargetPosition : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _moveToTargetPositionVoidEventChannel;
        [SerializeField] private VoidEventChannelSO _ReturnToStartPositionVoidEventChannel;
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Ease _easeMoveToTargetPosition;
        [SerializeField] private Ease _easeMoveToStartPosition;
        [SerializeField] private float _delayMoveToTargetPosition;
        [SerializeField] private float _delayMoveToStartPosition;
        [SerializeField] private float _duration;
        
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void OnEnable()
        {
            _moveToTargetPositionVoidEventChannel.OnVoidRequested += MoveToTargetPosition;
            _ReturnToStartPositionVoidEventChannel.OnVoidRequested += ReturnToStartPosition;
        }

        private void OnDisable()
        {
            _moveToTargetPositionVoidEventChannel.OnVoidRequested -= MoveToTargetPosition;
            _ReturnToStartPositionVoidEventChannel.OnVoidRequested -= ReturnToStartPosition;
        }

        private void MoveToTargetPosition()
        {
            transform.DOMove(_targetPosition.position, _duration).SetEase(_easeMoveToTargetPosition).SetDelay(_delayMoveToTargetPosition);
        }

        private void ReturnToStartPosition()
        {
            transform.DOMove(_startPosition, _duration).SetEase(_easeMoveToStartPosition).SetDelay(_delayMoveToStartPosition);
        }
    }
}