using Scriptable_Objects;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace Character
{
    public class SetCursorStateAndVisibility : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _setCursorVisibilityBoolEventChannel;
        [SerializeField] private CursorLockModeEventChannelSO _cursorLockModeEventChannelSOEventChannel;
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            SetCursorVisibility(false);
        }

        private void OnEnable()
        {
            _setCursorVisibilityBoolEventChannel.OnBoolRequested += SetCursorVisibility;
            _cursorLockModeEventChannelSOEventChannel.OnCursorLockModeRequested += SetCursorLockState;
        }

        private void OnDisable()
        {
            _setCursorVisibilityBoolEventChannel.OnBoolRequested -= SetCursorVisibility;
            _cursorLockModeEventChannelSOEventChannel.OnCursorLockModeRequested -= SetCursorLockState;
        }

        private void SetCursorLockState(CursorLockModeSO mode)
        {
            Cursor.lockState = mode.cursorLockMode;
        }
        
        private void SetCursorVisibility(bool value)
        {
            Cursor.visible = value;
        }
    }
}