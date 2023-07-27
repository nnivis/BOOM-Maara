using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public interface IEnemyDeathObserver
    {
        void OnEnemyDeath();
    }
}
