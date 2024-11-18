using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkill : MonoBehaviour
{
    [SerializeField] private FireBall _fireball;
    [SerializeField] private Transform _characterHand;
    [SerializeField] private float _coolDownDelay = 5f;
    [SerializeField] private float _animationDelay = 0.5f;
    [SerializeField] private Animator _animator;

    private float _timer;

    void Start()
    {

    }


    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse1) && _timer > _coolDownDelay)
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            { 
                HealthAndDefense health = hit.collider.GetComponent<HealthAndDefense>();
                if ( health != null)
                {
                    _animator.transform.LookAt(health.transform.position);
                    StartCoroutine(SendFireball(health.transform));
                }
            }
        }
    }

    private IEnumerator SendFireball (Transform target)
    {
        _animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(_animationDelay);
        FireBall newfireball = Instantiate(_fireball, _characterHand.position, Quaternion.identity);
        newfireball.SetTarget(target);
        _timer = 0;
    }
}
