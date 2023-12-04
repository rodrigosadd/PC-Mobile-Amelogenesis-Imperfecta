using Interfaces;
using UnityEngine;
using Character_Inputs;
using Scriptable_Objects.Channels;

namespace Character
{
    public class CharacterPickupAndDrop : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _blockPlayerActionsBoolEventChannel;
        [SerializeField] private BoolEventChannelSO _PickedUpAnObjectBoolEventChannel;
        [SerializeField] private VoidEventChannelSO _pickupVoidEventChannel;
        [SerializeField] private VoidEventChannelSO _throwVoidEventChannel;
        [SerializeField] private VoidEventChannelSO _hideTooltipVoidEventChannel;
        [SerializeField] private VoidEventChannelSO _resetPickupVoidEventChannel;
        [SerializeField] private LayerMask _layerToPickup;
        [SerializeField] private Transform _targetLookDirection;
        [SerializeField] private Transform _holdArea;
        [SerializeField] private float _pickupRange = 5f;
        [SerializeField] private float _pickupForce = 150f;
        [SerializeField] private float _throwForce;

        private RaycastHit _raycastHit;
        private IGrabbable _currentGrabbableObject;
        private bool _actionsBlocked;

        private void Start()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Grab.performed += ctx => Pickup();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Throw.performed += ctx => Throw();

            _pickupVoidEventChannel.OnVoidRequested += Pickup;
            _throwVoidEventChannel.OnVoidRequested += Throw;
            _resetPickupVoidEventChannel.OnVoidRequested += ResetPickup;
            _blockPlayerActionsBoolEventChannel.OnBoolRequested += SetBlockActionsBoolEventChannel;
        }

        private void OnDisable()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Grab.performed -= ctx => Pickup();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Throw.performed -= ctx => Throw();
            
            _pickupVoidEventChannel.OnVoidRequested -= Pickup;
            _throwVoidEventChannel.OnVoidRequested -= Throw;
            _resetPickupVoidEventChannel.OnVoidRequested -= ResetPickup;
            _blockPlayerActionsBoolEventChannel.OnBoolRequested -= SetBlockActionsBoolEventChannel;
        }

        private void Update()
        {
            if (_actionsBlocked) return;
            
            UpdateGrabbableObjectPosition();
        }
        
        private void Pickup()
        {
            if (_actionsBlocked) return;
            
            if (!Physics.Raycast(_targetLookDirection.position, _targetLookDirection.forward, out _raycastHit, _pickupRange, _layerToPickup)) return;
            
            if (_currentGrabbableObject == null)
            {
                _currentGrabbableObject = _raycastHit.transform.GetComponentInParent<IGrabbable>();
                _currentGrabbableObject.PickupObject(_holdArea);
                _hideTooltipVoidEventChannel.RaiseVoidEvent();
                _PickedUpAnObjectBoolEventChannel.RaiseBoolEvent(true);
            }
            else
            {
                _currentGrabbableObject.DropObject();
                _currentGrabbableObject = null;
                _PickedUpAnObjectBoolEventChannel.RaiseBoolEvent(false);
            }
        }

        private void UpdateGrabbableObjectPosition()
        {
            _currentGrabbableObject?.MoveObject(_holdArea, _pickupForce);
        }

        private void Throw()
        {
            if (_actionsBlocked) return;
            
            _currentGrabbableObject?.ThrowObject(_targetLookDirection, _throwForce);
            _currentGrabbableObject = null;
            _PickedUpAnObjectBoolEventChannel.RaiseBoolEvent(false);
        }

        private void ResetPickup()
        {
            if(_currentGrabbableObject == null) return;
            
            _currentGrabbableObject.DropObject();
            _currentGrabbableObject = null;
            _PickedUpAnObjectBoolEventChannel.RaiseBoolEvent(false);
        }
        
        private void SetBlockActionsBoolEventChannel(bool value)
        {
            _actionsBlocked = value;
        }
        
#if DEBUG_MODE
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_targetLookDirection.position, _targetLookDirection.position + (_targetLookDirection.forward * _pickupRange));
        }
#endif
    }
}
