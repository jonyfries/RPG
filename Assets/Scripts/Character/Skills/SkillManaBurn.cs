using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillManaBurn : SkillBase
{
    [SerializeField] protected float minDamageFactor = 1f;
    [SerializeField] protected float maxDamageFactor = 1.5f;

    [Command]
    protected override void CmdOnStartCast()
    {
        selectedObject = target.selectedObject;
        if (selectedObject == null) {
            hasValidTarget = false;
        } else {
            hasValidTarget = true;
        }
    }

    [Command]
    protected override void CmdOnFinishCast()
    {
        float damage = Random.Range(minDamageFactor, maxDamageFactor) * characterStats.AttackStrength;
        GameObject selectedObject = GetComponent<CharacterTarget>().selectedObject;
        selectedObject.GetComponent<CharacterStats>().TakeDamage(damage);
    }
}
