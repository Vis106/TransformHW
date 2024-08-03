using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _scale;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.left);
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
        transform.localScale += new Vector3(1, 1, 1) * _scale * Time.deltaTime;
    }

}
