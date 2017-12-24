using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
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
    [SerializeField] protected bool isCasting;
    //enchantment -- what effect is applied to the target

    protected float castTimer;

    public abstract void OnStartCast();
    public abstract void OnFinishCast();
}
