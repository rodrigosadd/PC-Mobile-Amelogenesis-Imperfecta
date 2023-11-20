using UnityEngine;
using Character_Inputs;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundDistance;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _gravity = -9.81f;
        private Vector3 _velocity;
        private bool _isGrounded;
        
        void Update()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayer);

            if (_isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -2f;
            }
            
            var movementInput = CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Movement.ReadValue<Vector2>();
            var direction = transform.right * movementInput.x + transform.forward * movementInput.y;
        
            _characterController.Move(direction * (_speed * Time.deltaTime));

            _velocity.y += _gravity * Time.deltaTime;

            _characterController.Move(_velocity * Time.deltaTime);
        }
        
#if DEBUG_MODE
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_groundCheck.position, _groundDistance);
        }
#endif
    }
}
