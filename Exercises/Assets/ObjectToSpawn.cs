using UnityEngine;


public class ObjectToSpawn : MonoBehaviour
{
    [SerializeField] private float _selfDestroyMaxDelay = 10f;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _objectSpeed = 5f;

    
    void Start()
    {
        GameManager._instance.IncreaseNbOfObject();

        _meshRenderer.material.color = Random.ColorHSV(0f, 1f);

        Destroy(gameObject, Random.Range(0f, _selfDestroyMaxDelay));

        Rigidbody _rb = GetComponent<Rigidbody>();
        if (_rb != null )
        {
            Vector3 randomDirection = Random.onUnitSphere;
           // This is like the one up here new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).Normalize();
            randomDirection.y = Mathf.Abs(randomDirection.y); 

            _rb.velocity = randomDirection * _objectSpeed;
        }
    }

    private void OnDestroy()
    {
        GameManager._instance.DecreaseNbOfObject();
    }
}
