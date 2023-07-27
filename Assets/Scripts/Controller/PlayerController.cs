using UnityEngine;
using UnityEngine.InputSystem;

namespace BOOM
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] InputActionAsset _inputActionAssets;

        InputAction _shootButtonAction;
        FollowComponent _followComponent;
        SkillController _skillController;

         bool _shootButtonExecuted = false;


        void Awake()
        {
            _shootButtonAction = _inputActionAssets.FindAction("Shoot");
        }

        void Start()
        {
            _followComponent = GetComponent<FollowComponent>();
            _skillController = GetComponent<SkillController>();
        }

        void OnEnable()
        {
            _inputActionAssets.FindActionMap("PlayerInput").Enable();
        }

        void OnDisable()
        {
            _inputActionAssets.FindActionMap("PlayerInput").Disable();
        }

        void Update()
        {
            if (_shootButtonAction.WasPressedThisFrame())
            {
                _skillController.DefaultSkill();
            }

            _followComponent.Follow();
        }
    }
}
