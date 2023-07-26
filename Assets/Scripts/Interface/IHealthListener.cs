using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public interface IHealthListener
    {
        void OnDamage();
        void OnDeath(GameObject gameObject);
    }
}
