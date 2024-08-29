using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Creator : MonoBehaviour
{
    [SerializeField] private float _explotionForce;
    [SerializeField] private float _explotionRadius;
   
    private int _maxCubeInstanstiate = 6;
    private int _minCubeInstanstiate = 2;
    private Cube _cubePrefab;

    public void Divide()
    {
        _cubePrefab = GetComponent<Cube>();
        Explode();        
        CreateCubes(_cubePrefab.CanCreate());       
    }

    private void Explode()
    {
        foreach (Cube explodableObject in CreateCubes(_cubePrefab.CanCreate()))
        {
            explodableObject.TryGetComponent<Rigidbody>(out Rigidbody explodableCube);
            explodableCube?.AddExplosionForce(_explotionForce, transform.position, _explotionRadius);
        }
    }

    private List<Cube> CreateCubes(bool canCreate)
    {
        List<Cube> cubes = new();
        int cubeCount = Random.Range(_minCubeInstanstiate, _maxCubeInstanstiate);       

        if (canCreate)
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
