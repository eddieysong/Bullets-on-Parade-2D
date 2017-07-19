// Eddie Song 2017-07-10
// Script to handle boss enemy movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : EnemyMovementController {

//	// configurable properties of enemy
//	[SerializeField]
//	private float speed = 5f;
	[SerializeField]
	private float changeDirectionInterval = 5f;
//	private float hp = 100f;
//	private float value = 1f;
//
//	// handles to components
//	private Rigidbody2D rb2d;
//
//	// handles to other controllers
//	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("Game Controller").GetComponent<GameController> ();
		uiController = GameObject.Find ("UI Controller").GetComponent<UIController> ();
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (ChangeDirection());
		uiController.SendMessage ("ToggleBossHP", true, SendMessageOptions.DontRequireReceiver);
		uiController.SendMessage ("RefreshBossHP", 1f, SendMessageOptions.DontRequireReceiver);
	}

	new void Hit (float damage) {
		this.hp -= damage;
//		Debug.Log (string.Format("Enemy has {0} hp remaining", hp.ToString()));
		uiController.SendMessage ("RefreshBossHP", Mathf.Clamp(hp / maxHP, 0f, 1f), SendMessageOptions.DontRequireReceiver);

		if (hp <= 0) {
			Die ();
		}
	}

	void Die () {
		gameController.BossKilled (transform.position, 1f);
		uiController.SendMessage ("ToggleBossHP", false, SendMessageOptions.DontRequireReceiver);
		rb2d.velocity = new Vector2 (0, 0);
		StopAllCoroutines ();
		GetComponent<Collider2D> ().enabled = false;
		foreach (EnemyWeaponController weapon in GetComponentsInChildren<EnemyWeaponController>()) {
			weapon.StopAllCoroutines ();
			weapon.enabled = false;
		}
		Destroy (gameObject, 4f);
	}

	// Sets the ship to go toward a random Destination
	void SetRandomDestination () {
		// calculate new destination
		float newX = Random.Range(gameController.XRange.x, gameController.XRange.y);
		float newY = Random.Range(gameController.YRange.y, 0.33f * gameController.YRange.y);
		rb2d.velocity = (new Vector3(newX, newY, 0f) - transform.position).normalized * speed;
	}

	IEnumerator ChangeDirection() {
		while (hp > 0) {
			yield return new WaitForSeconds (changeDirectionInterval);
			SetRandomDestination ();
		}
	}

//	// Sets the enemy's movement destination
//	public void SetDestination (Vector3 dest) {
//		rb2d = GetComponent<Rigidbody2D> ();
//		rb2d.velocity = (dest - transform.position).normalized * speed;
//	}
//
//	public void LoadConfig (EnemyShipConfigObject enemyShipConfig) {
//		this.hp = enemyShipConfig.hp;
//		this.speed = enemyShipConfig.speed;
//		transform.Find ("Enemy Ship Sprite").GetComponent<SpriteRenderer> ().color = enemyShipConfig.thisColor;
//	}

	// What happens when enemy collides with something
//	new void OnTriggerEnter2D (Collider2D other) {
//		if (other.CompareTag ("Player")) {
////			Debug.Log ("Player Hit! " + Time.time);
////			//			Destroy (other.gameObject);
////			Destroy (gameObject);
//		}
//		else if (other.CompareTag ("Boundary")) {
//			Destroy (gameObject);
//
//		}
//	}
}
