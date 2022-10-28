// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "GameObjectEvent", menuName = "Events/GameObject", order = 0)]
    public class GameObjectEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<GameObject> onEventRaised;
        public void RaiseEvent(GameObject gameObject) => onEventRaised?.Invoke(gameObject);
    }
}