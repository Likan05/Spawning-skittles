using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;

    private void Awake()
    {
        _transform = gameObject.transform;
    }

    private void Update()
    {
        _transform.Translate(0, 0, _speed * Time.deltaTime * -1);
    }
}
