using UnityEngine;

namespace Tutorial02_FSMs {

    public class SkeletonFSM : FSM {

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
