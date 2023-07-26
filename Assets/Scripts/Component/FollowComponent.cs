using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class FollowComponent : MonoBehaviour
    {

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        public void Follow()
        {
            Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Вычисляем вектор между спрайтом и курсором
            Vector3 direction = cursorPosition - transform.position;

            // Получаем угол между вектором направления и осью X (1, 0)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Поворачиваем спрайт вокруг его оси Z на вычисленный угол
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            
        }

    }
}
