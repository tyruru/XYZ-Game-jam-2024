using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 60;
    [SerializeField] private int _firstStageTime;
    [SerializeField] private Color _firstStageColor;
    [SerializeField] private int _secondStageTime;
    [SerializeField] private Color _secondStageColor;
    [SerializeField] private Color _baseColor;

    private float _currentTime;
    private TextMeshProUGUI _textMeshPro;
    private float _gameTime;

    public static event Action OnTimerOut;

    private void Awake()
    {
        _currentTime = _lifeTime;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textMeshPro.text = "" + _currentTime;
        _gameTime += 1 * Time.deltaTime;

        if(_gameTime >= 1)
        {
            _currentTime -= 1;
            _gameTime = 0;
        }

        if(_currentTime <= _firstStageTime)
        {
            _textMeshPro.color = Color.yellow;
        }

        if (_currentTime <= _secondStageTime)
            _textMeshPro.color = _secondStageColor;

        if (_currentTime <= 0)
        {
            RestartTimer();
            OnTimerOut?.Invoke();
        }
    }

    private void RestartTimer()
    {
        _currentTime = _lifeTime;
        _textMeshPro.color = _baseColor;
    }
}
