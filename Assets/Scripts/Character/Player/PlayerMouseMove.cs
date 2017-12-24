using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMouseMove : NetworkBehaviour
{
    public float followDistance;

    private float speed;
    private Vector3 targetPosition;
    private Transform targetObject = null;
    private bool isMoving = false;

    private void Start()
    {
        if (!isLocalPlayer) Destroy(this);
        speed = GetComponent<CharacterStats>().speed;
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
            isMoving = false;
        }

        if (isMoving) MovePlayer();
    }

    public void SetMove(Vector3 movePosition)
    {
        targetPosition = movePosition;
        isMoving = true;
        targetObject = null;
    }

    public void SetMove(Transform followTarget)
    {
        targetObject = followTarget;
        isMoving = true;
    }

    private void MovePlayer()
    {
        if (targetObject) {
            targetPosition = targetObject.position;
            if ((targetPosition - transform.position).magnitude < followDistance)
            {
                //transform.position = Vector3.Lerp(transform.position, targetPosition, 19f);
                return;
            }
        }

        transform.LookAt(targetPosition);

        if ((transform.position - targetPosition).magnitude < speed * Time.deltaTime)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
