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
        List<HeathComponent> healthComponents = new List<HeathComponent>();

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

        public void RegisterHealthComponent(HeathComponent healthComponent)
        {
            healthComponents.Add(healthComponent);
            healthComponent.OnDead += OnDeath;
            healthComponent.OnDamage += OnDamage;
        }

        public void UnregisterHealthComponent(HeathComponent healthComponent)
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
