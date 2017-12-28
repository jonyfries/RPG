using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    private Transform cam;

    private void Start()
    {
        if (!isLocalPlayer) Destroy(this);

        cam = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Move();
        }
    } 

    private void Move()
    {
        Vector3 cameraForward = cam.transform.TransformDirection(Vector3.forward);
        cameraForward.y = 0f;
        cameraForward = cameraForward.normalized;

        Vector3 cameraRight = cam.transform.TransformDirection(Vector3.right);
        cameraRight.y = 0f;
        cameraRight = cameraRight.normalized;

        Vector3 forwardMovement = cameraForward * Input.GetAxis("Vertical");
        Vector3 sideMovement = cameraRight * Input.GetAxis("Horizontal");
        Vector3 movement = (forwardMovement + sideMovement) * characterStats.Speed * Time.deltaTime;

        transform.LookAt(movement + transform.position);
        movement = transform.InverseTransformDirection(movement);
        transform.Translate(movement);
    }
}
