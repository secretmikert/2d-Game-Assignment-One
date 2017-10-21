/***
 * Source File: PlankShieldCollisionController.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankShieldCollisionController : MonoBehaviour {

		[SerializeField]
		GameObject explosion;

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () {
		
		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update () { }

		/// <summary>
		/// Raises the trigger enter2 d event.
		/// </summary>
		/// <param name="other">Other.</param>
		public void OnTriggerEnter2D(Collider2D other){

			//If collides with rocket 
			if (other.gameObject.tag.Equals ("rocket")) {
				Instantiate (explosion)
					.GetComponent<Transform> ()
					.position = other.gameObject
						.GetComponent<Transform> ()
						.position;

				other.gameObject.
				GetComponent<RocketController> ()
					.Reset ();
			} else if (other.gameObject.tag.Equals ("bomb")) { // If collides with bomb
				Instantiate (explosion)
					.GetComponent<Transform> ()
					.position = other.gameObject
						.GetComponent<Transform> ()
						.position;

				other.gameObject.
				GetComponent<BombController> ()
					.Reset ();

			} 
		}
	}
