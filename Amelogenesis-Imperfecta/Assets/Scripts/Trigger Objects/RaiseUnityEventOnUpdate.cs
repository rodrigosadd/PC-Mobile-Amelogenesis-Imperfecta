using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class RaiseUnityEventOnUpdate : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onUpdate;

        private bool _hasTriggered;

        private void Update()
        {
            if (_hasTriggered) return;

            _hasTriggered = true;
            _onUpdate?.Invoke();
        }
    }
}