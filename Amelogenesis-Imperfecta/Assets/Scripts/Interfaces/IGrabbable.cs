using UnityEngine;

namespace Interfaces
{
    public interface IGrabbable
    {
        public void PickupObject(Transform position);
        public void DropObject();
        public void MoveObject(Transform holdArea, float pickUpForce);
        public void ThrowObject(Transform direction, float throwForce);
        public void SetPosition(Vector3 position);
    }
}