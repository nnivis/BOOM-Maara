using System;
using UnityEngine;

namespace BOOM
{
    public class UIStateManager : StateManager, ICharacterDeathObserver
    {
        UIState _activeUIState = UIState.MAINMENU;

        public override void Awake()
        {
            base.Awake();
            LoadUIPanels();
            ChangeState(UIState.MAINMENU);
        }

        void Start()
        {
            GameManager.Instance.RegisterDeathListener(this);
        }

        public override void ChangeState(Enum nextState)
        {
            stateList[(int)_activeUIState].Exit();
            this._activeUIState = (UIState)nextState;
            stateList[(int)_activeUIState].Begin(this);
        }

        public void OnDeath(GameObject gameObject)
        {

            ChangeState(UIState.GAMEOVER);
            GameManager.Instance.EndGame();

        }
    }
}
