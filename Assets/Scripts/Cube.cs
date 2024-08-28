using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _decreaseChanceRate = 0.5f;
    [SerializeField] private float _decreaseScaleRate = 0.5f;
    [SerializeField] private float _chanceCreateCube = 100;  
    [SerializeField] private Creator _creator;
     
    public float ChanceCreateCube => _chanceCreateCube;
    public float DecreaseRate => _decreaseChanceRate;    

    private void OnMouseUpAsButton()
    {
        _creator.Divide();          
    }

    public void Init()
    {
        _chanceCreateCube *= _decreaseChanceRate;
        Vector3 scaleChange = transform.localScale / _decreaseScaleRate;
        transform.localScale -= scaleChange;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
