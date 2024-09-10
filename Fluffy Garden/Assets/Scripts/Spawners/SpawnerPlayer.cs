using PlayerMenu;
using UnityEngine;

namespace Spawners
{
    public class SpawnerPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Transform _spawnPoint;

        private void OnEnable()
        {
            PlayerMenuHandler.OnRespawnPlayer += SpawnPlayer;
        }

        private void OnDisable()
        {
            PlayerMenuHandler.OnRespawnPlayer -= SpawnPlayer;
        }

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Instantiate(
                _player, 
                new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, 0),
                Quaternion.identity);
        }
    }
}

