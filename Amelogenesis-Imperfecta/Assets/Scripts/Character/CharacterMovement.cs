using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        private CharacterInputs _characterInputs;

        private void Awake()
        {
            _characterInputs = new CharacterInputs();
            _characterInputs.Enable();
        }

        void Update()
        {
            var movementInput = _characterInputs.CharacterActionMap.Movement.ReadValue<Vector2>();
            var direction = transform.right * movementInput.x + transform.forward * movementInput.y;
        
            _characterController.Move(direction * (_speed * Time.deltaTime));
        }
    }
}
