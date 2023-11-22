using UnityEngine;

namespace Interfaces
{
    public interface IGrabbable
    {
        public void GrabObject(Transform position);
        public void DropObject();
        public void ThrowObject(Transform direction, float throwForce);
    }
}