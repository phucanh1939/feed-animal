using System;
using GG.Events;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private int _startLives = 3;
    [Header("Movable Range")]
    [SerializeField] private float _minX = -25.0f;
    [SerializeField] private float _maxX = 25.0f;
    [SerializeField] private float _minZ = -10.0f;
    [SerializeField] private float _maxZ = 10.0f;

    [Header("Events Listen to")]
    [SerializeField] private VoidEventChannelSO _onFoodHitAnimal;
    [SerializeField] private VoidEventChannelSO _onAnimalHitHome;

    [Header("Events Raised")]
    [SerializeField] private IntEventChannelSO _onScoreUpdated;
    [SerializeField] private IntEventChannelSO _onLivesUpdated;
    [SerializeField] private VoidEventChannelSO _dead;

    private int _lives;
    private int _score;

    private float _verticalInput;
    private float _horizontalInput;
    private Transform _transform;

    #region Unity callbacks

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        SetScore(0);
        SetLives(_startLives);
    }

    private void OnEnable()
    {
        _onFoodHitAnimal.onEventRaised += OnFoodHitAnimal;
        _onAnimalHitHome.onEventRaised += OnAnimalHitHome;
    }

    private void OnDisable()
    {
        _onFoodHitAnimal.onEventRaised -= OnFoodHitAnimal;
        _onAnimalHitHome.onEventRaised -= OnAnimalHitHome;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            OnAnimalHit();
        }
    }

    #endregion

    #region Events

    private void OnAnimalHit()
    {
        SetLives(_lives - 1);
    }

    private void OnFoodHitAnimal()
    {
        SetScore(_score + 1);
    }

    private void OnAnimalHitHome()
    {
        SetLives(_lives - 1);
    }

    #endregion

    #region Movement

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

    #endregion

    #region Throw Food

    private void SpawnFood()
    {
        var transformPosition = _transform.position;
        var position = new Vector3(transformPosition.x, 0.5f, transformPosition.z);
        Instantiate(_foodPrefab, position, _transform.rotation);
    }

    #endregion

    #region Score, Lives, Dead

    public void SetScore(int score)
    {
        if (_score == score) return;
        _score = score;
        _onScoreUpdated.RaiseEvent(score);
    }

    public void SetLives(int lives)
    {
        if (_lives == lives) return;
        _lives = lives;
        if (_lives <= 0) Dead();
        _onLivesUpdated.RaiseEvent(_lives);
    }

    private void Dead()
    {
        _dead.RaiseEvent();
    }

    #endregion
}
