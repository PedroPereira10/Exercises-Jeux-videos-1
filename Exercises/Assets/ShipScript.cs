using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotation;
    [SerializeField] Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovement();
    }

    void ControlMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.forward * horizontalInput * _rotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = transform.up * _speed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
