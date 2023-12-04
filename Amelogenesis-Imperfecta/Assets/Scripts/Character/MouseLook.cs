using UnityEngine;
using Character_Inputs;
using Scriptable_Objects.Channels;

namespace Character
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _blockPlayerActionsBoolEventChannel;
        [SerializeField] private Transform _characterBody;
        [SerializeField] private float _mouseSensitivity;
        [SerializeField] private float _clampXRotationMin;
        [SerializeField] private float _clampXRotationMax;

        private float _xRotation;
        private bool _actionsBlocked;
        
        private void Start()
        {
            _blockPlayerActionsBoolEventChannel.OnBoolRequested += SetBoolEventChannel;
        }

        private void OnDisable()
        {
            _blockPlayerActionsBoolEventChannel.OnBoolRequested -= SetBoolEventChannel;
        }
        
        private void Update()
        {
            if (_actionsBlocked) return;
            
            var mousePosition = CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.MouseLook.ReadValue<Vector2>() * (_mouseSensitivity * Time.deltaTime);
            
            _xRotation -= mousePosition.y;
            _xRotation = Mathf.Clamp(_xRotation, _clampXRotationMin, _clampXRotationMax);
            
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _characterBody.Rotate(Vector3.up * mousePosition.x);
        }
        
        private void SetBoolEventChannel(bool value)
        {
            _actionsBlocked = value;
        }
    }
}