using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class ObjectPoolManager : MonoBehaviour
{

    public static ObjectPoolManager _instance;
    private List<Pool> _objectPool = new();
    private List<GameObject> _poolParent = new();

    private void Awake()
    {
        if (_instance != null)
        { 
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }

    public GameObject SpawnObjectFromPool(GameObject objToSpawn,Vector3 spawnPos, Quaternion spawnRotation)
    {
        Pool pool = _objectPool.Find(p=>p._poolName == objToSpawn.name);
        if (pool == null) 
        { 
            pool =  new Pool() { _poolName = objToSpawn.name };
            _objectPool.Add(pool);
            GameObject newPoolParent = new GameObject(objToSpawn.name);
            newPoolParent.transform.parent = transform;
            _poolParent.Add(newPoolParent);
        }
        GameObject spawnableObj = null;

        foreach(GameObject obj in pool._inactiveObjects)
        {
            if (_objectPool != null)
            {
                spawnableObj = obj;
                break;
            }
        }

        if (spawnableObj == null)
        {
            spawnableObj = Instantiate(objToSpawn, spawnPos, spawnRotation);
            spawnableObj.transform.parent = _poolParent.Find(p => p.name == objToSpawn.name).transform;
        }
        else
        {
            spawnableObj.transform.position = spawnPos;
            spawnableObj.transform.rotation = spawnRotation;
            pool._inactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }
        return spawnableObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        string gameObjectName = obj.name.Substring(0, obj.name.Length - 7);
        Pool pool = _objectPool.Find(p => p._poolName == gameObjectName);

        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that's not pooled" + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool._inactiveObjects.Add(obj);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

public class Pool
{
    public string _poolName;
    public List<GameObject> _inactiveObjects = new();
}
