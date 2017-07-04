﻿// Eddie Song 2017-06-27
// Script to handle enemy ship movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	// handles to components
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		// Movement according to input axis
		rb2d.velocity = new Vector2 (0, -1) * speed;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadConfig (EnemyShipConfigObject enemyShipConfig) {
		transform.Find ("Enemy Ship Sprite").GetComponent<SpriteRenderer> ().color = enemyShipConfig.thisColor;
	}

	// What happens when enemy collides with something
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("Player Hit! " + Time.time);
			//			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		else if (other.CompareTag ("Boundary")) {
			Destroy (gameObject);

		}
	}
}
