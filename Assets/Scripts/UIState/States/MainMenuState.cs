using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class MainMenuState : MonoBehaviour, IStates
    {
        StateManager _stateManager;
        public void Begin(StateManager stateManager)
        {
            this._stateManager = stateManager;
            this.gameObject.SetActive(true);
        }

        public void Exit()
        {
            this.gameObject.SetActive(false);
        }
        public void OnGameButtonClicked()
        {
            this._stateManager.ChangeState(UIState.GAME);
        }
    }
}
