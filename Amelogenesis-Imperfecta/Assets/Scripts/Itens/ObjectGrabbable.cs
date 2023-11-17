using Interfaces;
using UnityEngine;

namespace Itens
{
    public class ObjectGrabbable : MonoBehaviour, IGrabbable
    {
        [SerializeField] private Rigidbody _rbody;
        private CharacterInputs _characterInputs;
        
        public void Grab(Transform holderPosition)
        {
            transform.position = holderPosition.position;
            transform.parent = holderPosition;
            _rbody.isKinematic = true;
        }

        public void Drop()
        {
            transform.parent = null;
            _rbody.isKinematic = false;
        }
    }
}