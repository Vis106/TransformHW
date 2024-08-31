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

    public void Divide(Cube _currentCube)
    {
        Explode(CreateCubes(_currentCube));   
    }

    private void Explode(List<Cube> cubes)
    {
        foreach (Cube explodableObject in cubes)
        {
            explodableObject.TryGetComponent<Rigidbody>(out Rigidbody explodableCube);
            explodableCube?.AddExplosionForce(_explotionForce, transform.position, _explotionRadius);
        }
    }

    private List<Cube> CreateCubes(Cube _currentCube)
    {
        List<Cube> cubes = new();
        int cubesCount = Random.Range(_minCubeInstanstiate, _maxCubeInstanstiate);

        for (int i = 0; i < cubesCount; i++)
        {
            var cube = Instantiate(_currentCube, transform.position, transform.rotation);
            cube.Init();
        }

        return cubes;
    }
}