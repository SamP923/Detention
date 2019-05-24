﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class S2PlayerAnimation : MonoBehaviour {
	public float movementSpeed = 8;
	// Use this for initialization
	public bool startAnim = false;
	// Use this for initialization
	void Start () {
		StartCoroutine(waiter());
	}

	IEnumerator waiter ()
	{
		yield return new WaitForSeconds(5);
		startAnim = true;

	}
	// Update is called once per frame
	void Update () {
		if (startAnim == true ){
		transform.Translate(new Vector3 (.85f, -1, 0) * movementSpeed * Time.deltaTime);

		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name.Equals("BlobEnemy")){
			SceneManager.LoadScene("Scene3Game1");
		}
	}
}
