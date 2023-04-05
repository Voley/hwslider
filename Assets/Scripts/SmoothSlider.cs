using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SmoothSlider : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;

    private Slider _slider;
    private float _targetValue;
    private float _velocity;
    private Player _player;
    private Coroutine _scoreCoroutine;
    
    public void Init(Player player)
    {
        _player = player;
        _player.HealthPercentageChanged += SetValue;
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.Health / _player.MaxHealth;
    }

    public void SetValue(float value)
    {
        _targetValue = value;

        if (_scoreCoroutine != null)
        {
            StopCoroutine(_scoreCoroutine);
        }

        _scoreCoroutine = StartCoroutine(UpdateValue());
    }

    private IEnumerator UpdateValue()
    {
        float minimumDifference = 0.001f;

        while (Mathf.Abs(_targetValue - _slider.value) > minimumDifference)
        {
            _slider.value = Mathf.SmoothDamp(_slider.value, _targetValue, ref _velocity, _animationSpeed);
            yield return null;
        }

        yield return null;
    }
}
