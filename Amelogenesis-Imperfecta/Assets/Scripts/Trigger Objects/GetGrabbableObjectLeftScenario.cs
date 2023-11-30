using Itens;
using UnityEngine;

namespace Trigger_Objects
{
    public class GetGrabbableObjectLeftScenario : MonoBehaviour
    {
        [SerializeField] private LayerMask _grabbableObjectLayer;
        [SerializeField] private Transform _target;
        
        private GrabbableObject _currentGrabbableObject;
        
        private void OnTriggerEnter(Collider other)
        {
            if(((1 << other.gameObject.layer) & _grabbableObjectLayer) == 0) return;

            _currentGrabbableObject = other.GetComponentInParent<GrabbableObject>();
            _currentGrabbableObject.SetPosition(_target.position);
        }
    }
}