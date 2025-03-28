using System.Collections;
using UnityEngine;

public class Exercice28 : MonoBehaviour
{
    [SerializeField] private GameObject _prefab1;
    [SerializeField] private GameObject _prefab2;

    private int _counter;
    private float _time1;
    private float _time2;

    private void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        /////////////////////////////////////////
        yield return new WaitForSeconds(2f);

        _time1 = Time.realtimeSinceStartup;
        //1
        for (int i = 0; i < 500; i++)
        {
            
            float distance = new Vector3(10, 10, 10).magnitude;
        }
        _time2 = Time.realtimeSinceStartup;
        Debug.Log("Time 1: " + (_time2 - _time1));
        ///////////////////////////////////////////////
        yield return new WaitForSeconds(2f);

        _time1 = Time.realtimeSinceStartup;
        //2
        for (int i = 0; i < 125; i++)
        {
            Debug.Log("This is a very important message");
        }
        _time2 = Time.realtimeSinceStartup;
        Debug.Log("Time 2: " + (_time2 - _time1));
        //////////////////////////////////////////////////
        
        yield return new WaitForSeconds(1f);

        //3
        _time1 = Time.realtimeSinceStartup;
        Factorial(10000);

        _time2 = Time.realtimeSinceStartup;
        Debug.Log("Time 3: " + (_time2 - _time1));


        
        ///////////////////////////////////////////////////
        yield return new WaitForSeconds(1f);
        _time1 = Time.realtimeSinceStartup;
        //4
        for (int i = 0; i < 75; i++)
        {
            Instantiate(_prefab1);
        }

        _time2 = Time.realtimeSinceStartup;
        Debug.Log("Time 4: " + (_time2 - _time1));
        ////////////////////////////////////////////////
        
        yield return new WaitForSeconds(1f);
        _time1 = Time.realtimeSinceStartup;
        //5
        for (int i = 0; i < 75; i++)
        {
            Instantiate(_prefab2);
        }

        _time2 = Time.realtimeSinceStartup;
        Debug.Log("Time 5: " + (_time2 - _time1));
        ///////////////////////////////////////////////////
        
        yield return new WaitForSeconds(1f);
        _time1 = Time.realtimeSinceStartup;
        //6
        for (int i = 0; i < 500; i++)
        {
            if (Physics.Raycast(transform.position, transform.forward, 100))
            {
                _counter++;
            };
        }

        _time2 = Time.realtimeSinceStartup;
        Debug.Log("Time 6: " + (_time2 - _time1));
    }

    private int Factorial(int value)
    {
        if (value > 1)
        {
            return value * Factorial(value - 1);
        }
        else
        {
            return value;
        }
    }
}
