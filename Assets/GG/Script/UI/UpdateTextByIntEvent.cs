using GG.Events;
using TMPro;
using UnityEngine;

namespace GG.UI
{
    public class UpdateTextByIntEvent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private IntEventChannelSO _eventOnValueChanged;

        private void OnEnable()
        {
            _eventOnValueChanged.onEventRaised += OnValueChanged;
        }

        private void OnDisable()
        {
            _eventOnValueChanged.onEventRaised -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            _text.text = value.ToString();
        }
    }
}