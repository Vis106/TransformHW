using TMPro;
using UnityEngine;

public class CountShower : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _countText;

    private void OnEnable()
    {
        _counter.Changed += Change;
    }

    private void OnDisable()
    {
        _counter.Changed -= Change;
    }

    private void Change(float value)
    {
        _countText.text = value.ToString();
    }
}
