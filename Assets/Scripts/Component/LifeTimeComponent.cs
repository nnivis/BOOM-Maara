using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class LifeTimeComponent : MonoBehaviour
    {

        [SerializeField] float _delay = 1.0f;
        float _startTime;

        void Start()
        {
            _startTime = Time.time;
        }

        void Update()
        {
            if (Time.time > _startTime + _delay)
            {
                Destroy(gameObject);
            }
        }


    }
}
