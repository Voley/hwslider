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

    private void Start()
    {
        _player = new Player(_startingPlayerHealth);
        _player.HealthPercentageChanged += _slider.SetValue;
    }

    private void OnDestroy()
    {
        _player.HealthPercentageChanged -= _slider.SetValue;
    }

    public void TakeDamage()
    {
        _player.TakeDamage(_damageAmount);
    }

    public void HealDamage()
    {
        _player.Heal(_healAmount);
    }
}
