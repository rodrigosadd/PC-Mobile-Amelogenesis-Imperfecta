using UnityEngine;
using UnityEngine.Events;

namespace Trigger_Objects
{
    public class CheckItensPlaced : MonoBehaviour
    {
        [SerializeField] private LayerMask _firstItemLayerCheck;
        [SerializeField] private LayerMask _secondItemLayerCheck;
        [SerializeField] private bool _firstItemWasPlaced;
        [SerializeField] private bool _secondItemWasPlaced;
        [SerializeField] private UnityEvent _OnItensWasPlaced;
        [SerializeField] private UnityEvent _OnItemsWasntPlaced;

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & _firstItemLayerCheck) != 0)
            {
                _firstItemWasPlaced = true;
            }
            else if (((1 << other.gameObject.layer) & _secondItemLayerCheck) != 0)
            {
                _secondItemWasPlaced = true;
            }
            
            CheckItensWasPlaced();
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (((1 << other.gameObject.layer) & _firstItemLayerCheck) != 0)
            {
                _firstItemWasPlaced = false;
            }
            else if (((1 << other.gameObject.layer) & _secondItemLayerCheck) != 0)
            {
                _secondItemWasPlaced = false;
            }
            
            CheckItensWasPlaced();
        }
        
        private void CheckItensWasPlaced()
        {
            if (_firstItemWasPlaced && _secondItemWasPlaced)
            {
                _OnItensWasPlaced?.Invoke();
            }
            else
            {
                _OnItemsWasntPlaced?.Invoke();
            }
        }
    }
}