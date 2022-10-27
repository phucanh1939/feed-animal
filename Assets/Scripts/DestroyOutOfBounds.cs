using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float _top = 100;
    [SerializeField] private float _bot = -100;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        var position = _transform.position;
        if (position.z < _bot || position.z > _top)
        {
            if (gameObject.CompareTag("Animal"))
            {
                Debug.Log("Game Over!");
            }
            Destroy(gameObject);
        }
    }
}
