using DG.Tweening;
using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class MoveObjectToTargetPosition : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _ReturnToStartPositionVoidEventChannel;
        [SerializeField] private VoidEventChannelSO _moveToTargetPositionVoidEventChannel;
        [SerializeField] private Transform _objectToMove;
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Ease _easeMoveToTargetPosition;
        [SerializeField] private Ease _easeMoveToStartPosition;
        [SerializeField] private float _delayMoveToTargetPosition;
        [SerializeField] private float _delayMoveToStartPosition;
        [SerializeField] private float _duration;
        [SerializeField] private UnityEvent _onFinishedMoveToTargetPosition;
        [SerializeField] private UnityEvent _onFinishedMoveToStartPosition;
        
        private Vector3 _startPosition;

        private void Start()
        {
            if (_objectToMove == null)
            {
                _objectToMove = transform;
            }
            
            _startPosition = _objectToMove.position;
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
            _objectToMove.DOMove(_targetPosition.position, _duration).SetEase(_easeMoveToTargetPosition).SetDelay(_delayMoveToTargetPosition).OnComplete(MoveToTargetPositionCallback);
        }

        private void ReturnToStartPosition()
        {
            _objectToMove.DOMove(_startPosition, _duration).SetEase(_easeMoveToStartPosition).SetDelay(_delayMoveToStartPosition).OnComplete(MoveToStartPositionCallback);
        }

        private void MoveToTargetPositionCallback()
        {
            _onFinishedMoveToTargetPosition?.Invoke();
        }
        
        private void MoveToStartPositionCallback()
        {
            _onFinishedMoveToStartPosition?.Invoke();
        }
    }
}