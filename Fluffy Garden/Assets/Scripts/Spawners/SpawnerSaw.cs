using System.Collections;
using System.Collections.Generic;
using Store.Items;
using UnityEngine;

namespace Spawners
{
    public class SpawnerSaw : MonoBehaviour
    {
        [SerializeField] private GameObject _saw;
        [SerializeField] private Transform _parentComponent;
        [SerializeField] private List<Transform> _spawnPoints = new();
        [SerializeField] private float _delay;
        private const float DelayDoubleSpawn = 0.5f;

        private int _counter;

        private void Start()
        {
            StartCoroutine(SpawnSaws());
        }

        private IEnumerator SpawnSaws()
        {
            while (true)
            {
                var indexSpawnPoint = Random.Range(0, _spawnPoints.Count);

                if (_counter % 4 == 0)
                {
                    InstantiateSaw(indexSpawnPoint);
                    yield return new WaitForSeconds(DelayDoubleSpawn);
                }

                InstantiateSaw(indexSpawnPoint);

                _counter++;
                yield return new WaitForSeconds(_delay);
            }
        }

        private void InstantiateSaw(int indexSpawnPoint)
        {
            Instantiate(_saw, 
                        _spawnPoints[indexSpawnPoint].transform.position, 
                        _spawnPoints[indexSpawnPoint].rotation, 
                        _parentComponent);
        }
    }
}

