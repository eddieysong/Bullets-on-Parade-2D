// Eddie Song 2017-06-27
// Player Movement Controller script, handles player movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {


	// configurable properties of player ship
	[SerializeField]
	private float movespeed = 10f;
	[SerializeField]
	private int lives = 5;
	private bool invulnerable = false;
	private float invulnerableTime = 2.5f;

	// configuration read from other scripts
	private Vector2 xRange, yRange;

	// handles to components
	private Rigidbody2D rb2d;
	private Animator anim;
	[SerializeField]
	private GameObject playerHitSoundPackage;

	// handles to other controllers
	private GameController gameController;
	private UIController uiController;
	private GameObject simulatedInfoCanvas;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		gameController = GameObject.Find ("Game Controller").GetComponent<GameController> ();
		uiController = GameObject.Find ("UI Controller").GetComponent<UIController> ();
		simulatedInfoCanvas = GameObject.Find ("Simulated Info Canvas");
		simulatedInfoCanvas.SetActive (false);
		xRange = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().XRange;
		yRange = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().YRange;

		uiController.SendMessage ("RefreshLives", lives, SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {

		// Movement according to input axis
		rb2d.velocity = new Vector2 (CnControls.CnInputManager.GetAxis("Horizontal"), CnControls.CnInputManager.GetAxis("Vertical")) * movespeed;
		// Clamp position of player ship so it doesn't go outside boundaries
		rb2d.position = new Vector2 (Mathf.Clamp (rb2d.position.x, xRange.x, xRange.y), Mathf.Clamp (rb2d.position.y, yRange.x, yRange.y));

	}

	void Hit () {
		if (!invulnerable)
		{
			lives--;
			uiController.SendMessage ("RefreshLives", lives, SendMessageOptions.DontRequireReceiver);

			if (lives <= 0) {
				gameController.PlayerKilled (transform.position);
				Destroy (gameObject);
				return;
			}

			StartCoroutine (TurnInvulnerable ());

		}
	}

	IEnumerator TurnInvulnerable() {
		Destroy (Instantiate (playerHitSoundPackage, transform.position, Quaternion.identity), invulnerableTime);

		invulnerable = true;
		anim.SetTrigger ("TransitionFlash");
		simulatedInfoCanvas.SetActive (true);
		yield return new WaitForSeconds (invulnerableTime);
		invulnerable = false;
		anim.SetTrigger ("TransitionNormal");
		simulatedInfoCanvas.SetActive (false);
	}
}
