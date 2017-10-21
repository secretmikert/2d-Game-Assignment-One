using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickController : MonoBehaviour {

	public void Start () {
		PlayerPrefs.SetInt ("HighScore", 0);
		SceneManager.LoadScene(0);
	}


	public void StartGame() {
		SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
