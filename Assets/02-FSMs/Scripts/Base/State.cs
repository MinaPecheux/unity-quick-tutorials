namespace Tutorial02_FSMs {

    public abstract class State {

        protected FSM _fsm;
        
        public virtual void Init(FSM fsm) { _fsm = fsm; }
        public virtual void Enter() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void Exit() {}

    }

}
