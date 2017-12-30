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
    [SerializeField] protected CharacterTarget target;

    protected GameObject selectedObject;
    protected bool hasValidTarget;
    private bool isCasting;

    protected float castTimer;

    protected abstract void CmdOnStartCast();
    protected abstract void CmdOnFinishCast();

    private void Start()
    {
        this.enabled = false;
        target = GetComponent<CharacterTarget>();
    }

    [Command]
    public void CmdStartCast()
    {
        if (this.enabled) return; //If the skill is already being used exit.

        CmdOnStartCast();

        if (!hasValidTarget) return; // If the skill doesn't have a valid target return;

        this.enabled = true;
        isCasting = false;

        Vector3 targetVector = transform.position - selectedObject.transform.position;
        if (targetVector.magnitude > range) {
            GetComponent<PlayerMouseMove>().SetMove(selectedObject.transform, range);
        } else {
            StartCasting();
        }
    }

    private void StartCasting()
    {
        characterStats.ModifySpeed(-deltaSpeedWhileCasting);
        skillVisual.StartSkillCast();
        isCasting = true;
    }

    private void Update()
    {
        if (!isCasting)
        {
            Vector3 targetVector = transform.position - selectedObject.transform.position;
            if (targetVector.magnitude <= range) {
                StartCasting();
            } else {
                return;
            }
        }

        castTimer += Time.deltaTime;

        if (castTimer > castTime) {
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
