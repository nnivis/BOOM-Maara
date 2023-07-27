using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BOOM
{
    public class HealthComponent : MonoBehaviour
    {
        float _health;
        [SerializeField] float _maxHealth = 80;
        public event Action<GameObject> OnDead;
        public event Action OnDamage;

        void Start()
        {
            GameManager.Instance.RegisterHealthComponent(this);
        }

        void OnDestroy()
        {
            GameManager.Instance.UnregisterHealthComponent(this);
        }

        public void TakeDamage(float damage)
        {
            _health = Mathf.Max(_health - damage, 0f);
            OnDamage?.Invoke();

            if (_health == 0)
            {
                OnDead?.Invoke(gameObject);
            }

            if(gameObject.CompareTag("Character"))
            {
                Debug.Log("hello-hello ");
            }
        }

    }
}
