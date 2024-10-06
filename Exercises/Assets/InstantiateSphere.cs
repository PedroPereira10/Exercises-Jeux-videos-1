using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSphere : MonoBehaviour
{
    [SerializeField] GameObject _spherePrefab;
    [SerializeField] Transform _emptyObject;
    [SerializeField] float _maxX = 10f;
    [SerializeField] float _maxY = 10f;

    private int _numberOfSpheres = 6;
    private List<GameObject> _spheres = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < _numberOfSpheres; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-_maxX, _maxX), Random.Range(-_maxY, _maxY), 0);
            GameObject newSphere = Instantiate(_spherePrefab, randomPosition, Quaternion.identity);
            _spheres.Add(newSphere);

            newSphere.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    void Update()
    {
        foreach (GameObject sphere in _spheres)
        {
            float distance = Vector3.Distance(sphere.transform.position, _emptyObject.position);

            SpriteRenderer sphereRenderer = sphere.GetComponent<SpriteRenderer>();

            if (distance <= 2f)
            {
                sphereRenderer.color = Color.red;
            }

            else
            {
                sphereRenderer.color = Color.white;
            }
        }

        
    }
}
