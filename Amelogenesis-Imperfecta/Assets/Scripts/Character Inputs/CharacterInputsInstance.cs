using System;
using UnityEngine;

namespace Character_Inputs
{
    public class CharacterInputsInstance : MonoBehaviour
    {
        private static CharacterInputsInstance _instance;
        private CharacterInputs _characterInputs;
        
        private void Awake()
        {
            _instance = this;
            
            _characterInputs = new CharacterInputs();
            _characterInputs.Enable();
        }

        public static CharacterInputs GetCharacterInputs()
        {
            return _instance._characterInputs;
        }
    }
}