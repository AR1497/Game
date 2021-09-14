using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Transform _target;
    private Vector3 _point;
    private bool _selfHoming;
    public string findEnemyTag;
    
    public void Initialization(float lifetime, Transform target, bool selfHoming = true)
    {
        _target = target;
        _point = target.position;
        _selfHoming = selfHoming;

        Destroy(gameObject, lifetime);
    }

    void Update(){

        transform.position += transform.forward * _speed * Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       // transform.position = Vector3.MoveTowards(transform.position, (_selfHoming) ? _target.position : _point, _speed * Time.fixedDeltaTime);
    }
}
