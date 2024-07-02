using UnityEngine;

namespace Tutorial01_FPSController {

    public class FirstPersonController : MonoBehaviour {
        private const float Gravity = 9.81f;
        public float speed = 5.0f;
        public float mouseSensitivity = 4.0f;
        public float jumpSpeed = 5.0f;

        private CharacterController _charController;
        private Transform _camTransform;
        private float _yVel;
        private float _pitch; // (we need to keep track to be able to clamp)

        void Start() {
            _charController = GetComponent<CharacterController>();
            _camTransform = Camera.main.transform;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update() {
            MovePlayer();
            RotatePlayer();
        }

        void MovePlayer() {
            if (!_charController.isGrounded) {
                _yVel -= Gravity * Time.deltaTime;
            } else if (Input.GetButtonDown("Jump")) {
                _yVel = jumpSpeed;
            }

            Vector3 moveDirection = new(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            moveDirection.y = _yVel;
            _charController.Move(moveDirection * Time.deltaTime);
        }

        void RotatePlayer() {
            float yaw = Input.GetAxis("Mouse X") * mouseSensitivity;
            _pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            _pitch = Mathf.Clamp(_pitch, -90f, 90f);
            transform.Rotate(0, yaw, 0);
            _camTransform.localEulerAngles = new Vector3(_pitch, 0, 0);
        }
    }

}
