using UnityEngine;
using UnityEngine.AI;

using BehaviorTree;

namespace Tutorial03_BehaviourTrees.Example_3D {

    public static class EnemyUtils {

        public const float FOV = 7f;
        private static int PlayerLayer = 3;
        private static int PlayerMask = 1 << PlayerLayer;

        public static bool CheckForPlayerInFOV(
            BTree tree, NavMeshAgent agent, out Transform player) {
            player = null;
            var coll = Physics.OverlapSphere(agent.transform.position, FOV, PlayerMask);
            if (coll.Length > 0) {
                player = coll[0].transform;
                return true;
            } else if (tree.blackboard.ContainsKey("target")) {
                Transform t = (Transform)tree.blackboard["target"];
                if (t.gameObject.layer == PlayerLayer) {
                    tree.blackboard.Remove("target");
                    agent.SetDestination(agent.transform.position);
                }
            }
            return false;
        }

    }

}
