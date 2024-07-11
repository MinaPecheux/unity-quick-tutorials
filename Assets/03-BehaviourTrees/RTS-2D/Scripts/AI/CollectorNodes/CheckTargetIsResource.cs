using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class CheckTargetIsResource : Node
    {
        public override NodeState Evaluate()
        {
            bool targetIsResource = (bool)_tree.blackboard["target_is_resource"];
            _state = targetIsResource ? NodeState.SUCCESS : NodeState.FAILURE;
            return _state;
        }
    }

}
