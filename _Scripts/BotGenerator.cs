using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGenerator : MonoBehaviour
{
    [SerializeField] private Bot _prefabBot;
    [SerializeField] private SpawnPointsGenerator _spawn;
    [SerializeField] private float _timeSpawn;

    private List<Bot> _bots;   

    private void OnValidate()
    {
        if (_timeSpawn <= 0)
            _timeSpawn = 2;
    }

    private void Start()
    {
        _bots = new List<Bot>();
        StartCoroutine(CreatNewBot());
    }

    private void Update()
    {
        RemoveWhoReachedLimit();
    }

    private void RemoveWhoReachedLimit()
    {
        int coordinateLimit = -20;

        for (int i = 0; i < _bots.Count; i++)
        {
            if (_bots[i].transform.position.z < coordinateLimit)
            {
                Destroy(_bots[i].gameObject);
                _bots.Remove(_bots[i]);
            }
        }
    }

    private IEnumerator CreatNewBot()
    {
        int numberOfBots = 100;
        int countSpawning = _spawn.Points.Count;
        int number = 0;
        var expectations = new WaitForSeconds(_timeSpawn);

        for (int i = 0; i < numberOfBots; i++)
        {
            int index = Random.Range(0, countSpawning);
            var position = _spawn.Points[index].transform.position;
            Bot newBot = Instantiate(_prefabBot, new Vector3(position.x, 8, position.z), Quaternion.identity);
            MeshRenderer meshBot = newBot.GetComponent<MeshRenderer>();
            meshBot.material = _spawn.Points[index].GetComponent<MeshRenderer>().material;
            yield return expectations;
            number++;
            _bots.Add(newBot);
            if (number >= countSpawning)
            {
                number = 0;
            }
        }
    }
}
