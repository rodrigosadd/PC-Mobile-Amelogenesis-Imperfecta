using UnityEngine;
using Character_Inputs;

namespace Character
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity;
        [SerializeField] private Transform _characterBody;
        [SerializeField] private float _clampXRotationMin;
        [SerializeField] private float _clampXRotationMax;
        private float _xRotation;
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var mousePosition = CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.MouseLook.ReadValue<Vector2>() * (_mouseSensitivity * Time.deltaTime);
            
            _xRotation -= mousePosition.y;
            _xRotation = Mathf.Clamp(_xRotation, _clampXRotationMin, _clampXRotationMax);
            
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _characterBody.Rotate(Vector3.up * mousePosition.x);
        }
    }
}