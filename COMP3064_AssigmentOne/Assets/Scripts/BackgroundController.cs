/***
 * Source File: BackgroundController.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

		//Public to Unity
	    [SerializeField]
	    private float speed;

	    private Transform _transform;
	    private Vector2 _currentPosition;

	    /// <summary>
	    /// Start this instance.
	    /// </summary>
	    void Start () {
		        _transform = gameObject.GetComponent<Transform>();
		        _currentPosition = _transform.position;
		        Reset ();
		    }
	    
	    /// <summary>
	    /// Update this instance.
	    /// </summary>
	    void Update () {
		        _currentPosition = _transform.position;

		        _currentPosition -= new Vector2 (speed, 0);
		        _transform.position = _currentPosition;

		        if (_currentPosition.x <= -10) {
			            Reset ();
			        }
		    }

		/// <summary>
		/// Reset this instance.
		/// </summary>
	    private void Reset(){
		    
		_currentPosition = new Vector2 (10f, 0);
		        _transform.position = _currentPosition;
		    }
}
