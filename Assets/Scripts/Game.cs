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

    private void Awake()
    {
        _player = new Player(_startingPlayerHealth);
        _slider.Init(_player);
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
