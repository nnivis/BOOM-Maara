using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BOOM
{
    public abstract class StateManager : MonoBehaviour
    {

        protected List<IStates> stateList = new List<IStates>();
        public Transform uiParentTransform;

        public abstract void ChangeState(Enum stateEnum);

        public virtual void Awake()
        {

        }

        void Start()
        {

        }

        void Update()
        {

        }

        public virtual void LoadUIPanels()
        {
            foreach (Transform transform in uiParentTransform)
            {
                if (transform.GetComponent<IStates>() != null)
                {
                    stateList.Add(transform.GetComponent<IStates>());
                    transform.gameObject.SetActive(false);
                }
            }
        }

    }
}
