using UnityEngine;

using BehaviorTree;

namespace Tutorial03_BehaviourTrees.RTS_2D {

    public class CheckIsVisible : Node
    {
        private SpriteRenderer _spriteRenderer;

        public CheckIsVisible(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        public override NodeState Evaluate()
        {
            _state = _spriteRenderer.enabled ? NodeState.SUCCESS : NodeState.FAILURE;
            return _state;
        }
    }

}
