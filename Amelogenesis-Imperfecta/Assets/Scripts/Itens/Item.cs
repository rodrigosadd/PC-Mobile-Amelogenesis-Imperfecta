using Interfaces;
using UnityEngine;

namespace Itens
{
    public class Item : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Inside the item!!!");
        }
    }
}