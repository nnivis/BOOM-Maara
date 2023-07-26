using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class EnemyController : MonoBehaviour
    {
        EnemyMovementComponent _enemyMovementComponent;

        [SerializeField] GameObject _targetPosition;

        void Start()
        {
            _enemyMovementComponent = GetComponent<EnemyMovementComponent>();
        }


        void Update()
        {
            if (_targetPosition != null)
            {
                _enemyMovementComponent.Move(_targetPosition);
            }
        }
    }
}
