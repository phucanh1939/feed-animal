// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global

using GG.Base;
using UnityEngine;
using UnityEngine.Events;

namespace GG.Events
{
    [CreateAssetMenu(fileName = "TwoGameObjectEvent", menuName = "Events/GameObject, GameObject", order = 0)]
    public class TwoGameObjectsEventChannelSO : DescriptionBaseSO
    {
        public UnityAction<GameObject,GameObject> onEventRaised;
        public void RaiseEvent(GameObject gameObjectA, GameObject gameObjectB) => onEventRaised?.Invoke(gameObjectA, gameObjectB);
    }
}