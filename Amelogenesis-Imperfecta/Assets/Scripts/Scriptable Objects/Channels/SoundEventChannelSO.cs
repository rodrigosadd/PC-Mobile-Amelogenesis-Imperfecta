using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Event Channels/Sound", fileName = "Sound Event Channel")]
    public class SoundEventChannelSO : ScriptableObject
    {
        public UnityAction<SoundSO> OnSoundRequested;

        public void RaiseSoundEvent(SoundSO sound)
        {
            if (OnSoundRequested != null)
            {
                OnSoundRequested.Invoke(sound);
            }
            else
            {   
                Debug.Log("Sound Event is null!!!");
            }
        }
    }
}