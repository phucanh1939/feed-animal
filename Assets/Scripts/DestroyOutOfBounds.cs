using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float _minX = -30.0f;
    [SerializeField] private float _maxX = 30.0f;
    [SerializeField] private float _minZ = -10.0f;
    [SerializeField] private float _maxZ = 20.0f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        var position = _transform.position;
        if (position.z < _minZ || position.z > _maxZ || position.x < _minX || position.x > _maxX)
        {
            Destroy(gameObject);
        }
    }
}
