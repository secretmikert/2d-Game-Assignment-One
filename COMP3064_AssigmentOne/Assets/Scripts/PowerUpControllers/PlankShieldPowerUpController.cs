/***
 * Source File: PlankShieldPowerUpController.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankShieldPowerUpController : MonoBehaviour {

		//Public to Unity variables
		[SerializeField]
		private float startX = 6.8f;
		[SerializeField]
		private float endX = -6.8f;
		[SerializeField]
		private float startY = 4.5f;
		[SerializeField]
		private float endY = -4.5f;

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

			if (_currentPosition.x <= endX-2) {
				Destroy (gameObject);
			}

		}

		/// <summary>
		/// Reset this instance.
		/// </summary>
		public void Reset(){

			float xSpeed = Random.Range (minXSpeed, maxXSpeed);

			_currentSpeed = new Vector2 (xSpeed, 0);

			float y = Random.Range (endY, startY); 
			_transform.position = 
				new Vector2 (startX + Random.Range (20, 30), y);

		}
	}


