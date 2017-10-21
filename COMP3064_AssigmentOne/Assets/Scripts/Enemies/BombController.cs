/***
 * Source File: BombController.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

	//Visible to Unity variables
	[SerializeField]
	private float startX = 10f;
	[SerializeField]
	private float endX = 12f;
	[SerializeField]
	private float startY = 4.5f;
	[SerializeField]
	private float endY = -4.5f;

	[SerializeField]
	float minYSpeed = 0f;
	[SerializeField]
	float maxYSpeed = 0.14f;
	[SerializeField]
	float minXSpeed = 0.06f;
	[SerializeField]
	float maxXSpeed = 0.1f;

	//private variables
	private Transform _transform;
	private Vector2 _currentPosition;
	private Vector2 _currentSpeed;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		_currentPosition = _transform.position;
		_currentPosition -= _currentSpeed;
		_transform.position = _currentPosition;

		if (_currentPosition.y <= endY) {
			Reset ();
		}

	}

	/// <summary>
	/// Reset this instance.
	/// </summary>
	public void Reset(){

		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float x = Random.Range (startX, endX); 
		_transform.position = 
			new Vector2 (x, startY + Random.Range (1, 3));
	}
}



