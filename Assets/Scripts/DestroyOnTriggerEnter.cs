using GG.Attributes;
using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour
{
    [TagSelector] [SerializeField] private string _targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_targetTag))
        {
            Destroy(gameObject);
        }
    }
}
