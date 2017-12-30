using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float Speed
    {
        get
        {
            return currentSpeed >= 0 ? currentSpeed : 0f;
        }
    }

    public float Health
    {
        get
        {
            return currentHealth;
        }
    }

    public float DamageTaken
    {
        get
        {
            return currentDamageTaken;
        }
    }

    public float AttackStrength
    {
        get
        {
            return currentAttackStrength;
        }
    }

    [SerializeField] private float currentSpeed;
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentDamageTaken;
    [SerializeField] private float currentAttackStrength;

    [SerializeField] private float baseSpeed = 0;
    [SerializeField] private float baseHealth = 0;
    [SerializeField] private float baseAttackStrength = 0;

    private void Start()
    {
        currentSpeed = baseSpeed;
        currentHealth = baseHealth;
        currentAttackStrength = baseAttackStrength;
    }

    // *** STATUS EFFECTS *** //
    public void ModifySpeed(float deltaSpeed)
    {
        currentSpeed += deltaSpeed;
    }

    public void TakeDamage(float attackStrength)
    {
        currentDamageTaken += attackStrength;
        if (currentDamageTaken > currentHealth)
        {
            Destroy(gameObject);
        }
    }
}
