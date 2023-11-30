using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Event Channels/String", fileName = "String Event Channel")]
    public class StringEventChannelSO : ScriptableObject
    {
        public UnityAction<string> OnStringRequested;
        
        public void RaiseStrigEvent(string value)
        {
            if (OnStringRequested != null)
            {
                OnStringRequested.Invoke(value);
            }
            else
            {   
                Debug.Log("String Event is null!!!");
            }
        }
    }
}