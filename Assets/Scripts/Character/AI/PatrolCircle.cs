using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PatrolCircle : NetworkBehaviour
{
    public float speed;
    public float rotateSpeed;

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}
}
