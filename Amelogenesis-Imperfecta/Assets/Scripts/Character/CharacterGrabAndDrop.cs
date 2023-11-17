using Interfaces;
using UnityEngine;

namespace Character
{
    public class CharacterGrabAndDrop : MonoBehaviour
    {
        [SerializeField] private Transform _targetLookDirection;
        [SerializeField] private Transform _grabPoint;
        [SerializeField] private float _maxDistanceToInteract;
        private RaycastHit _raycastHit;
        private CharacterInputs _characterInputs;
        private IGrabbable _currentGrabbableObject;

        private void Awake()
        {
            _characterInputs = new CharacterInputs();
            _characterInputs.Enable();
        }

        private void OnEnable()
        {
            _characterInputs.CharacterActionMap.Grab.performed += ctx => GrabObject();
            _characterInputs.CharacterActionMap.Drop.performed += ctx => DropObject();
        }

        private void OnDisable()
        {
            _characterInputs.CharacterActionMap.Grab.performed -= ctx => GrabObject();
            _characterInputs.CharacterActionMap.Drop.performed -= ctx => DropObject();
        }

        private void GrabObject()
        {
            if (!Physics.Raycast(_targetLookDirection.position, _targetLookDirection.forward, out _raycastHit, _maxDistanceToInteract)) return;

            if (!_raycastHit.transform.TryGetComponent(out _currentGrabbableObject)) return;
            
            Debug.Log("Interacted with object!!!");
            _currentGrabbableObject.Grab(_grabPoint);
        }

        private void DropObject()
        {
            _currentGrabbableObject.Drop();
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
