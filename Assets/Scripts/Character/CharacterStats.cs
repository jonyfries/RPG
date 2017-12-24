using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float health;
    [SerializeField] private float damageTaken;
    [SerializeField] public float attackStrength;

    [SerializeField] private float baseSpeed;
    [SerializeField] private float baseHealth;
    [SerializeField] private float baseAttackStrength;

    public void TakeDamage(float attackStrength)
    {
        damageTaken += attackStrength;
        if (damageTaken > health) Destroy(gameObject);
    }
}
