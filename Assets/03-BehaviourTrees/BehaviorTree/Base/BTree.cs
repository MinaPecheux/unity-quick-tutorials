using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BTree : MonoBehaviour
    {
        public static BTree current;

        protected Node _root = null;
        public Dictionary<string, object> blackboard = new();

        protected virtual void Awake()
        {
            Node.LAST_ID = 0;
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        public Node Root => _root;
        protected abstract Node SetupTree();
    }
}
