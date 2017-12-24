using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : CameraBase
{
    public Transform target;

    public float distance;
    public float currentX;
    public float currentY;
    public float sensitivityX;
    public float sensitivityY;
    public float sensitivityZoom;
    public float lerpTime;

    public float minY;
    public float maxY;
    public float minDistance;
    public float maxDistance;

    private void Update()
    {
        if (Input.GetAxis("Fire2") != 0)
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, minY, maxY);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityZoom;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = Vector3.Lerp(transform.position, target.position + rotation * direction, Time.deltaTime * lerpTime);
        transform.LookAt(target);
    }

    public override void AssignTarget(Transform newTarget)
    {
        target = newTarget;
        transform.LookAt(target);
    }
}
