using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class EnemyDamageComponent : MonoBehaviour
    {
        [SerializeField]float _damage = 1f;
        void OnCollisionEnter2D(Collision2D other)
        {
            var heath = other.gameObject.GetComponent<HealthComponent>();
            if (heath)
            {
                heath.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
