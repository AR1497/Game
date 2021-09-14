using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public bool _takeObject = false;
    [SerializeField] private GameObject fak;

    void Update()
    {
        if (_takeObject)
        {
            Destroy(fak);
        }
    }
}
