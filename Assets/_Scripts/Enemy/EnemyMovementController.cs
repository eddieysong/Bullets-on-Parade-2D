// Eddie Song 2017-06-27
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
		
	}
	
	// Update is called once per frame
	public void SetDestination (Vector3 dest) {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = (dest - transform.position).normalized * speed;
	}

	public void LoadConfig (EnemyShipConfigObject enemyShipConfig) {
		speed = enemyShipConfig.speed;
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
