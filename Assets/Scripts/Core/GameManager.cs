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
        List<ICharacterDeathObserver> _deathCharacterListeners = new List<ICharacterDeathObserver>();
        List<IEnemyDeathObserver> _deathEnemyListeners = new List<IEnemyDeathObserver>();

        EnemyManager _enemyManager;
        ScoreController _scoreController;

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
        }

        void Start()
        {
            _enemyManager = GetComponent<EnemyManager>();
            _scoreController = GetComponent<ScoreController>();
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

        public void RegisterDeathListener(ICharacterDeathObserver listener)
        {
            _deathCharacterListeners.Add(listener);
        }

        public void UnregisterDeathListener(ICharacterDeathObserver listener)
        {
            _deathCharacterListeners.Remove(listener);
        }

        public void RegisterEnemyDeathListener(IEnemyDeathObserver listener)
        {
            _deathEnemyListeners.Add(listener);
        }

        public void UnregisterEnemyDeathListener(IEnemyDeathObserver listener)
        {
            _deathEnemyListeners.Remove(listener);
        }

        public void OnDeath(GameObject gameObject)
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("Character"))
            {
                foreach (var listener in _deathCharacterListeners)
                {
                    listener.OnDeath(gameObject);
                }
            }

            if (gameObject.CompareTag("Enemy"))
            {
                foreach (var listener in _deathEnemyListeners)
                {
                    listener.OnEnemyDeath();
                }
            }
        }

        public void OnDamage()
        {

        }
        public void EndGame()
        {
            _enemyManager.RemoveAllEnemies();
            _scoreController.ResetCurrentPoints();
        }

    }
}
