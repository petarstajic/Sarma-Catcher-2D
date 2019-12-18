using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

	public bool paused;

	void Start () {
		paused = false;
	}

	public void puaseFunkcija () {
			paused = !paused;


		if (paused) {
			Time.timeScale = 0;
		} else if (!paused) {
			Time.timeScale = 1;
		}
	}
}
