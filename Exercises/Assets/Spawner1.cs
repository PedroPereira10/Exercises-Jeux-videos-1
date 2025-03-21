using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _spherePrefab;

    [SerializeField] private float _objSpeed = 5f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject cube = ObjectPoolManager._instance.SpawnObjectFromPool(_cubePrefab, transform.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().velocity = Vector3.one.normalized * _objSpeed;
        }

        if(Input.GetMouseButtonDown(1))
        {
            GameObject sphere = ObjectPoolManager._instance.SpawnObjectFromPool(_spherePrefab, transform.position, Quaternion.identity);
            sphere.GetComponent<Rigidbody>().velocity = new Vector3(-1,1,1).normalized * _objSpeed;
        }
    }
}
