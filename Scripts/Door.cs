using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public float _openOrClose = 30f;
	private bool _isButton;
	private float count;

	public void Initialization(bool isButton){
		_isButton = isButton;
	}

	void FixedUpdate(){
		if (_isButton && count <= 88){
			Debug.Log("Opened door");
			transform.Rotate(Vector3.up * _openOrClose * Time.fixedDeltaTime);
			count += _openOrClose * Time.fixedDeltaTime;
		}

		if (!_isButton && count > 0 ){
			Debug.Log("Closing door");
			transform.Rotate(-Vector3.up * _openOrClose * Time.fixedDeltaTime);
			count -= _openOrClose * Time.fixedDeltaTime;
		}
	}
}
