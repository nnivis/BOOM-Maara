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
        List<HealthComponent> healthComponents = new List<HealthComponent>();

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

        public void RegisterHealthComponent(HealthComponent healthComponent)
        {
            healthComponents.Add(healthComponent);
            healthComponent.OnDead += OnDeath;
            healthComponent.OnDamage += OnDamage;
        }

        public void UnregisterHealthComponent(HealthComponent healthComponent)
        {
            healthComponents.Remove(healthComponent);
            healthComponent.OnDead -= OnDeath;
            healthComponent.OnDamage -= OnDamage;
        }


        public void OnDeath(GameObject gameObject)
        {
            Destroy(gameObject);
        }

        public void OnDamage()
        {
            Debug.Log(" Player damaged! Damage: " );
        }


    }
}
