using UnityEngine;
using Cinemachine;

public class DemoCamera : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera skeletonCam;
    private bool _lookingAtSkeleton = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            _lookingAtSkeleton = !_lookingAtSkeleton;
            skeletonCam.Priority = playerCam.Priority + (_lookingAtSkeleton ? 1 : -1);
        }
    }
}
