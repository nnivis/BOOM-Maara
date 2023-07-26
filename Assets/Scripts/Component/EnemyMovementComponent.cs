using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class EnemyMovementComponent : MonoBehaviour
    {
        float _speed = 0.1f;

        public void Move(GameObject targetPosition)
        {

            var tragetLocalPosotiom = targetPosition;
            var traslation = tragetLocalPosotiom.transform.position - transform.position;

            if(traslation.magnitude >_speed)
            {
                traslation = traslation.normalized *_speed;
            }
            transform.Translate(traslation);

        }
    }
}
