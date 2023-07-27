using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BOOM
{
    public class GameManager : MonoBehaviour
    {
        static GameManager instance;
        public static GameManager Instance => instance;
        List<HealthComponent> _healthComponents = new List<HealthComponent>();
        List<IGameObserver> _deathListeners = new List<IGameObserver>();

        EnemyManager _enemyManager;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _enemyManager = GetComponent<EnemyManager>();
        }

        public void RegisterHealthComponent(HealthComponent healthComponent)
        {
            _healthComponents.Add(healthComponent);
            healthComponent.OnDead += OnDeath;
            healthComponent.OnDamage += OnDamage;

            if (healthComponent.CompareTag("Enemy"))
            {
                _enemyManager.RegisterEnemy(healthComponent.gameObject); // n.g
            }
        }

        public void UnregisterHealthComponent(HealthComponent healthComponent)
        {
            _healthComponents.Remove(healthComponent);
            healthComponent.OnDead -= OnDeath;
            healthComponent.OnDamage -= OnDamage;

            if (healthComponent.CompareTag("Enemy"))
            {
                _enemyManager.UnregisterEnemy(healthComponent.gameObject); // n.g
            }
        }

        public void RegisterDeathListener(IGameObserver listener)
        {
            _deathListeners.Add(listener);
        }

        public void UnregisterDeathListener(IGameObserver listener)
        {
            _deathListeners.Remove(listener);
        }

        public void OnDeath(GameObject gameObject)
        {
            Destroy(gameObject);
            foreach (var listener in _deathListeners)
            {
                listener.OnDeath(gameObject);
            }
        }

        public void OnDamage()
        {
        }
        public void EndGame()
        {
            _enemyManager.RemoveAllEnemies();
        }

    }
}
