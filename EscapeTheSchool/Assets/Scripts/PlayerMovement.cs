﻿using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour {
	public GameObject map;
	public float speed;             //Floating point variable to store the player's movement speed.
	private GameObject instantiatedObj;
	public GameObject exitB;
	public float ds;

	// Use this for initialization
	void Start()
	{
		speed = 12;
		ds = .5f;
	}

	void Update (){
		if (GameObject.Find ("exit") != null) {
			exitB = GameObject.Find ("exit");
			exitB.transform.position = new Vector3(36f,19f,0);
			exitB.transform.localScale = new Vector3( ds, ds, ds );
		}

		Scene currentScene = SceneManager.GetActiveScene ();
		float horizontalInput = Input.GetAxis ("Horizontal");
		transform.Translate (new Vector3 (1, 0, 0) * Time.deltaTime * speed * horizontalInput);
		float verticalInput = Input.GetAxis ("Vertical");
		transform.Translate (new Vector3 (0, 1, 0) * Time.deltaTime * speed * verticalInput);

		if (transform.position.x > 30f) {
			transform.position = new Vector3 (30f, transform.position.y, 0);
		} else if (transform.position.x < -25.5f) {
			transform.position = new Vector3 (-25.5f, transform.position.y, 0);
		}

		if(transform.position.y > 12f)
		{
			transform.position = new Vector3(transform.position.x, 12, 0);
		}
		else if (transform.position.y < -12f)
		{
			transform.position = new Vector3(transform.position.x, -12f, 0);
		}

		if (Input.GetKeyDown ("t") && currentScene.name != "Scene3Game1" && currentScene.name != "Scene5Game3") {

			openMap ();

		}

	}
	public void openMap(){
		if (GameObject.Find ("Map(Clone)") != null) {
			Destroy (instantiatedObj);
		} else {
			instantiatedObj = Instantiate (map, new Vector3 (170, 260, 0), Quaternion.identity);
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name.Equals ("QuestionMark")) {
			SceneManager.LoadScene ("Scene2Cut2");
		} else if (other.name.Equals ("CutSceneDoor")) {
			SceneManager.LoadScene ("Scene5Game3");

		} else if (other.name.Equals ("mapreopen1") || other.name.Equals ("mapreopen2")) {
			openMap ();
		} else if (other.name.Equals ("testSpawn") && GameObject.Find ("epoxy") == null) {
			SceneManager.LoadScene ("TestIntro");
		} 

	}

}