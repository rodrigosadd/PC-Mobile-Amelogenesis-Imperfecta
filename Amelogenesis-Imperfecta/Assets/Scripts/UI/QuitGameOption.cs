using System;
using Scriptable_Objects.Channels;
using UnityEngine;

namespace UI
{
    public class QuitGameOption : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO _quitVoidEventChannel;

        private void OnEnable()
        {
            _quitVoidEventChannel.OnVoidRequested += QuitGame;
        }

        private void OnDisable()
        {
            _quitVoidEventChannel.OnVoidRequested -= QuitGame;
        }

        private void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quit Game!!!");
        }
    }
}