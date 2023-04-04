using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int _maxHealth;

    public int Health { get; private set; }

    public event Action<float> HealthPercentageChanged;

    public Player(int health)
    {
        _maxHealth = health;
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(Health - damage, 0);
        HealthPercentageChanged?.Invoke((float)Health/_maxHealth);
    }

    public void Heal(int amount)
    {
        Health = Mathf.Min(Health + amount, _maxHealth);
        HealthPercentageChanged?.Invoke((float)Health / _maxHealth);
    }
}
