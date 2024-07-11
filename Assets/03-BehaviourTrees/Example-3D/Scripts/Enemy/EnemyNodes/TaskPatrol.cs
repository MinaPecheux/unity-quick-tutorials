using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;

namespace Tutorial03_BehaviourTrees.Example_3D {

    public class TaskPatrol : Node
    {
        private NavMeshAgent _agent;

        private Transform[] _patrolPoints;
        private int _currentPatrolIndex;
        private float _waitDelay;

        public TaskPatrol(Transform[] patrolPoints)
        {
            _agent = _tree.GetComponent<NavMeshAgent>();
            _patrolPoints = patrolPoints;
            _currentPatrolIndex = 0;
            _agent.Warp(_patrolPoints[_currentPatrolIndex].position);
        }

        public override NodeState Evaluate()
        {
            _state = NodeState.RUNNING;

            Transform player;
            if (EnemyUtils.CheckForPlayerInFOV(_tree, _agent, out player)) {
                _tree.blackboard["target"] = player;
                _state = NodeState.FAILURE;
                return _state;
            }

            if (_tree.blackboard.ContainsKey("reached_target")) {
                _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
                _waitDelay = 1f;
                _tree.blackboard.Remove("reached_target");
            }

            if (_waitDelay > 0f) {
                _waitDelay -= Time.deltaTime;
            } else {
                _tree.blackboard["target"] = _patrolPoints[_currentPatrolIndex];
            }

            return _state;
        }

    }

}
