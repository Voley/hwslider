using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }

    public event Action<float> HealthPercentageChanged;

    public Player(int health)
    {
        MaxHealth = health;
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(Health - damage, 0);
        HealthPercentageChanged?.Invoke((float)Health/MaxHealth);
    }

    public void Heal(int amount)
    {
        Health = Mathf.Min(Health + amount, MaxHealth);
        HealthPercentageChanged?.Invoke((float)Health / MaxHealth);
    }
}
