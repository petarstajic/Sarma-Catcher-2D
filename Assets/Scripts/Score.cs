using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int bube;
	public Text scoreText;
	public Text totalText;
	public int ballValue;


	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		bube = 0;
		UpdateScore ();	
	}

	void OnTriggerEnter2D () {
		score += ballValue;
		UpdateScore ();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Buba") {
			score -= ballValue * 2;
			bube += 1;
			UpdateScore ();
		}
	}

	void UpdateScore () {
		scoreText.text = "Score:\n" + score;
		totalText.text = "Score: " + score;
		
	}


}
