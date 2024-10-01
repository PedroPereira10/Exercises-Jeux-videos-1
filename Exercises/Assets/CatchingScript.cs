using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingScript : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] GameObject _ball;
    Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer.color = Color.red;
    }

    
    void Update()
    {
        Vector2 direction = (_ball.transform.position - transform.position).normalized;

        _rigidbody.velocity = direction * _speed;

        float distance = Vector2.Distance(transform.position, _ball.transform.position);

        Color color = Color.red;
        if(distance <5)
        {
            color = Color.green;
        }

        _ball.GetComponentInChildren<SpriteRenderer>().color = color;

        Debug.Log(_rigidbody.velocity.magnitude + " [m/s]");
    }
    
}

