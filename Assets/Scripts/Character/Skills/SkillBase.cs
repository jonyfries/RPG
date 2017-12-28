using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class SkillBase : NetworkBehaviour
{
    public enum TargetType
    {
        Self,
        Friendly,
        Enemy,
        Any,
        Position
    }

    [SerializeField] protected CharacterStats characterStats;
    [SerializeField] protected TargetType targetType;
    [SerializeField] protected float range;
    [SerializeField] protected float castTime;
    [SerializeField] protected float deltaSpeedWhileCasting;
    [SerializeField] protected SkillVisualBase skillVisual;
    //enchantment -- what effect is applied to the target

protected float castTimer;

    protected abstract bool CmdOnStartCast();
    protected abstract void CmdOnFinishCast();


    [Command]
    public void CmdStartCast()
    {
        if (CmdOnStartCast())
        {
            this.enabled = true;
            characterStats.ModifySpeed(-deltaSpeedWhileCasting);
            skillVisual.StartSkillCast();
        }
    }

    private void Update()
    {
        castTimer += Time.deltaTime;

        if (castTimer > castTime)
        {
            CmdFinishCast();
            castTimer = 0;
        }
    }

    [Command]
    public void CmdFinishCast()
    {
        characterStats.ModifySpeed(deltaSpeedWhileCasting);
        skillVisual.EndSkillCast();
        this.enabled = false;
        CmdOnFinishCast();
    }
}
