// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "IntEvent", menuName = "Events/int", order = 0)]
    public class IntEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<int> onEventRaised;
        public void RaiseEvent(int value) => onEventRaised?.Invoke(value);
    }
}