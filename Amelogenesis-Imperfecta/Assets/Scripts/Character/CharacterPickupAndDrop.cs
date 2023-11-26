using Interfaces;
using UnityEngine;
using Character_Inputs;
using UnityEngine.Serialization;

namespace Character
{
    public class CharacterPickupAndDrop : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerToPickup;
        [SerializeField] private Transform _targetLookDirection;
        [SerializeField] private Transform _holdArea;
        [SerializeField] private float _pickupRange = 5f;
        [SerializeField] private float _pickupForce = 150f;
        [SerializeField] private float _throwForce;
        
        private RaycastHit _raycastHit;
        private IGrabbable _currentGrabbableObject;

        private void Start()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Grab.performed += ctx => Pickup();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Throw.performed += ctx => Throw();
        }

        private void OnDisable()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Grab.performed -= ctx => Pickup();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Throw.performed -= ctx => Throw();
        }

        private void Update()
        {
            UpdateGrabbableObjectPosition();
        }

        private void Pickup()
        {
            if (_currentGrabbableObject == null)
            {
                if (!Physics.Raycast(_targetLookDirection.position, _targetLookDirection.forward, out _raycastHit, _pickupRange, _layerToPickup)) return;
                    
                _currentGrabbableObject = _raycastHit.transform.GetComponentInParent<IGrabbable>();
                _currentGrabbableObject.PickupObject(_holdArea);
            }
            else
            {
                _currentGrabbableObject.DropObject();
                _currentGrabbableObject = null;
            }
        }

        private void UpdateGrabbableObjectPosition()
        {
            _currentGrabbableObject?.MoveObject(_holdArea, _pickupForce);
        }

        private void Throw()
        {
            _currentGrabbableObject?.ThrowObject(_targetLookDirection, _throwForce);
            _currentGrabbableObject = null;
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
