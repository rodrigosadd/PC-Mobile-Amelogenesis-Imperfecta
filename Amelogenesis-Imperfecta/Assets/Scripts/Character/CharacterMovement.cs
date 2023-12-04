using UnityEngine;
using Character_Inputs;
using Scriptable_Objects.Channels;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _blockPlayerActionsBoolEventChannel;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _speed;
        [SerializeField] private float _groundDistance;
        [SerializeField] private float _gravity = -9.81f;

        private Vector3 _velocity;
        private bool _isGrounded;
        private bool _actionsBlocked;
        
        private void Start()
        {
            _blockPlayerActionsBoolEventChannel.OnBoolRequested += SetBoolEventChannel;
        }

        private void OnDisable()
        {
            _blockPlayerActionsBoolEventChannel.OnBoolRequested -= SetBoolEventChannel;
        }
        
        void Update()
        {
            if (_actionsBlocked) return;

            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayer);

            if (_isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -2f;
            }
            
            var movementInput = CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Movement.ReadValue<Vector2>();
            //Debug.Log(CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Movement.ReadValue<Vector2>());
            var direction = transform.right * movementInput.x + transform.forward * movementInput.y;
        
            _characterController.Move(direction * (_speed * Time.deltaTime));

            _velocity.y += _gravity * Time.deltaTime;

            _characterController.Move(_velocity * Time.deltaTime);
        }
        
        private void SetBoolEventChannel(bool value)
        {
            _actionsBlocked = value;
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
