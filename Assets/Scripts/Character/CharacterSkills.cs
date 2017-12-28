using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterSkills : NetworkBehaviour
{
    public CharacterTarget target;
    public CharacterStats stats;
    public UIHandles uiHandle;

    // *** Skills Character has Equiped *** //
    public SkillBase skill1;
    public SkillBase skill2;

    private void Start()
    {
        if (isLocalPlayer)
        {
            uiHandle = GameObject.Find("Canvas").GetComponent<UIHandles>();
            uiHandle.button1.onClick.AddListener(delegate () { skill1.CmdStartCast(); });
        }
    }
}
