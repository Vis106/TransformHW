using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    private int _maxCubeInstanstiate = 7;
    private int _minCubeInstanstiate = 2;

    public List<Rigidbody> CreateCubes(Cube _currentCube)
    {
        List<Rigidbody> cubes = new();
        int cubesCount = Random.Range(_minCubeInstanstiate, _maxCubeInstanstiate);

        for (int i = 0; i < cubesCount; i++)
        {
            var cube = Instantiate(_currentCube, transform.position, transform.rotation);
            cube.Init();
            cubes.Add(cube.GetComponent<Rigidbody>());
        }

        return cubes;
    }
}