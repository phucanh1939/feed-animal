using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private GameObject _foodPrefab;
    [Header("Movable Range")]
    [SerializeField] private float _minX = -25.0f;
    [SerializeField] private float _maxX = 25.0f;
    [SerializeField] private float _minZ = -10.0f;
    [SerializeField] private float _maxZ = 10.0f;

    private float _verticalInput;
    private float _horizontalInput;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFood();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        KeepPlayerInRange();
    }

    private void MovePlayer()
    {
        var direction = Vector3.right * _horizontalInput + Vector3.forward * _verticalInput;
        _transform.Translate(_speed * Time.fixedDeltaTime * direction);
    }

    private void KeepPlayerInRange()
    {
        var position = _transform.position;
        var x = Mathf.Max(Mathf.Min(position.x, _maxX), _minX);
        var z = Mathf.Max(Mathf.Min(position.z, _maxZ), _minZ);
        _transform.position = new Vector3(x, position.y, z);
    }

    private void SpawnFood()
    {
        var transformPosition = _transform.position;
        var position = new Vector3(transformPosition.x, 0.5f, transformPosition.z);
        Instantiate(_foodPrefab, position, _transform.rotation);
    }
}
