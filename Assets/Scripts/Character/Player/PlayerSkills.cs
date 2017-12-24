using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSkills : NetworkBehaviour
{
    public CharacterSkills characterSkills;

    private void Start()
    {
        UIHandles handle = GameObject.Find("Networking").GetComponent<UIHandles>();
        handle.button1.onClick.AddListener(delegate { characterSkills.Attack(); });
    }
}
