using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects.Channels
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Event Channels/Cursor Lock Mode", fileName = "Cursor Lock Mode Event Channel")]
    public class CursorLockModeEventChannelSO : ScriptableObject
    {
        public UnityAction<CursorLockModeSO> OnCursorLockModeRequested;
        
        public void RaiseCursorLockModeEvent(CursorLockModeSO mode)
        {
            if (OnCursorLockModeRequested != null)
            {
                OnCursorLockModeRequested.Invoke(mode);
            }
            else
            {
                Debug.Log("Cursor Lock Mode Event is null!!!");
            }
        }
    }
}