using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : CameraBase
{
    public Transform target;

    public override void AssignTarget(Transform newTarget)
    {
        target = newTarget;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
