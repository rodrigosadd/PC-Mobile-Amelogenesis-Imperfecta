using Interfaces;
using UnityEngine;

namespace Itens
{
    public class ObjectGrabbable : MonoBehaviour, IGrabbable
    {
        [SerializeField] private Rigidbody _rbody;
        private CharacterInputs _characterInputs;
        
        public void GrabObject(Transform holderPosition)
        {
            transform.position = holderPosition.position;
            transform.parent = holderPosition;
            _rbody.isKinematic = true;
        }

        public void DropObject()
        {
            transform.parent = null;
            _rbody.isKinematic = false;
        }

        public void ThrowObject(Transform direction, float throwForce)
        {
            transform.parent = null;
            _rbody.isKinematic = false;
            _rbody.velocity = direction.forward * throwForce;
        } 
    }
}