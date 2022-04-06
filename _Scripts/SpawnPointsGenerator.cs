using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Material[] _material;

    private List<GameObject> _points;

    public List<GameObject> Points => _points;

    private void Awake()
    {
        _points = new List<GameObject>();

        int offsetFromPoint = -18;
        int offsetDistanse = 15;
        int numberOfSpawns = 3;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            int index = Random.Range(0,3);
            MeshRenderer mesh = _spawnPoint.GetComponent<MeshRenderer>();
            Transform positionPoint = _spawnPoint.GetComponent<Transform>();
            mesh.material = _material[index];
            GameObject spawnPoint = Instantiate(_spawnPoint, new Vector3(offsetFromPoint, 2, 50), Quaternion.identity);
            offsetFromPoint += offsetDistanse;
            positionPoint.position = new Vector3(offsetFromPoint, 2, 50);
            _points.Add(spawnPoint);
        }
    }
}
