using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Event Channels/Void", fileName = "void Event Channel")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public UnityEvent OnVoidRequested;

        public void RaiseVoidEvent()
        {
            if (OnVoidRequested != null)
            {
                OnVoidRequested.Invoke();
            }
            else
            {   
                Debug.Log("Void Event is null!!!");
            }
        }
    }
}
