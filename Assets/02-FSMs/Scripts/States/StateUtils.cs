using UnityEngine;

namespace Tutorial02_FSMs {

    public static class StateUtils {

        private static Camera _cam;
        private static RaycastHit _hit;
        private static LayerMask _floorMask;

        public static void Setup() {
            _cam = Camera.main;
            _floorMask = 1 << LayerMask.NameToLayer("Floor");
        }

        public static bool ClickedOnGround(out Vector3 position) {
            // if right-clicking, check for a click on the floor
            // using a raycast - and if that works, mark this position
            // as the current target, and switch to the 'run' state
            if (Input.GetMouseButtonDown(1)) {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _hit, 100f, _floorMask)) {
                    position = _hit.point;
                    return true;
                }
            }
            position = Vector3.zero;
            return false;
        }

    }

}
