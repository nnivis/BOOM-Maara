using UnityEngine;

namespace BOOM
{
    public interface ICharacterDeathObserver
    {
        void OnDeath(GameObject gameObject);
    }
}
