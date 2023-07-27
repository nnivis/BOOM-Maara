using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class SpawnComponent : MonoBehaviour
    {
        GameObject _enemyPrefab;
        GameObject _characterPrefab;
        int _enemyNumber = 6;
        float _spawnRadius = 30f;
        float _timeSpawns = 1f;
        float _timeSpawnsWawes = 2f;
        bool _spawn = true;


        public void SetSpawnInfo(GameObject enemyPrefab, GameObject characterPrefab)
        {
            _enemyPrefab = enemyPrefab;
            _characterPrefab = characterPrefab;
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnEnemy());
            SpawnCharacter();
        }

        void SpawnCharacter()
        {
            var character = Instantiate(_characterPrefab, transform.position, Quaternion.identity);
        }
        IEnumerator SpawnEnemy()
        {

            while (_spawn)
            {
                float angleStep = 360f / _enemyNumber;

                for (int i = 0; i < _enemyNumber; i++)
                {
                    float angle = i * angleStep;
                    Vector2 spawnPosition = CalculateCirclePosition(angle);
                    var monster = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
                    yield return new WaitForSeconds(_timeSpawns);

                }

                yield return new WaitForSeconds(_timeSpawnsWawes);
            }
        }

        Vector2 CalculateCirclePosition(float angle)
        {
            float radians = angle * Mathf.Deg2Rad;
            float x = transform.position.x + _spawnRadius * Mathf.Cos(radians);
            float y = transform.position.y + _spawnRadius * Mathf.Sin(radians);

            return new Vector2(x, y);
        }

    }
}

