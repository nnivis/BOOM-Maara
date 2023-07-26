using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class FollowComponent : MonoBehaviour
    {
        Camera _mainCamera;

        void Start()
        {
            _mainCamera = Camera.main;
        }

        public void Follow()
        {
            Vector3 cursorPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = cursorPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
