using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class TaskCollect : Node
    {
        private const int _COLLECT_AMOUNT = 1;

        private ResourceMap _resourceMap;
        private int _maxStorage;

        public TaskCollect(ResourceMap resourceMap, int maxStorage)
        {
            _resourceMap = resourceMap;
            _maxStorage = maxStorage;
        }

        public override NodeState Evaluate()
        {
            // update resource amount
            int curAmount = (int)_tree.blackboard["current_resource_amount"];
            int newAmount = curAmount + _COLLECT_AMOUNT;
            if (newAmount > _maxStorage)
                newAmount = _maxStorage;

            _tree.blackboard["current_resource_amount"] = newAmount;

            // update resource map
            Vector3Int resourceCellPos = (Vector3Int)_tree.blackboard["target_cell"];
            try
            {
                bool tileIsDead = _resourceMap.ConsumeTile(resourceCellPos, _COLLECT_AMOUNT);
                if (tileIsDead)
                    _ClearTarget();
            }
            catch (KeyNotFoundException)
            {
                // (if target is not valid anymore, but we are not yet aware)
                _ClearTarget();
            }

            _state = NodeState.RUNNING;
            return _state;
        }

        private void _ClearTarget()
        {
            _tree.blackboard.Remove("target");
            _tree.blackboard.Remove("target_cell");
            _tree.blackboard.Remove("target_is_resource");
        }

    }

}
