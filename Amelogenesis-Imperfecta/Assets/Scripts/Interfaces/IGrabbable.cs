using UnityEngine;

namespace Interfaces
{
    public interface IGrabbable
    {
        public void Grab(Transform position);
        public void Drop();
    }
}