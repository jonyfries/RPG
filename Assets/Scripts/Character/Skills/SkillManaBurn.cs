using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManaBurn : SkillBase
{
    protected float damage = 2;

    public override void OnStartCast()
    {
        isCasting = true;
        characterStats.speed = 0;
    }

    private void Update()
    {
        if (!isCasting) this.enabled = false;

        castTimer += Time.deltaTime;

        if (castTimer > castTime) OnFinishCast();
    }

    public override void OnFinishCast()
    {
        GameObject selectedObject = GetComponent<CharacterTarget>().selectedObject;
        selectedObject.GetComponent<CharacterStats>().TakeDamage(damage);
        isCasting = false;
    }
}
