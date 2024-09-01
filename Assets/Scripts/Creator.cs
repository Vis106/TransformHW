using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Creator : MonoBehaviour
{
    [SerializeField] private float _explotionForce;
    [SerializeField] private float _explotionRadius;

    private int _maxCubeInstanstiate = 6;
    private int _minCubeInstanstiate = 2;

    public void Divide(Cube _currentCube, bool isDivided, float explosionScale)
    {
        if (isDivided)
            Explode(CreateCubes(_currentCube), explosionScale);
        else
            Explode(GetExplodableCubes(), explosionScale);
    }

    private void Explode(List<Rigidbody> cubes, float explosionScale)
    {
        foreach (Rigidbody explodableObject in cubes)
        {
            explodableObject.TryGetComponent<Rigidbody>(out Rigidbody explodableCube);
            explodableCube?.AddExplosionForce(_explotionForce* explosionScale, transform.position, _explotionRadius);
        }
    }

    private List<Rigidbody> GetExplodableCubes()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explotionRadius);

        List<Rigidbody> cubes = new();

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }

    private List<Rigidbody> CreateCubes(Cube _currentCube)
    {
        List<Rigidbody> cubes = new();
        int cubesCount = Random.Range(_minCubeInstanstiate, _maxCubeInstanstiate);

        for (int i = 0; i < cubesCount; i++)
        {
            var cube = Instantiate(_currentCube, transform.position, transform.rotation);
            cube.Init();
        }

        return cubes;
    }
}