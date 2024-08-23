using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _decreaseChanceRate = 0.5f;
    [SerializeField] private float _decreaseScaleRate = 0.5f;
    [SerializeField] private float _chanceCreateCube = 100;

    public float ChanceCreateCube => _chanceCreateCube;
    public float DecreaseRate => _decreaseChanceRate;

    public void ChangeChance()
    {
        _chanceCreateCube *= _decreaseChanceRate;
    }

    public void ChangeScale()
    {
        Vector3 scaleChange = transform.localScale / _decreaseScaleRate;       
        transform.localScale -= scaleChange;
    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();            
    }
}
