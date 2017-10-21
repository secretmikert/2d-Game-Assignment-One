/***
 * Source File: explosion.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	/// <summary>
	/// Destorys the explosion animation. 
	/// </summary>
	public void DestroyMe(){
		Destroy (gameObject);
	}
}
