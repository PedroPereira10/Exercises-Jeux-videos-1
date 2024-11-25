using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectToSpawn _objectToSpawn;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Instantiate(_objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
