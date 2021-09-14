using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject Bombs;
    private float Timer = 1.5f;
    //[SerializeField] private GameObject _enemyPrefub;
    private Collider other;

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            //Instantiate(_enemyPrefub, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
