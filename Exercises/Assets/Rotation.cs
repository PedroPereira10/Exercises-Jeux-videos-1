using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform _sun;
    [SerializeField] private float _orbitSpeed = 10f;
   
    void Update()
    {
        OrbitRotation();
    }

    private void OrbitRotation()
    {
        transform.RotateAround(_sun.position,Vector3.up,_orbitSpeed * Time.deltaTime);
    }
}
