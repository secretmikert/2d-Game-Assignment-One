/***
 * Source File: PlayerCollision.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

		//Public to Unity
		[SerializeField]
	    GameController gameController;
		
	    private AudioSource _collisionSound;

		[SerializeField]
	    GameObject explosion;

	    /// <summary>
	    /// Start this instance.
	    /// </summary>
	    void Start () {
			_collisionSound = gameObject.GetComponent<AudioSource> ();
		}
	    
	    /// <summary>
	    /// Update this instance.
	    /// </summary>
	    void Update () { }

	    public void OnTriggerEnter2D(Collider2D other){

	       //Plays sound for every collision
		   if (_collisionSound != null) {
				_collisionSound.Play ();
		    }

		if (other.gameObject.tag.Equals ("rocket")) {
			Instantiate (explosion)
				.GetComponent<Transform> ()
				.position = other.gameObject
					.GetComponent<Transform> ()
					.position;

			other.gameObject.
			GetComponent<RocketController> ()
				.Reset ();
			Player.Instance.Life -= 1;
		} else if (other.gameObject.tag.Equals ("bomb")) {


			Debug.Log ("Collision bomb\n");

			Instantiate (explosion)
			                .GetComponent<Transform> ()
			                .position = other.gameObject
				                    .GetComponent<Transform> ()
				                    .position;

			other.gameObject.
			                GetComponent<BombController> ()
			                .Reset ();
			
			Player.Instance.Life -= 1;
		} else if (other.gameObject.tag.Equals ("coin")) {
			other.gameObject.
			GetComponent<CoinController> ()
				.Reset ();
			Player.Instance.Score += 10;
		} else if (other.gameObject.tag.Equals ("masterBomb")) {
			gameController.masterBombCollision ();
			Destroy (other.gameObject);
		} else if(other.gameObject.tag.Equals("singleUseBomb")) {
			Instantiate (explosion)
				.GetComponent<Transform> ()
				.position = other.gameObject
					.GetComponent<Transform> ()
					.position;

			Destroy (other.gameObject);
			Player.Instance.Life -= 1;
		} else if(other.gameObject.tag.Equals("plankShieldVerticalPowerUp")) {
			Destroy (other.gameObject);

			gameController.plankShieldActiviated();
		}
	}
}
