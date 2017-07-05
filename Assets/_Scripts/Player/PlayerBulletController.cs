// Eddie Song 2017-06-27
// Script to handle player bullet behavior

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	private float damage = 10f;

	// handles to components
	private Rigidbody2D rb2d;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetDamage(float damage) {
		this.damage = damage;
	}

	// What happens when bullet collides with an enemy
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			Debug.Log ("Enemy Hit! " + Time.time);
			other.gameObject.SendMessage ("Hit", damage, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		} else if (other.CompareTag ("Boundary")) {
			Destroy (gameObject);
		}
	}

}
