using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
