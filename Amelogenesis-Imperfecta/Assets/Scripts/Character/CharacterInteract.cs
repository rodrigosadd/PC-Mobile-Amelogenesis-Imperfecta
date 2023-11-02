using Interfaces;
using UnityEngine;

namespace Character
{
    public class CharacterInteract : MonoBehaviour
    {
        [SerializeField] private Transform _targetLookDirection;
        [SerializeField] private float _maxDistanceToInteract;
        private RaycastHit _raycastHit;
        private CharacterInputs _characterInputs;

        private void Awake()
        {
            _characterInputs = new CharacterInputs();
            _characterInputs.Enable();
        }

        private void OnEnable()
        {
            _characterInputs.CharacterActionMap.Interact.performed += ctx => InteractWithObject();
        }

        private void OnDisable()
        {
            _characterInputs.CharacterActionMap.Interact.performed -= ctx => InteractWithObject();
        }

        private void InteractWithObject()
        {
            if (!Physics.Raycast(_targetLookDirection.position, _targetLookDirection.forward, out _raycastHit, _maxDistanceToInteract)) return;

            if (!_raycastHit.transform.TryGetComponent(out IInteractable interactable)) return;
            
            Debug.Log("Interacted with object!!!");
            interactable.Interact();
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
