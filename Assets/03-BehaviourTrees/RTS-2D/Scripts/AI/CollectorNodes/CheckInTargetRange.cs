using UnityEngine;

using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class CheckInTargetRange : Node
    {
        private const float _REACH_THRESHOLD = 0.01f;

        private Transform _transform;

        public CheckInTargetRange(Transform transform)
        {
            _transform = transform;
        }

        public override NodeState Evaluate()
        {
            Vector3 t = (Vector3)_tree.blackboard["target"];
            _state = Vector2.Distance(_transform.position, t) < _REACH_THRESHOLD
                ? NodeState.SUCCESS : NodeState.FAILURE;
            return _state;
        }
    }

}
