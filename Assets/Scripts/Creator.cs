using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explotionForce;
    [SerializeField] private float _explotionRadius;
    [SerializeField] private float _decreaseScaleRate = 0.5f;

    private int _maxCubeInstanstiate = 6;
    private int _minCubeInstanstiate = 2;
    private int _positionGap = 2;
    private int _maxChance = 100;
    private int _minChance = 1;

    private void OnMouseUpAsButton()
    {
        Explode();
        Destroy(gameObject);
        CreateCube();
    }

    private void Explode()
    {
        foreach (Cube explodableObject in CreateCube())
        {
            explodableObject.TryGetComponent<Rigidbody>(out Rigidbody explodableCube);
            explodableCube.AddExplosionForce(_explotionForce, transform.position, _explotionRadius);
        }
    }

    private bool CheckChance()
    {
        var currentChance = Random.Range(_minChance, _maxChance);
        return currentChance <= _cubePrefab.ChanceCreateCube;
    }

    private List<Cube> CreateCube()
    {
        List<Cube> cubes = new();
        int cubeCount = Random.Range(_minCubeInstanstiate, _maxCubeInstanstiate);

        if (CheckChance())
        {
            for (int i = 0; i < cubeCount; i++)
            {
                var cube = Instantiate(_cubePrefab, transform.position, transform.rotation);
                int positionGap = Random.Range(0, _positionGap);
                cube.transform.position += new Vector3(positionGap, positionGap, positionGap);
                cube.ChangeChance();
                cube.ChangeColor();
                cube.ChangeScale();
            }
        }

        return cubes;
    }
}
