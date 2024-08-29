using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _decreaseChanceRate = 0.5f;
    [SerializeField] private float _decreaseScaleRate = 0.5f;
    [SerializeField] private float _chanceCreate = 100;  
    [SerializeField] private Creator _creator;

    private int _maxChance = 100;
    private int _minChance = 1;

    public float ÑhanceCreate => _chanceCreate;
    public float DecreaseRate => _decreaseChanceRate;    

    private void OnMouseUpAsButton()
    {
        _creator.Divide();
        Destroy(gameObject);
    }

    public void Init()
    {
        _chanceCreate *= _decreaseChanceRate;
        Vector3 scaleChange = transform.localScale / _decreaseScaleRate;
        transform.localScale -= scaleChange;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public bool CanCreate()
    {
        var currentChance = Random.Range(_minChance, _maxChance);
        return currentChance <= ÑhanceCreate;
    }
}
