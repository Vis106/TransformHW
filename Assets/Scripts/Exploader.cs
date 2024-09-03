using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private float _explotionForce;
    [SerializeField] private float _explotionRadius;

    public void Explode(List<Rigidbody> cubes, float explosionScale)
    {
        foreach (Rigidbody explodableObject in cubes)
        {
            var explodableCube = explodableObject.GetComponent<Rigidbody>();
            explodableCube?.AddExplosionForce(_explotionForce * explosionScale, transform.position, _explotionRadius);
        }
    }

    public void ExplodeAll(float explosionScale)
    {
        Explode(GetExplodableCubes(), explosionScale);
    }

    public List<Rigidbody> GetExplodableCubes()
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
}
