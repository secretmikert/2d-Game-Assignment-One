/***
 * Source File: GameController.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	//Public Variables
	[SerializeField]
	GameObject rocket; 
	[SerializeField]
	GameObject bomb;
	[SerializeField]
	GameObject masterBomb;
	[SerializeField]
	GameObject singleUseBomb;
	[SerializeField]
	GameObject plankShield;
	[SerializeField]
	GameObject plankShieldPowerUp;

	[SerializeField]
	GameObject coin;

    [SerializeField]
    Text lifeLabel;
    [SerializeField]
    Text scoreLabel;
    [SerializeField]
    Text gameOverLabel;
    [SerializeField]
    Button resetBtn;

   	/// <summary>
   	/// Initialize this instance.
   	/// </summary>
	private void initialize(){

		Player.Instance.Score = 0;
		Player.Instance.Life = 5;

		gameOverLabel.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);

		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);
		StartCoroutine ("AddRocket");
		StartCoroutine ("AddBomb");
		StartCoroutine ("AddMasterBomb");

		StartCoroutine ("AddCoin");
		StartCoroutine ("addVerticalPlankShieldPowerUp");
	}

	/// <summary>
	/// Called on game over to show canvas to user.
	/// </summary>
    public void gameOver(){
        gameOverLabel.gameObject.SetActive (true);
        resetBtn.gameObject.SetActive (true);

        lifeLabel.gameObject.SetActive (false);
        scoreLabel.gameObject.SetActive (false);
    }

	/// <summary>
	/// Updates the Score & Life UI
	/// </summary>
	public void updateUI(){

		scoreLabel.text = "Score: " + Player.Instance.Score;
		lifeLabel.text = "Life: " + Player.Instance.Life;
	}

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start () {
		Player.Instance.gameController = this;
	    initialize ();
	}
    
    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update () { }

	/// <summary>
	/// Restarts the. Restarts to game
	/// </summary>
    public void ResetBtnClick(){
	    
	        SceneManager.
	            LoadScene (
		                SceneManager.GetActiveScene ().name);
	    
	}

	/// <summary>
	/// Spawns 6 planks
	/// </summary>
	public void plankShieldActiviated() {
		for(int i = 0; i <= 5; i++) {
			Instantiate(plankShield);
		}
	}

	/// <summary>
	/// Adds a rocket each run.
	/// </summary>
	private IEnumerator addRocket() {
		int time = Random.Range (15, 25);
		yield return new WaitForSeconds ((float) time);
		Instantiate (rocket);
		StartCoroutine ("addRocket");
	}

	/// <summary>
	/// Adds a bomb each run.
	/// </summary>
	private IEnumerator AddBomb() {
		int time = Random.Range (5, 15);
		yield return new WaitForSeconds ((float) time);
		Instantiate (bomb);
		StartCoroutine ("addBomb");
	}

	/// <summary>
	/// Adds a Master Bomb each run.
	/// </summary>
	private IEnumerator addMasterBomb() {
		int time = Random.Range (10, 20);
		yield return new WaitForSeconds ((float) time);
		Instantiate (masterBomb);
		StartCoroutine ("addMasterBomb");
	}

	/// <summary>
	/// Spawns 26 single use bombs
	/// </summary>
	public void masterBombCollision() {
		for(int i = 0; i <= 25; i++) {
			Instantiate(singleUseBomb);
		}
	}

	/// <summary>
	/// Adds a coin each run.
	/// </summary>
	private IEnumerator addCoin() {
		int time = Random.Range (30, 50);
		yield return new WaitForSeconds ((float) time);
		Instantiate (coin);
		StartCoroutine ("addCoin");
	}

	/// <summary>
	/// Adds a plank shield power up each run.
	/// </summary>
	private IEnumerator addVerticalPlankShieldPowerUp() {
		int time = Random.Range (5, 15);
		yield return new WaitForSeconds ((float) time);
		Instantiate (plankShieldPowerUp);
		StartCoroutine ("addVerticalPlankShieldPowerUp");
	}

}
