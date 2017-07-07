// Eddie Song 2017-06-27
// Script to handle enemy ship movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	// configurable properties of enemy
	[SerializeField]
	private float speed = 5f;
	private float hp = 100f;
	private float value = 1f;

	private bool isMirror = false;

	// handles to components
	private Rigidbody2D rb2d;

	// handles to other controllers
	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("Game Controller").GetComponent<GameController> ();
	}

	void Hit (float damage) {
		this.hp -= damage;
		if (hp <= 0) {
			Die ();
		}
	}

	void Die () {
		gameController.EnemyKilled (transform.position, 1f);
		Destroy (gameObject);
	}

	// Update is called once per frame
	public void SetDestination (Vector3 dest) {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = (dest - transform.position).normalized * speed;
	}

	public void LoadConfig (EnemyShipConfigObject enemyShipConfig) {
		this.hp = enemyShipConfig.hp;
		this.speed = enemyShipConfig.speed;
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

	public bool IsMirror {
		get {
			return this.isMirror;
		}
		set {
			isMirror = value;
		}
	}
}
