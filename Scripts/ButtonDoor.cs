using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    Transform text;
    private bool _button;
    private bool _boolSwitch = true;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            _button = true;
            Debug.Log("enter button");
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Игрок вошёл");
        }
    }

    private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Игрок в зоне триггера");
            if (_button){

                door.GetComponent<Door>().Initialization(_boolSwitch);  //Надо для открытия двери
                _button = false;
                _boolSwitch = _boolSwitch ? false : true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Игрок вышел");
        }
    }
}
