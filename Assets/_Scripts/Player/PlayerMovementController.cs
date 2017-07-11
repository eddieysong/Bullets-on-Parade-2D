// Eddie Song 2017-06-27
// Player Movement Controller script, handles player movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {


	// configurable properties of player ship
	[SerializeField]
	private float movespeed = 10f;
	private int lives = 3;
	private bool invulnerable = false;
	private float invulnerableTime = 2.5f;

	// configuration read from other scripts
	private Vector2 xRange, yRange;

	// handles to components
	private Rigidbody2D rb2d;
	[SerializeField]
	private GameObject playerHitSoundPackage;

	// handles to other controllers
	private UIController uiController;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		uiController = GameObject.Find ("Canvas").GetComponent<UIController> ();
		xRange = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().XRange;
		yRange = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().YRange;

		uiController.SendMessage ("RefreshLives", lives, SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {

		// Movement according to input axis
		rb2d.velocity = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * movespeed;
		// Clamp position of player ship so it doesn't go outside boundaries
		rb2d.position = new Vector2 (Mathf.Clamp (rb2d.position.x, xRange.x, xRange.y), Mathf.Clamp (rb2d.position.y, yRange.x, yRange.y));

	}

	void Hit () {
		if (!invulnerable)
		{
			lives--;
			StartCoroutine (TurnInvulnerable ());
			Destroy (Instantiate (playerHitSoundPackage, transform.position, Quaternion.identity), invulnerableTime);
			uiController.SendMessage ("RefreshLives", lives, SendMessageOptions.DontRequireReceiver);
			if (lives <= 0) {
				Debug.Log ("game over!");
				Destroy (gameObject);
			}
		}
	}

	IEnumerator TurnInvulnerable() {
		invulnerable = true;
		yield return new WaitForSeconds (invulnerableTime);
		invulnerable = false;
	}
}
