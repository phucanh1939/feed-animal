using GG.Attributes;
using UnityEngine;

namespace GG.Events
{
    public class RaiseVoidEventOnTriggerEnter : MonoBehaviour
    {
        [TagSelector] [SerializeField] private string _targetTag;
        [SerializeField] private VoidEventChannelSO _eventToRaise;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_targetTag))
            {
                _eventToRaise.RaiseEvent();
            }
        }
    }
}