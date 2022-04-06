using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGenerator : MonoBehaviour
{
    [SerializeField] private Bot _prefabBot;
    [SerializeField] private float _timeSpawn;

    private SpawnPointsGenerator _spawn;
    private List<Bot> _bots;

    private void OnValidate()
    {
        if (_timeSpawn <= 0)
            _timeSpawn = 2;
    }

    private void Start()
    {
        _bots = new List<Bot>();
        _spawn = GameObject.FindObjectOfType<SpawnPointsGenerator>();
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
            if (_bots[i].gameObject.GetComponent<Transform>().position.z < coordinateLimit)
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
 
        for (int i = 0; i < numberOfBots; i++)
        {
            int index = Random.Range(0, countSpawning);
            var position = _spawn.Points[index].GetComponent<Transform>();
            Bot newBot = Instantiate(_prefabBot, new Vector3(position.position.x, 8, position.position.z), Quaternion.identity);
            MeshRenderer meshBot = newBot.GetComponent<MeshRenderer>();
            meshBot.material = _spawn.Points[index].GetComponent<MeshRenderer>().material;
            yield return new WaitForSeconds(_timeSpawn);
            number++;
            _bots.Add(newBot);
            if (number >= countSpawning)
            {
                number = 0;
            }
        }
    }
}
