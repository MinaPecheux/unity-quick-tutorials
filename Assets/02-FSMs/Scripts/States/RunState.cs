using UnityEngine;

namespace Tutorial02_FSMs {

    public class RunState : State {

        private const float Speed = 5f;
        private const float DistThreshold = 0.1f;

        private Transform _transform;
        private CharacterController _controller;
        private Vector3 _target;

        public override void Init(FSM fsm) {
            base.Init(fsm);
            _transform = fsm.transform.Find("Mesh");
            _controller = fsm.GetComponent<CharacterController>();
        }

        public override void Enter() {
            ((SkeletonFSM) _fsm).animator.SetBool("Running", true);
            _target = (Vector3) _fsm.data["target"];
        }

        public override void Update() {
            if (StateUtils.ClickedOnGround(out Vector3 pos)) {
                _fsm.data["target"] = pos;
                _target = (Vector3) _fsm.data["target"];
            }

            Vector3 moveDirection = (_target - _transform.position).normalized;
            moveDirection.y = 0;
            if (moveDirection.magnitude > DistThreshold) {
                _transform.rotation = Quaternion.LookRotation(moveDirection);
                _controller.Move(moveDirection * Speed * Time.deltaTime);
            } else {
                _fsm.data.Remove("target");
                _fsm.TransitionTo("idle");
            }
        }

        public override void Exit() {
            ((SkeletonFSM) _fsm).animator.SetBool("Running", false);
        }

    }

}
