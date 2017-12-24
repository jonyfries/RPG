using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class HandleMouseEvents : NetworkBehaviour
{
    public PlayerMouseMove mouseMove;
    public CharacterTarget target;

    private void Start()
    {
        if (!isLocalPlayer) Destroy(this);
    }

    private void Update()
    {
        if (Input.GetAxis("Fire1") != 0) SetTarget();
    }

    private void SetTarget()
    {
        //If user clicked on UI element don't ray cast.
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Raycast to see if an object was hit
        if (Physics.Raycast(ray, out hit))
        {
            //If the object is a GameCharacter move towards it
            if (hit.transform.tag == "GameCharacter")
            {
                target.selectedObject = hit.transform.gameObject;
                mouseMove.SetMove(target.selectedObject.transform);
            }
            //If the object is Navigatable then move to where was clicked
            else if (hit.transform.tag == "Navigable" && mouseMove != null)
            {
                mouseMove.SetMove(hit.point + Vector3.up);
            }
        }
    }
}
