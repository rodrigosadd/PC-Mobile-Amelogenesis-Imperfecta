using Interfaces;
using UnityEngine;
using Character_Inputs;

namespace Character
{
    public class CharacterGrabAndDrop : MonoBehaviour
    {
        [SerializeField] private Transform _targetLookDirection;
        [SerializeField] private Transform _grabPoint;
        [SerializeField] private float _maxDistanceToInteract;
        [SerializeField] private float _throwForceObject;
        private RaycastHit _raycastHit;
        private IGrabbable _currentGrabbableObject;
        
        private void OnEnable()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Grab.performed += ctx => GrabObject();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Drop.performed += ctx => DropObject();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Throw.performed += ctx => ThrowObject();
        }

        private void OnDisable()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Grab.performed -= ctx => GrabObject();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Drop.performed -= ctx => DropObject();
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Throw.performed -= ctx => ThrowObject();
        }

        private void GrabObject()
        {
            if (!Physics.Raycast(_targetLookDirection.position, _targetLookDirection.forward, out _raycastHit, _maxDistanceToInteract)) return;

            if (!_raycastHit.transform.TryGetComponent(out _currentGrabbableObject)) return;
            
            Debug.Log("Interacted with object!!!");
            _currentGrabbableObject.GrabObject(_grabPoint);
        }

        private void DropObject()
        {
            if (_currentGrabbableObject == null) return;

            _currentGrabbableObject.DropObject();
            _currentGrabbableObject = null;
        }

        private void ThrowObject()
        {
            if(_currentGrabbableObject != null) _currentGrabbableObject.ThrowObject(_targetLookDirection, _throwForceObject);
        }

#if DEBUG_MODE
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_targetLookDirection.position, _targetLookDirection.position + (_targetLookDirection.forward * _maxDistanceToInteract));
        }
#endif
    }
}
