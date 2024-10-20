using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast1 : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 5f;
    [SerializeField] Transform _radarHead;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);

        Vector3 origine = _radarHead.position;
        Vector3 direction = _radarHead.forward;
        Ray ray = new Ray(origine, direction);
        RaycastHit hit;

        Debug.DrawLine(origine, direction*1000f, Color.red);

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            string objectName = hit.collider.gameObject.name;

            if (objectName == "Cube 1" || objectName == "Cube 2")
            {
                Debug.Log("Le Raycast touched the cube");
            }
            else if (objectName == "Wall")
            {
                Debug.Log("Le Raycast touched the wall.");
            }
        }
        else
        {
            Debug.Log("Le Raycast touches nothing.");
        }
    }
}
