using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        //if (other.gameObject.CompareTag("Player")){
        if (other) {
            Debug.Log(other);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("exit");
        }
    }
}
