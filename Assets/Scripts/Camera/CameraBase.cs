using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBase : MonoBehaviour
{
    public Transform cam;

    public abstract void AssignTarget(Transform newTarget);

    private void Start()
    {
        cam = Camera.main.transform;
    }
}
