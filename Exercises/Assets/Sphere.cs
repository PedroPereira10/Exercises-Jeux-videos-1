using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed;

    void FixedUpdate()
    {
        ControlMovement();
    }

    void ControlMovement()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction.z = -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.z = 1;
        }

        _rigidBody.velocity = direction * _speed;
    }
}
