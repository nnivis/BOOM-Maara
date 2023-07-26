using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class GameState : MonoBehaviour, IStates
    {

        StateManager _stateManager;
        public void Begin(StateManager stateManager)
        {
            _stateManager = stateManager;
            gameObject.SetActive(true);
        }

        public void Exit()
        {
            gameObject.SetActive(false);
        }

    }
}
