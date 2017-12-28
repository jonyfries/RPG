using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillVisualManaBurn : SkillVisualBase
{
    public GameObject glasses;
    public Material attackMaterial;
    public Material baseMaterial;

    private Renderer glassesRenderer;

    public void Start()
    {
        glassesRenderer = glasses.GetComponent<Renderer>();
    }

    public override void StartSkillCast()
    {
        Material[] mats = new Material[1];
        mats[0] = attackMaterial;
        glassesRenderer.materials = mats;
    }

    public override void EndSkillCast()
    {
        Material[] mats = new Material[1];
        mats[0] = baseMaterial;
        glassesRenderer.materials = mats;
    }
}
