using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    public int currentHealth;


    private void Start()
    {
        setHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DealDamage(100);
            
        }
    }


    private void DealDamage(int damageAmount)
    {
        setHealth(currentHealth - damageAmount);
    }


    private void setHealth(int value)
    {
        currentHealth = value;
       // Debug.Log(currentHealth);
    }
}
