using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFAK : MonoBehaviour
{
    [SerializeField] private GameObject FirstAidKits;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Destroy(gameObject);
    }
}
