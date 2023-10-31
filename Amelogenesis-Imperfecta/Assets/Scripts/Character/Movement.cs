using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    private CharacterInputs _characterInputs;
    [SerializeField] private float _speed;
    [SerializeField] private float _minMagnitudeToRotating;
    [SerializeField] private float _turnSmoothTime;
    private float _currentVelocity;


    private void Awake()
    {
        _characterInputs = new CharacterInputs();
        _characterInputs.Enable();
    }

    void FixedUpdate()
    {
        var movementInput = _characterInputs.CharacterActionMap.Movement.ReadValue<Vector2>();
        var direction = new Vector3(movementInput.x, 0f, movementInput.y);

        if (direction.magnitude >= _minMagnitudeToRotating)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        }

        _characterController.Move(direction * (_speed * Time.deltaTime));
    }
}
