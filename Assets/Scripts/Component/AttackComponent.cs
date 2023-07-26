using UnityEngine;

namespace BOOM
{
    public class AttackComponent : MonoBehaviour
    {

        [SerializeField] ProjectileComponent _projectileComponent;
        [SerializeField] Transform _projectileSpawn;
        public void Shoot()
        {
            var projectile = Instantiate(_projectileComponent, _projectileSpawn.position,_projectileSpawn.rotation);
            projectile.Shoot();

        }
    }
}
