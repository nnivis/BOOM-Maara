using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileComponent : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rigidbody2D;
        float _force = 55f;

        [SerializeField]float _damage = 1f;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void Shoot()
        {
            Vector2 direction = transform.right;
            Vector2 movement = direction * _force;

            _rigidbody2D.AddForce(movement, ForceMode2D.Impulse);
        }

        void OnCollisionEnter2D(Collision2D other)
        {

            var heath = other.gameObject.GetComponent<HeathComponent>();
            if (heath)
            {
                heath.TakeDamage(_damage);
            }

            Destroy(gameObject);

        }
    }
}