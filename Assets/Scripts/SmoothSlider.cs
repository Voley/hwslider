using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class SmoothSlider : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;
    [SerializeField] private float _initialValue;

    private Slider _slider;
    private float _targetValue;
    private float _velocity;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _targetValue = _initialValue;
    }

    private void Update()
    {
        _slider.value = Mathf.SmoothDamp(_slider.value, _targetValue, ref _velocity, _animationSpeed);
    }

    public void SetValue(float value)
    {
        _targetValue = value;
    }
}
