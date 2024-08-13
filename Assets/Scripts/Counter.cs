using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countStepTime = 0.5f;
    [SerializeField] private float _countStep = 1f;

    private float _count = 0f;
    private bool _isCounting = false;
    private WaitForSeconds _wait;
    private Coroutine _countCoroutine;
    private byte _mouseButton = 0;

    public event Action<float> Changed;

    private void Awake()
    {
        _countCoroutine = StartCoroutine(CountingBySteps());
        _wait = new WaitForSeconds(_countStepTime);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            if (_isCounting == false)
            {
                _isCounting = true;
                _countCoroutine = StartCoroutine(CountingBySteps());
            }
            else
            {
                _isCounting = false;
                if (_countCoroutine != null)
                {
                    StopCoroutine(_countCoroutine);
                }
            }
        }
    }

    private IEnumerator CountingBySteps()
    {
        while (_isCounting)
        {
            _count += _countStep;
            Changed?.Invoke(_count);
            yield return _wait;
        }
    }
}
