/***
 * Source File: Player.cs
 * Author: Samuel Benoit
 * Last Modified By: Samuel Benoit
 * Last Modified Date: Oct-18-2017
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	static private Player _instance;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	static public Player Instance{
		get{ 
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Player"/> class.
	/// </summary>
	private Player(){ }


	public GameController gameController;

	private int _score = 0;
	private int _life = 5;

	/// <summary>
	/// Gets or sets the score.
	/// </summary>
	public int Score{
		get{ return _score; }
		set{ 
			_score = value;
			//scoreLabel.text = "Score: " + _score;
			gameController.updateUI();
		}

	}

	/// <summary>
	/// Gets or sets the life.
	/// </summary>
	public int Life{
		get{ return _life; }
		set{ 
			_life = value;


			if (_life <= 0) {
				//game over
				gameController.gameOver();
			}else{
				//lifeLabel.text = "Life: " + _life;
				gameController.updateUI();
			}
		}
	}
}