using System.Collections.Generic;

namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public abstract class Node
    {
        protected NodeState _state;
        public NodeState State => _state;

        public static uint LAST_ID = 0;
        private uint _id;
        public uint Id => _id;

        private Node _parent;
        public Node Parent => _parent;

        private List<Node> _children;
        public List<Node> Children => _children;
        public bool HasChildren => _children.Count > 0;

        protected BTree _tree;

        public Node()
        {
            _id = LAST_ID++;
            _parent = null;
            _children = new List<Node>();
            _tree = BTree.current;
        }
        public Node(List<Node> children) : this()
        {
            SetChildren(children);
        }

        public abstract NodeState Evaluate();

        public void SetChildren(List<Node> children, Node root = null)
        {
            foreach (Node c in children)
                Attach(c);
        }

        public void Attach(Node child)
        {
            _children.Add(child);
            child._parent = this;
        }

        public void Detach(Node child)
        {
            _children.Remove(child);
            child._parent = null;
        }

        public void SetRoot(Node root)
        {
            foreach (Node child in _children)
                child.SetRoot(root);
        }
    }
}
