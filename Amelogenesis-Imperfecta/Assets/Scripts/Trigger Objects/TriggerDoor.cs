using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class TriggerDoor : MonoBehaviour
    {
        [SerializeField] private LayerMask _triggerLayerMask;
        [SerializeField] private BoolEventChannelSO _boolEventChannel;
        [SerializeField] private UnityEvent _onTriggerEnter;
        [SerializeField] private UnityEvent _onTriggerExit;
        
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & _triggerLayerMask) == 0) return;
            
            _boolEventChannel.RaiseBoolEvent(true);
            _onTriggerEnter?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (((1 << other.gameObject.layer) & _triggerLayerMask) == 0) return;
            
            _boolEventChannel.RaiseBoolEvent(false);
            _onTriggerExit?.Invoke();
        }
    }
}