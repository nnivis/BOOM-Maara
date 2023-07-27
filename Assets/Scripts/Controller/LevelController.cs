using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] GameObject _enemySpawnPrefab;
        [SerializeField] GameObject _characterSpawnPrefab;
        [SerializeField] SpawnComponent _spawner;

        void OnEnable()
        {
            _spawner.SetSpawnInfo(_enemySpawnPrefab,_characterSpawnPrefab);
            _spawner.StartSpawning();
        }

    }
}
