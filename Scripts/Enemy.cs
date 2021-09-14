using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _bulletPrefub, _enemyPrefub;
    [SerializeField] private Transform _bulletSpawn;
    
    // public GameObject _bomb, Effects;

    private void Awake()
    {
        //_target = FindObjectOfType<Hero>().transform;
    }

    public void Initialization()
    {
        Destroy(gameObject);
    }
    
    void FixedUpdate()
    {
        if (_target == null) return;

        Vector3 direction = _target.position - _head.position;
        direction.Set(direction.x, _head.position.y, direction.z);

        Vector3 stepDirection = Vector3.RotateTowards(_head.forward, direction, _speed * Time.fixedDeltaTime, 0.0f);

        _head.transform.rotation = Quaternion.LookRotation(stepDirection);
    }

    private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _target = other.transform;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _target = null;
        
        if (other.tag == "Enemy")
        {
            Instantiate(_enemyPrefub, other.transform.position, other.transform.rotation);
        }
        //Destroy(other.gameObject);
        Destroy(gameObject);
    }
}