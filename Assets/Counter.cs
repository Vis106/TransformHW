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
    private byte _mousebutton = 0;

    public static Action<float> Changed;

    private void Awake()
    {
        _countCoroutine = StartCoroutine(CountingBySteps());
        _wait = new WaitForSeconds(_countStepTime);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mousebutton))
        {
            if (_isCounting == false)
            {
                _isCounting = true;
                Start();
            }
            else
            {
                _isCounting = false;
                Stop();
            }
        }
    }

    public void Start()
    {
        _countCoroutine = StartCoroutine(CountingBySteps());
    }

    public void Stop()
    {
        if (_countCoroutine != null)
        {
            StopCoroutine(_countCoroutine);
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
