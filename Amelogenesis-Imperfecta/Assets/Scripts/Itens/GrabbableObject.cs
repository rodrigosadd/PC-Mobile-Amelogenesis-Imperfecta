using Interfaces;
using UnityEngine;

namespace Itens
{
    public class GrabbableObject : MonoBehaviour, IGrabbable
    {
        [SerializeField] private Rigidbody _rbody;
        
        public void PickupObject(Transform holdArea)
        {
            _rbody.useGravity = false;
            _rbody.drag = 10f;
            _rbody.constraints = RigidbodyConstraints.FreezeRotation;

            _rbody.transform.parent = holdArea;
        }

        public void DropObject()
        {
            _rbody.useGravity = true;
            _rbody.drag = 1f;
            _rbody.constraints = RigidbodyConstraints.None;

            _rbody.transform.parent = null;
        }

        public void MoveObject(Transform holdArea, float pickUpForce)
        {
            if (!(Vector3.Distance(transform.position, holdArea.position) > 0.1f)) return;
            
            Vector3 moveDirection = holdArea.position - transform.transform.position;
            _rbody.AddForce(moveDirection * pickUpForce);
        }

        public void ThrowObject(Transform direction, float throwForce)
        {
            transform.parent = null;
            _rbody.useGravity = true;
            _rbody.drag = 1f;
            _rbody.constraints = RigidbodyConstraints.None;
            _rbody.AddForce(direction.forward * throwForce);
        }
        
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
            _rbody.velocity = Vector3.zero;
        }
    }
}