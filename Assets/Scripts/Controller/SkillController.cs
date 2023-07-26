using UnityEngine;

namespace BOOM
{
    public class SkillController : MonoBehaviour
    {
        float _rateDefaultSkill = 0.5f;
        float _nextDefaultSkill = 0.0f;

        AttackComponent _attackComponent;

        void Start()
        {
            _attackComponent = GetComponent<AttackComponent>();
        }
        public void DefaultSkill()
        {
            if (Time.time > _nextDefaultSkill)
            {
                _nextDefaultSkill = Time.time + _rateDefaultSkill;
                _attackComponent.Shoot();
            }
        }


    }
}
