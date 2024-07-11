using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class CheckHasTarget : Node
    {
        public override NodeState Evaluate()
        {
            _state = _tree.blackboard.ContainsKey("target")
                ? NodeState.SUCCESS : NodeState.FAILURE;
            return _state;
        }
    }

}
