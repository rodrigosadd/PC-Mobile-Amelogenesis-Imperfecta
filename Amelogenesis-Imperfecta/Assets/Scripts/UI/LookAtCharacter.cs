using UnityEngine;

namespace UI
{
    public class LookAtCharacter : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            if(_camera == null) return;
                
            transform.LookAt(_camera.transform, Vector3.up);
        }
    }
}