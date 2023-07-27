using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class EnemyManager : MonoBehaviour
    {
        List<GameObject> enemies = new List<GameObject>();

        public void RegisterEnemy(GameObject enemy)
        {
            enemies.Add(enemy);
        }

        public void UnregisterEnemy(GameObject enemy)
        {
            enemies.Remove(enemy);
        }

        public void RemoveAllEnemies()
        {
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
            enemies.Clear();
        }
    }
}
