// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "VoidEvent", menuName = "Events/void", order = 0)]
    public class VoidEventChannelSO : DescriptionBaseSO
    {
        public UnityAction onEventRaised;
        public void RaiseEvent() => onEventRaised?.Invoke();
    }
}