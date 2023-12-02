using Scriptable_Objects.Channels;
using UnityEngine;

namespace UI
{
    public class SetActiveGameObject : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _setActiveBoolEventChannel;
        [SerializeField] private GameObject _gameObjectToSetActive;

        private void Start()
        {
            _setActiveBoolEventChannel.OnBoolRequested += SetActiveMenu;
        }
        
        private void OnDisable()
        {
            _setActiveBoolEventChannel.OnBoolRequested -= SetActiveMenu;
        }

        private void SetActiveMenu(bool value)
        {
            _gameObjectToSetActive.SetActive(value);
        }
    }
}