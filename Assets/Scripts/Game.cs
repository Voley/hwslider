using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private SmoothSlider _slider;
    [SerializeField] int _startingPlayerHealth;
    [SerializeField] int _damageAmount;
    [SerializeField] int _healAmount;

    private Player _player;

    void Start()
    {
        _player = new Player(_startingPlayerHealth);
        _player.OnHealthChanged += PlayersHealthChanged;
    }

    private void PlayersHealthChanged(int current, int max)
    {
        float amount = (float)current / max;
        _slider.SetValue(amount);
    }

    public void TakeDamage()
    {
        _player.TakeDamage(_damageAmount);
    }

    public void HealDamage()
    {
        _player.HealDamage(_healAmount);
    }
}
