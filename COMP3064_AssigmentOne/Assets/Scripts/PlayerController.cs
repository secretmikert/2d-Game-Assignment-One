/***
 * Source File: PlayerController.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed;

	private Transform _transform;
	private Vector2 _currentPosition;
	private float _playerInputX;
	private float _playerInputY;

	private PlayerController instance;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake() {

		instance = gameObject.GetComponent<PlayerController>();
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {

		_transform = gameObject.GetComponent<Transform>();
		_currentPosition = _transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

		_playerInputX = Input.GetAxis ("Horizontal");
		_playerInputY = Input.GetAxis ("Vertical");

		_currentPosition = _transform.position;
		//move right
		if (_playerInputX > 0) {
			_currentPosition += new Vector2 (speed, 0);
		}
		//move left
		if (_playerInputX < 0) {
			_currentPosition -= new Vector2 (speed, 0);
		}

		//move right
		if (_playerInputY > 0) {
			_currentPosition += new Vector2 (0, speed);
		}
		//move left
		if (_playerInputY < 0) {
			_currentPosition -= new Vector2 (0, speed);
		}
		//fix bounds
		checkBounds ();
		_transform.position = _currentPosition;
	}

	/// <summary>
	/// Checks the bounds of the screen. Does not allow the palyer to exit the scene. 
	/// </summary>
	private void checkBounds(){

		if (_currentPosition.x < -6.8) {
			_currentPosition.x = -6.8f;
		}
		if (_currentPosition.x > 6.8f) {
			_currentPosition.x = 6.8f;
		}

		if (_currentPosition.y > 4.5f) {
			_currentPosition.y = 4.5f;
		}

		if (_currentPosition.y < -4.5f) {
			_currentPosition.y = -4.5f;
		}
	}

}
