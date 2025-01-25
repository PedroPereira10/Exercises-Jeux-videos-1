using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumaration : MonoBehaviour
{
    private enum Directon
    {
        North,
        South,
        West,
        East,
        Foward,
        Back
    }

    [SerializeField] Directon _currentDirection;
    [SerializeField] Rigidbody _rb;
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 movement = Vector3.zero;


        switch (_currentDirection)
        {
            case Directon.North:
                movement = Vector3.up;
                break;
            case Directon.South:
                movement = Vector3.down;
                break;
            case Directon.West:
                movement = Vector3.left;
                break;
            case Directon.East:
                movement = Vector3.right;
                break;
            case Directon.Foward:
                movement = Vector3.forward;
                break;
            case Directon.Back:
                movement = Vector3.back;
                break;
            default:
                break;
        }

        if (_rb != null)
        { 
            _rb.MovePosition(transform.position + movement * _speed * Time.deltaTime); // Pega a posição do objeto, calcula o deslocamento da (direção * velocidade * tempo tomado) _MovePosition atualiza a posição do objeto.
        }
        else
        {
            transform.Translate(movement*_speed*Time.deltaTime, Space.World);
        }
    }
}
