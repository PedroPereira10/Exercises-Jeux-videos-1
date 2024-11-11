using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _stoppingDistance = 1f;
    [SerializeField] private float _attackCoolDown = 1.5f;
    [SerializeField] private int _damage = 5;

    private Camera _camera;
    private Rigidbody _rb;
    private Animator _animator;
    private Vector3 _targetPosition;

    void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _targetPosition = hit.point;
                transform.LookAt(_targetPosition);
            }
        }

        float distance = (transform.position - _targetPosition).magnitude;
        
        if(distance > _stoppingDistance)
        {
            Vector3 direction = (_targetPosition - transform.position).normalized;
            _rb.velocity = _movementSpeed * direction;
            _animator.SetBool("IsWalking", true);
        }

        else
        {
            _animator.SetBool("IsWalking", false);
            _rb.velocity = Vector3.zero;
        }
    }
}
