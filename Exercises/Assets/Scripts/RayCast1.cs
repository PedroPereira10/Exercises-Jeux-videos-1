using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast1 : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 5f;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _rayCastLenght = 1000f;

    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime,0);
        Vector3 origine = transform.position;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(origine, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayCastLenght, _layer))
        {
            string name = hit.collider.gameObject.name;
            Debug.Log($"Name:{name} --- Hit Distance: {hit.distance} --- Hit Position: {hit.point} --- {name} position: {hit.collider.transform.position}");
            Debug.DrawRay(origine, direction * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(origine, direction * _rayCastLenght, Color.red);
        }
    }
}
