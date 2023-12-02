using UnityEngine;
using UnityEngine.Events;

public class RaiseUnityEventOnStart : MonoBehaviour
{
    [SerializeField] private UnityEvent _onStart;
    
    void Start()
    {
        _onStart?.Invoke();
    }
}
