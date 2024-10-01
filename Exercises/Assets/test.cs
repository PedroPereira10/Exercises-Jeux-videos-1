using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _nbToInstantiate = 15;
    

    private void Start()
    {
        for (int i = 0; i < _nbToInstantiate; i++)
        {
            float _speed = i;
            GameObject newObject = Instantiate(_prefab, new Vector3(0,0,0), Quaternion.identity);
            newObject.name = i.ToString();
            newObject.GetComponent<Rigidbody2D>().velocity = i * GetDirection(i % 4);
        }
    }

    private Vector3 GetDirection(int index)
    {
        switch (index)
        {
            case 0:
                return new Vector3(1, 0, 0);
                break;
            case 1:
                return new Vector3(0, 1, 0);
                break;
            case 2:
                return new Vector3(-1, 0, 0);
            case 3:
                return new Vector3(0,-1,0);
                break;
            default:
                return new Vector3(0, 0,0);
                break;
        }
    }
}
