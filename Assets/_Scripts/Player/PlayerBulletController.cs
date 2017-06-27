using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	// handles to components
	private Rigidbody2D rb2d;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (0, speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// what happens when bullet collides with an enemy
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			Debug.Log ("Enemy Hit! " + Time.time);
		}
	}
}
