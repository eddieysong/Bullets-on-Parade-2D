// Eddie Song 2017-07-04
// Script to handle enemy bullet behavior

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	// handles to components
	private Rigidbody2D rb2d;


	// Update is called once per frame
	void Update () {

	}

	// What happens when bullet collides with an enemy
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
//			Debug.Log ("Player Hit! " + Time.time);
			other.gameObject.SendMessage ("Hit", SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
		else if (other.CompareTag ("Boundary")) {
			Destroy (gameObject);

		}
	}
		
}
