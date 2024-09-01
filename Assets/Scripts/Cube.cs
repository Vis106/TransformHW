using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _decreaseChanceRate = 0.5f;
    [SerializeField] private float _decreaseScaleRate = 0.5f;
    [SerializeField] private float _chanceCreate = 100;
    [SerializeField] private float _explosionScale = 1;
    [SerializeField] private float _increaseExplosionScale = 1.5f;
    [SerializeField] private Creator _creator;

    private int _maxChance = 100;
    private int _minChance = 1;

    private void OnMouseUpAsButton()
    {
        _creator.Divide(this, CanDivide(), _explosionScale);
        Destroy(gameObject);
    }

    public void Init()
    {
        _chanceCreate *= _decreaseChanceRate;
        Vector3 scaleChange = transform.localScale / _decreaseScaleRate;
        transform.localScale -= scaleChange;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        _explosionScale *= _increaseExplosionScale;
    }

    public bool CanDivide()
    {
        var currentChance = Random.Range(_minChance, _maxChance);
        return currentChance <= _chanceCreate;
    }
}
