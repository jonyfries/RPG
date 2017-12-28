using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillManaBurn : SkillBase
{
    [SerializeField] protected float minDamageFactor = 1f;
    [SerializeField] protected float maxDamageFactor = 1.5f;
    private GameObject selectedObject;
    private CharacterTarget target;

    private void Start()
    {
        this.enabled = false;
        target = GetComponent<CharacterTarget>();
    }

    [Command]
    protected override bool CmdOnStartCast()
    {
        selectedObject = target.selectedObject;
        if (selectedObject == null) return false;
        else return true;
    }

    [Command]
    protected override void CmdOnFinishCast()
    {
        float damage = Random.Range(minDamageFactor, maxDamageFactor) * characterStats.AttackStrength;
        GameObject selectedObject = GetComponent<CharacterTarget>().selectedObject;
        selectedObject.GetComponent<CharacterStats>().TakeDamage(damage);
    }
}
