using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalls : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidBody;

    void FixedUpdate()
    {
        ControlMovement();
    }

    void ControlMovement()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
        }

        _rigidBody.velocity = direction * _speed;
    }
}
