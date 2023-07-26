using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] GameObject _enemySpawnPrefab;
        [SerializeField] SpawnComponent _spawner;

        void Start()
        {
            _spawner.SetSpawnInfo(_enemySpawnPrefab);
            _spawner.StartSpawning();
        }

    }
}
