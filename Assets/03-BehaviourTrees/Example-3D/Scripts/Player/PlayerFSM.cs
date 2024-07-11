using UnityEngine;

namespace Tutorial03_BehaviourTrees.Example_3D {

    public class PlayerFSM : FSM {

        [HideInInspector] public Animator animator;
        
        protected override void Start() {
            _states["idle"] = new IdleState();
            _states["run"] = new RunState();
            _currentState = "idle";
            base.Start();

            animator = GetComponent<Animator>();
        }

    }

}
