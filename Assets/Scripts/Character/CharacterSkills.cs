using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkills : MonoBehaviour
{
    public CharacterTarget target;
    public CharacterStats stats;

    public void Attack()
    {
        GameObject selectedObject = target.selectedObject;
        if (selectedObject == null)
        {
            return;
        }

        CharacterStats targetStats = selectedObject.GetComponent<CharacterStats>();
        targetStats.TakeDamage(stats.attackStrength);
    }
}
