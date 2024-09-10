using GameItems;
using PlayerControllers;
using UnityEngine;

namespace Spawners
{
    public class SpawnerBonus : MonoBehaviour
    {
        [SerializeField] private GameObject _bonus;
        [SerializeField] private Transform _parentComponent;
        private int _counter;

        private void OnEnable()
        {
            Saw.OnSpawnBonus += SpawnBonus;
            SawChecker.OnResetCounterBonus += ResetCounter;
        }

        private void OnDisable()
        {
            Saw.OnSpawnBonus -= SpawnBonus;
            SawChecker.OnResetCounterBonus -= ResetCounter;
        }

        private void SpawnBonus(Vector3 position)
        {
            if (_counter > 0)
            {
                var tempCounter = _counter;
                
                while (tempCounter >= 0)
                {
                    InstantiateBonus(position);
                    tempCounter--;
                }
                _counter++;
            }
            else
            {
                InstantiateBonus(position);

            }

            _counter++;
        }

        private void ResetCounter()
        {
            _counter = 0;
        }

        private void InstantiateBonus(Vector3 position)
        {
            Instantiate(_bonus, position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f), Quaternion.identity, _parentComponent);
        }
    }
}

