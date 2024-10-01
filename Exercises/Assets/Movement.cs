using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    private float _minY = -5f;
    private float _maxY = 5f;
    private  float _timer;

    void Update()
    {
        _timer += Time.deltaTime * _speed;
        float y_position = Mathf.PingPong(_timer, _maxY - _minY) + _minY;
        transform.position  = new Vector3(0,y_position,0);
    }

   
}