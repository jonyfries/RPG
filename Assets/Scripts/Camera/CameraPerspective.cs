using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective : CameraBase
{
    public Transform target;
    public Vector3 offset;
    public float damping = 1;

    public override void AssignTarget(Transform newTarget)
    {
        target = newTarget;
        transform.position = target.transform.position + offset;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        if (!(target == null))
        {
            Vector3 desiredPosition = target.transform.position + offset;
            Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
            transform.position = position;
        }
    }
}
