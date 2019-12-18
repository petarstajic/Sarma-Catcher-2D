using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serpacontroller : MonoBehaviour {

	public Camera cam;
	public Rigidbody2D rb;
	public Renderer r;

	private float maxWidth;
	private bool canControl;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		r = GetComponent<Renderer> ();
		if (cam == null) {
			cam = Camera.main;
		}
		canControl = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatwidth = r.bounds.extents.x;
		maxWidth = targetWidth.x - hatwidth;
	}

	// Fixedupdate is called once per physics timestep -update for frame
	void FixedUpdate () {
		if (canControl) {
			Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, 0.5f, 0.0f);
			float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
			rb.transform.position = targetPosition;﻿

		}
	}
	public void ToggleControl (bool toggle) {
		canControl = toggle;
	}
}
