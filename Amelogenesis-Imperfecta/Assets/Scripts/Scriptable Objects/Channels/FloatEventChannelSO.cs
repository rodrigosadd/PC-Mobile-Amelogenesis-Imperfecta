using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Event Channels/Float", fileName = "Float Event Channel")]
    public class FloatEventChannelSO : ScriptableObject
    {
        public UnityAction<float> OnFloatRequested;

        public void RaiseFloatEvent(float value)
        {
            if (OnFloatRequested != null)
            {
                OnFloatRequested.Invoke(value);
            }
            else
            {
                Debug.Log("Float Event is null!!!");
            }
        }
    }
}