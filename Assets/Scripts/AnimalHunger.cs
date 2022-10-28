using GG.Events;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private int _amountToBeFed;

    [Header("Events Raised")]
    [SerializeField] private VoidEventChannelSO _onAnimalFull;

    private int _fedAmount;

    private void Start()
    {
        _slider.maxValue = _amountToBeFed;
        _slider.value = 0;
        _fedAmount = 0;
        _slider.fillRect.gameObject.SetActive(false);
    }

    private void Feed(int amount)
    {
        _fedAmount += amount;
        _slider.fillRect.gameObject.SetActive(true);
        _slider.value = _fedAmount;
        if (_fedAmount >= _amountToBeFed)
        {
            OnFull();
        }
    }

    private void OnFull()
    {
        _onAnimalFull.RaiseEvent();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Feed(1);
        }
    }
}
