using Interfaces;
using UnityEngine;

namespace Tooth
{
    public class ToothObject : MonoBehaviour
    {
        [SerializeField] private LayerMask _treatmentObject;

        private ITreatmentable _treatmentableObject;
        
        private void OnTriggerEnter(Collider other)
        {
            if(((1 << other.gameObject.layer) & _treatmentObject) == 0) return;

            _treatmentableObject = other.GetComponentInParent<ITreatmentable>();
            
            _treatmentableObject.QuestComplete();
        }
    }
}