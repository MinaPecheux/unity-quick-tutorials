using System.Collections.Generic;
using UnityEngine;

namespace Tutorial03_BehaviourTrees.Example_3D {

    public abstract class FSM : MonoBehaviour {
        protected string _currentState = "";
        protected Dictionary<string, State> _states = new();
        public Dictionary<string, object> data = new();

        protected virtual void Start() {
            StateUtils.Setup();
            foreach ((string k, State s) in _states) {
                s.Init(this);
                if (k == _currentState)
                    s.Enter();
            }
        }

        void Update() {
            if (_currentState != string.Empty)
                _states[_currentState].Update();
        }

        void FixedUpdate() {
            if (_currentState != string.Empty)
                _states[_currentState].FixedUpdate();
        }

        public void TransitionTo(string state) {
            if (_currentState != string.Empty)
                _states[_currentState].Exit();
            _currentState = state;
            if (_currentState != string.Empty)
                _states[_currentState].Enter();
        }

    }

}
