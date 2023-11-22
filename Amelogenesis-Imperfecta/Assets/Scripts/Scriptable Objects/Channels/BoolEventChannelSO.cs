using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Event Channels/Bool", fileName = "Bool Event Channel")]
    public class BoolEventChannelSO : ScriptableObject
    {
        public UnityAction<bool> OnBoolRequested;
        
        public void RaiseBoolEvent(bool value)
        {
            if (OnBoolRequested != null)
            {
                OnBoolRequested.Invoke(value);
            }
            else
            {   
                Debug.Log("Bool Event is null!!!");
            }
        }
    }
}