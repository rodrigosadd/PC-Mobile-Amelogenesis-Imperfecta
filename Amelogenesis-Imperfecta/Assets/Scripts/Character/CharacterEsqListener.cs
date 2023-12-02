using Character_Inputs;
using Scriptable_Objects.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class CharacterEsqListener : MonoBehaviour
    {
        [SerializeField] private BoolEventChannelSO _setHasPressedFirstTimeBoolEventChannel;
        [SerializeField] private BoolEventChannelSO _areAllQuestsCompletedBoolEventChannel;
        [SerializeField] private UnityEvent _onPressEsqFirstTime;
        [SerializeField] private UnityEvent _onPressEsqSecondTime;

        private bool _hasPressedFirstTime;
        private bool _canRaiseEvent = true;
        
        private void Start()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Esq.performed += ctx => PressedEsq();
            _setHasPressedFirstTimeBoolEventChannel.OnBoolRequested += SetHasPressedFirstTimeBool;
            _areAllQuestsCompletedBoolEventChannel.OnBoolRequested += SetCanRaiseEvent;
        }

        private void OnDisable()
        {
            CharacterInputsInstance.GetCharacterInputs().CharacterActionMap.Esq.performed -= ctx => PressedEsq();
            _setHasPressedFirstTimeBoolEventChannel.OnBoolRequested -= SetCanRaiseEvent;
        }

        private void PressedEsq()
        {
            if(!_canRaiseEvent) return;
            
            if (!_hasPressedFirstTime)
            {
                _hasPressedFirstTime = true;
                _onPressEsqFirstTime?.Invoke();
            }
            else
            {
                _hasPressedFirstTime = false;
                _onPressEsqSecondTime?.Invoke();
            }
        }

        private void SetHasPressedFirstTimeBool(bool value)
        {
            _hasPressedFirstTime = value;
        }


        private void SetCanRaiseEvent(bool value)
        {
            _canRaiseEvent = !value;
        }
    }
}