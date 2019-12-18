using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject[] balls;
	public float timeLeft;
	public float timeSpeed=0;
	public Text timerText;
	public GameObject gameOver;
	public GameObject resetButton;
	public GameObject Total;
	public GameObject sarma;
	public GameObject sarma1;
	public GameObject sarma2;
	public GameObject sarma3;
	public GameObject sarma4;
	public GameObject buba;
	public GameObject buba1;
	public GameObject buba2;
	public GameObject splashScreen;
	public GameObject startButton;
	public int sarme;
	public serpacontroller SerpaController;
	public Score score;
	public int brojac;


	private bool playing;
	private float maxWidth;



	// Use this for initialization
	void Start () {
		sarme = 0;
		brojac = 0;
		if (cam == null) {
			cam = Camera.main;
		}
		playing = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;

	}

	void FixedUpdate () {
		if (playing) {
			timeLeft -= Time.deltaTime;	
			timeSpeed += Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
	

		}
		brojac = score.bube; 
		if (brojac == 1) {
			buba.SetActive (false);
		}
		if (brojac == 2) {
			buba1.SetActive (false);
		}
		if (brojac == 3) {
			buba2.SetActive (false);
		}
	}

	public void StartGame () {
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		SerpaController.ToggleControl (true);
		StartCoroutine (Spawn ());
	}


	IEnumerator Spawn () {
		yield return new WaitForSeconds (2.0f);
		playing = true;
		while ( sarme < 5 & brojac < 3 ) {
			GameObject ball = balls [Random.Range (0, balls.Length)];
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (2.0f-(timeSpeed/100));


		}
		yield return new WaitForSeconds (0.6f);
		gameOver.SetActive (true);

		yield return new WaitForSeconds (0.6f);
		Total.SetActive (true);

		yield return new WaitForSeconds (0.6f);
		resetButton.SetActive (true);
	}




	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Sarma") {
			sarme += 1;


			if (sarme == 1) {
				sarma.SetActive (false);
			}
			if (sarme == 2) {
				sarma1.SetActive (false);
			}
			if (sarme == 3) {
				sarma2.SetActive (false);
			}
			if (sarme == 4) {
				sarma3.SetActive (false);
			}
			if (sarme == 5) {
				sarma4.SetActive (false);
			}

		}
	}


}

	

