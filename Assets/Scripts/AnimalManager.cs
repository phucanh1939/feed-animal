using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnInterval = 0.75f;
    [SerializeField] private float _spawnDelay = 2.0f;

    [Header("Spawn Range")]
    [SerializeField] private float _minX = -20.0f;
    [SerializeField] private float _maxX = 20.0f;
    [SerializeField] private float _minZ = 3.0f;
    [SerializeField] private float _maxZ = 10.0f;

    private static readonly Vector3 TopRotation = new Vector3(0.0f, 180.0f, 0.0f);
    private static readonly Vector3 LeftRotation = new Vector3(0.0f, 90.0f, 0.0f);
    private static readonly Vector3 RightRotation = new Vector3(0.0f, -90.0f, 0.0f);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAnimals), _spawnDelay, _spawnInterval);
    }

    private GameObject GetRandomPrefab()
    {
        var index = Random.Range(0, _prefabs.Length);
        return _prefabs[index];
    }

    private Vector3 GetRandomSpawnPositionTop()
    {
        var x = Random.Range(_minX, _maxX);
        return new Vector3(x, 0, _maxZ + 2.0f);
    }

    private Vector3 GetRandomSpawnPositionLeft()
    {
        var z = Random.Range(_minZ, _maxZ);
        return new Vector3(_minX - 2, 0, z);
    }

    private Vector3 GetRandomSpawnPositionRight()
    {
        var z = Random.Range(_minZ, _maxZ);
        return new Vector3(_maxX + 2, 0, z);
    }

    private void SpawnAnimals()
    {
        SpawnAnimalTop();
        SpawnAnimalLeft();
        SpawnAnimalRight();
    }

    private void SpawnAnimalTop()
    {
        SpawnAnimal(GetRandomSpawnPositionTop(), TopRotation);
    }

    private void SpawnAnimalLeft()
    {
        SpawnAnimal(GetRandomSpawnPositionLeft(), LeftRotation);
    }

    private void SpawnAnimalRight()
    {
        SpawnAnimal(GetRandomSpawnPositionRight(), RightRotation);
    }

    private void SpawnAnimal(Vector3 position, Vector3 rotation)
    {
        var prefab = GetRandomPrefab();
        Instantiate(prefab, position, Quaternion.Euler(rotation));
    }
}
