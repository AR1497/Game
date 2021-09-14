using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefub, _enemyPrefub;
    [SerializeField] private Transform _bulletSpawn, _enemySpawn;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate = 50f;
    private static int _id = 0;
    private Vector3 _direction;
    private float _cfSpeed = 1f;
    private bool _isFire1;
    private bool _isFire2;
    private bool _isSprint;
    private bool _isEner;


    // public float turnSpeed = 50f;

    // public GameObject _bomb, Effects;

    private void Awake()
    {
        _isFire1 = false;
        _isFire2 = false;
        _isEner = false;
        name = "Hero" + _id++;
        _direction = Vector3.zero;
    }

    void Start()
    {
        FindObjectOfType<Hero>();

        float distance = Vector3.Distance(transform.position, _target.position);
    }

    //Update is called once per frame
    void Update()
    {
        _isFire1 = Input.GetMouseButtonDown(0);
        _isFire2 = Input.GetMouseButtonDown(1);

        _isSprint = Input.GetButton("Sprint");

        _isEner = Input.GetButton("Enem");
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        // float forwardMovement = Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;
        // float turnMovement = Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;

        // transform.Translate(Vector3.forward * forwardMovement);
        // transform.Rotate(Vector3.up * turnMovement);
        
        // if (Input.GetKey(KeyCode.A)){                                                      // Почему не работает? Как это можно испарвить?
        //     transform.rotation *= Quaternion.Euler(0f, 90f * Time.fixedDeltaTime, 0f);
        // }

        // if (Input.GetKey(KeyCode.B)){
        //     transform.rotation *= Quaternion.Euler(0f, -90f * Time.fixedDeltaTime, 0f);
        // }

        float sprint = (_isSprint) ? 2f : 1f;

        transform.Translate(_direction.normalized * _speed * sprint * _cfSpeed * Time.fixedDeltaTime);
        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * _speedRotate * Time.fixedDeltaTime);   //Странное перемещение, не выходит совместить позицию.

        if (_isFire1)
        {
           Fire(true); 
        } 
        
        if (_isFire2)
        {
            Fire(false);
        }

        if (_isEner)
        {
            Energence();
        }
    }

    private void Fire(bool selfHoming)
    {
        if (selfHoming)
            _isFire1 = false;
        else
            _isFire2 = false;
            
        GameObject bullet = Instantiate(_bulletPrefub, _bulletSpawn.position,  Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialization(15f, _target, selfHoming);
    }

    private void Energence()
    {
        _isEner = false;
        GameObject enemy = Instantiate(_enemyPrefub, _enemySpawn.position, Quaternion.identity);
        enemy.GetComponent<Enemy>();
    }

    public void SetBootsSpeed(float cfSpeed)
    {
        _cfSpeed = cfSpeed;
    }

    [SerializeField] private GameObject FirstAidKits;
    private void OnTriggerExit(Collider other)
    {   
        if (other.tag == "Player")
        {
            Debug.Log("Объект взят");
            Destroy(FirstAidKits);
        }
    }
}