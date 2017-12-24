using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : CameraBase
{
    public Transform target;
    public float damping = 1;
    public Vector3 offset;

    public override void AssignTarget(Transform newTarget)
    {
        target = newTarget;
        transform.position = target.transform.position + offset;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        if (target == null) return;

        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
