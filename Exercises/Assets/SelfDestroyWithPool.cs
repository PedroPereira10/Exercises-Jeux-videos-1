using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyWithPool : MonoBehaviour
{

    [SerializeField] private float _selfDestroyDelay = 5f;

    private void OnEnable()
    {
        StartCoroutine(SelfDestroyafterDelay());
    }

    private IEnumerator SelfDestroyafterDelay()
    {
        yield return new WaitForSeconds(_selfDestroyDelay);
        ObjectPoolManager._instance.ReturnObjectToPool(gameObject);
    }
}
