using System;
using Interfaces;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace Character
{
    public class ShowTooltipInObject : MonoBehaviour
    {
        [SerializeField] private StringEventChannelSO _showTooltipStringEventChannel;
        [SerializeField] private VoidEventChannelSO _hideTooltipVoidEventChannel;
        [SerializeField] private TransformEventChannelSO _setPositionTransformEventChannel;
        [SerializeField] private BoolEventChannelSO _PickedUpAnObjectBoolEventChannel;
        [SerializeField] private LayerMask _layerTooltip;
        [SerializeField] private float _raycastRange = 5f;

        private RaycastHit _raycastHit;
        private ITreatmentable _currentTreatmentableObject;
        private bool _alreadyResetTooltip;
        private bool _characterPickedUpAnObject;

        private void Start()
        {
            _PickedUpAnObjectBoolEventChannel.OnBoolRequested += CharacterPickedUpAnObject;
        }

        private void OnDisable()
        {
            _PickedUpAnObjectBoolEventChannel.OnBoolRequested -= CharacterPickedUpAnObject;
        }

        private void Update()
        {
            ShowGetObjectAndShowTooltip();
        }

        private void ShowGetObjectAndShowTooltip()
        {
            if (_characterPickedUpAnObject) return;

            if (Physics.Raycast(transform.position, transform.forward, out _raycastHit, _raycastRange, _layerTooltip))
            {
                ITreatmentable newTreatmentableObject = _raycastHit.transform.GetComponentInParent<ITreatmentable>();

                if (newTreatmentableObject == null || newTreatmentableObject == _currentTreatmentableObject) return;
                
                _currentTreatmentableObject = newTreatmentableObject;
                _setPositionTransformEventChannel.RaiseTransformEvent(_raycastHit.transform);
                _showTooltipStringEventChannel.RaiseStrigEvent(_currentTreatmentableObject.GetQuestName());
            }
            else if (_currentTreatmentableObject != null)
            {
                _currentTreatmentableObject = null;
                _hideTooltipVoidEventChannel.RaiseVoidEvent();
            }
        }

        private void CharacterPickedUpAnObject(bool value)
        {
            _characterPickedUpAnObject = value;
        } 
    }
}