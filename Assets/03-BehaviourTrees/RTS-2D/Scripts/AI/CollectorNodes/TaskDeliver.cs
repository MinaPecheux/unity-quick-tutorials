using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class TaskDeliver : Node
    {
        private string _resourceType;

        public TaskDeliver(string resourceType)
        {
            _resourceType = resourceType;
        }

        public override NodeState Evaluate()
        {
            // send global event with amount/type of resource collected
            int resourceAmount = (int)_tree.blackboard["current_resource_amount"];
            EventManager.TriggerEvent("ResourceCollected", new object[]
            {
                _resourceType, resourceAmount
            });

            // reset local storage of unit
            _tree.blackboard["current_resource_amount"] = 0;

            // clear target
            _tree.blackboard.Remove("target");
            _tree.blackboard.Remove("target_cell");
            _tree.blackboard.Remove("target_is_resource");

            _state = NodeState.RUNNING;
            return _state;
        }
    }

}
