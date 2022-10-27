using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnXRange = 20;
    [SerializeField] private float _spawnZ = 20;
    [SerializeField] private float _spawnInterval = 1.5f;
    [SerializeField] private float _spawnDelay = 2.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), _spawnDelay, _spawnInterval);
    }

    private void Update()
    {

    }

    private GameObject GetRandomPrefab()
    {
        var index = Random.Range(0, _prefabs.Length);
        return _prefabs[index];
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var x = Random.Range(-_spawnXRange, _spawnXRange);
        return new Vector3(x, 0, _spawnZ);
    }

    private void SpawnRandomAnimal()
    {
        var prefab = GetRandomPrefab();
        var position = GetRandomSpawnPosition();
        var rotation = prefab.transform.rotation;
        Instantiate(prefab, position, rotation);
    }
}
