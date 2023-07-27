using UnityEngine;

namespace BOOM
{
    public interface IGameObserver
    {
        void OnDeath(GameObject gameObject);
    }
}
