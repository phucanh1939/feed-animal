using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _xRange = 10.0f;
    [SerializeField] private GameObject _foodPrefab;

    private float _horizontalInput;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
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
        _transform.Translate(Vector3.right * (_horizontalInput * Time.fixedDeltaTime * _speed));
    }

    private void KeepPlayerInRange()
    {
        var position = _transform.position;
        if (position.x < -_xRange)
        {
            _transform.position = new Vector3(-_xRange, position.y, position.z);
        }
        else if (position.x > _xRange)
        {
            _transform.position = new Vector3(_xRange, position.y, position.z);
        }
    }

    private void SpawnFood()
    {
        var transformPosition = _transform.position;
        var position = new Vector3(transformPosition.x, 0.5f, transformPosition.z);
        Instantiate(_foodPrefab, position, _transform.rotation);
    }
}
