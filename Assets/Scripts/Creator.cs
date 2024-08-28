using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explotionForce;
    [SerializeField] private float _explotionRadius;
   
    private int _maxCubeInstanstiate = 6;
    private int _minCubeInstanstiate = 2;
    private int _maxChance = 100;
    private int _minChance = 1;      

    public void Divide()
    {
        Explode();
        Destroy(gameObject);
        CreateCubes();       
    }

    private void Explode()
    {
        foreach (Cube explodableObject in CreateCubes())
        {
            explodableObject.TryGetComponent<Rigidbody>(out Rigidbody explodableCube);
            explodableCube?.AddExplosionForce(_explotionForce, transform.position, _explotionRadius);
        }
    }

    private bool CanCreate()
    {
        var currentChance = Random.Range(_minChance, _maxChance);
        return currentChance <= _cubePrefab.ChanceCreateCube;
    }

    private List<Cube> CreateCubes()
    {
        List<Cube> cubes = new();
        int cubeCount = Random.Range(_minCubeInstanstiate, _maxCubeInstanstiate);

        if (CanCreate())
        {
            for (int i = 0; i < cubeCount; i++)
            {
                var cube = Instantiate(_cubePrefab, transform.position, transform.rotation);
                cube.Init();               
            }
        }

        return cubes;
    }
}
