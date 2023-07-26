using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class UIStateManager : StateManager
    {
        UIState _activeUIState = UIState.MAINMENU;

        public override void Awake()
        {
            base.Awake();
            LoadUIPanels();
            ChangeState(UIState.MAINMENU);

        }
        public override void ChangeState(Enum nextState)
        {
            stateList[(int)_activeUIState].Exit();
            _activeUIState = (UIState)nextState;
            stateList[(int)_activeUIState].Begin(this);
        }
    }
}
