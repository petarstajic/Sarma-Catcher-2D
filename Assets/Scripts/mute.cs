using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour {

	 public void funkcija () {

		if (AudioListener.pause == true) {
			AudioListener.pause = false;
		} else if (AudioListener.pause == false) {
			AudioListener.pause = true;
		}


	}
}