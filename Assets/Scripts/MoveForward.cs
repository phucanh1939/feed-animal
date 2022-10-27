using System;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed = 40.0f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.Translate(Vector3.forward * (_speed * Time.fixedDeltaTime));
    }
}
