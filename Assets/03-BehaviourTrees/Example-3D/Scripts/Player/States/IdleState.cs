using UnityEngine;

namespace Tutorial03_BehaviourTrees.Example_3D {

    public class IdleState : State {

        public override void Update() {
            if (StateUtils.ClickedOnGround(out Vector3 pos)) {
                _fsm.data["target"] = pos;
                _fsm.TransitionTo("run");
            }
        }

    }

}
