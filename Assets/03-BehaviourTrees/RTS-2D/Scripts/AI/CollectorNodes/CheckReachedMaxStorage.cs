using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class CheckReachedMaxStorage : Node
    {
        private int _maxStorage;

        public CheckReachedMaxStorage(int maxStorage)
        {
            _maxStorage = maxStorage;
        }

        public override NodeState Evaluate()
        {
            int a = (int)_tree.blackboard["current_resource_amount"];
            _state = a == _maxStorage ? NodeState.SUCCESS : NodeState.FAILURE;
            return _state;
        }
    }

}
