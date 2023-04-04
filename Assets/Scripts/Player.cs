using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int _maxHealth;

    public int Health { get; private set; }

    public event Action<int, int> OnHealthChanged;


    public Player(int health)
    {
        _maxHealth = health;
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(Health - damage, 0);
        if (OnHealthChanged != null)
        {
            OnHealthChanged(Health, _maxHealth);
        }
    }

    public void HealDamage(int amount)
    {
        Health = Mathf.Min(Health + amount, _maxHealth);
        if (OnHealthChanged != null)
        {
            OnHealthChanged(Health, _maxHealth);
        }
    }
}
