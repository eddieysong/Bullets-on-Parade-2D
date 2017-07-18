// Eddie Song 2017-06-27
// Script to handle enemy ship movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	// configurable properties of enemy
	[SerializeField]
	protected float speed = 5f;
	protected float hp = 100f;
	protected float maxHP = 100f;
	protected float value = 1f;

	protected bool isMirror = false;
	protected bool isBoss = false;


	// handles to components
	protected Rigidbody2D rb2d;

	// handles to other controllers
	protected GameController gameController;
	protected UIController uiController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("Game Controller").GetComponent<GameController> ();
		uiController = GameObject.Find ("UI Controller").GetComponent<UIController> ();
	}

	void Hit (float damage) {
		this.hp -= damage;
		Debug.Log (string.Format("Enemy has {0} hp remaining", hp.ToString()));
		if (hp <= 0) {
			Die ();
		}
	}

	void Die () {
		gameController.EnemyKilled (transform.position, 1f);
		Destroy (gameObject);
	}

	// Sets the enemy's movement destination
	public void SetDestination (Vector3 dest) {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = (dest - transform.position).normalized * speed;
	}

	public void LoadConfig (EnemyShipConfigObject enemyShipConfig) {
		this.hp = enemyShipConfig.hp;
		this.maxHP = enemyShipConfig.hp;
		this.speed = enemyShipConfig.speed;
		this.isBoss = enemyShipConfig.isBoss;
		transform.Find ("Enemy Ship Sprite").GetComponent<SpriteRenderer> ().color = enemyShipConfig.thisColor;
	}

	// What happens when enemy collides with something
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
//			Debug.Log ("Player Hit! " + Time.time);
//			//			Destroy (other.gameObject);
//			Destroy (gameObject);
		}
		else if (other.CompareTag ("Boundary")) {
			if (!isBoss) {
				Destroy (gameObject);
			}
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

	public bool IsBoss {
		get {
			return this.isBoss;
		}
	}
}
