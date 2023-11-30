using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Event Channels/Transform", fileName = "Transform Event Channel")]
    public class TransformEventChannelSO : ScriptableObject
    {
        public UnityAction<Transform> OnTransformRequested;
        
        public void RaiseTransformEvent(Transform position)
        {
            if (OnTransformRequested != null)
            {
                OnTransformRequested.Invoke(position);
            }
            else
            {   
                Debug.Log("Transform Event is null!!!");
            }
        }
    }
}