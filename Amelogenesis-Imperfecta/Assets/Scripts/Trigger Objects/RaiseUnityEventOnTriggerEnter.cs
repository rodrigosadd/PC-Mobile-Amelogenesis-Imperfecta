using UnityEngine;
using UnityEngine.Events;

public class RaiseUnityEventOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private LayerMask _triggerLayerMask;
    [Space]
    [SerializeField] private UnityEvent _onTrigger;
    [SerializeField] private UnityEvent _onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _triggerLayerMask) == 0) return;
        
        _onTrigger?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _triggerLayerMask) == 0) return;
        
        _onTriggerExit?.Invoke();
    }
}
