using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private float _countStepTime = 0.5f;
    [SerializeField] private float _countStep = 1f;

    private float _count = 0f;
    private bool _isCounting = false;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_countStepTime);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting == false)
            {
                _isCounting = true;
                StartCoroutine(CountingBySteps());
            }
            else
            {
                _isCounting = false;
                StopCoroutine(CountingBySteps());
            }
        }
    }

    private IEnumerator CountingBySteps()
    {
        while (_isCounting)
        {
            _count += _countStep;
            _countText.text = _count.ToString();
            yield return _wait;
        }
    }
}
