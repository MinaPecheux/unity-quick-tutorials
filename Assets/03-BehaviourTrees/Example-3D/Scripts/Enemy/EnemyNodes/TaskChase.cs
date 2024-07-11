using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;

namespace Tutorial03_BehaviourTrees.Example_3D {

    public class TaskChase : Node
    {
        private const float _REACH_THRESHOLD = 0.01f;

        private NavMeshAgent _agent;
        private Animator _animator;
        private bool _running = false;

        public TaskChase()
        {
            _agent = _tree.GetComponent<NavMeshAgent>();
            _animator = _tree.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            Transform player;
            if (EnemyUtils.CheckForPlayerInFOV(_tree, _agent, out player)) {
                _tree.blackboard["target"] = player;
                _agent.SetDestination(player.position);
            }

            if (!_running) {
                Transform target = (Transform)_tree.blackboard["target"];
                _agent.SetDestination(target.position);
                _animator.SetBool("Running", true);
                _running = true;
                _state = NodeState.RUNNING;
            }

            else if (_agent.remainingDistance < _REACH_THRESHOLD) {
                _tree.blackboard.Remove("target");
                _tree.blackboard["reached_target"] = true;
                _animator.SetBool("Running", false);
                _running = false;
                _state = NodeState.SUCCESS;
            }

            return _state;
        }

    }

}
