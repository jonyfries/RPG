using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FocusCamera : NetworkBehaviour
{
    public Transform cameraTarget;

    private void Start()
    {
        if (!isLocalPlayer) Destroy(this);

        Camera.main.GetComponent<CameraBase>().AssignTarget(cameraTarget);
    }
}
