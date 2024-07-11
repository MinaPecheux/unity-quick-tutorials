using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class TaskEnterBuilding : Node
    {
        private CollectorAI _brain;

        public TaskEnterBuilding(CollectorAI brain)
        {
            _brain = brain;
        }

        public override NodeState Evaluate()
        {
            _brain.ToggleVisuals(false);

            _state = NodeState.SUCCESS;
            return _state;
        }

    }

}
