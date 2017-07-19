// Eddie Song 2017-06-27
// Game Controller Script, contains general configurations of the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Vector2 xRange, yRange;

	// handles to prefabs
	[SerializeField]
	private GameObject explosion;

	// handles to other controllers
	private UIController uiController;

	// Use this for initialization
	void Start () {
		uiController = GameObject.Find ("UI Controller").GetComponent<UIController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnemyKilled (Vector2 enemyPos, float enemyValue) {
		Destroy (Instantiate (explosion, enemyPos, Quaternion.identity), 2f);
	}

	public void PlayerKilled (Vector2 playerPos) {
		Destroy (Instantiate (explosion, playerPos, Quaternion.identity), 2f);
		StartCoroutine (BackToMainMenu ());
	}

	public void BossKilled (Vector2 bossPos, float enemyValue) {
		StartCoroutine (BossExplosions (bossPos));
	}

	IEnumerator BossExplosions (Vector2 bossPos) {
		Vector2 randomOffset = new Vector2 ();
		for (int i = 0; i <= 20; i ++) {
			randomOffset = Random.insideUnitCircle * 5;
			Destroy (Instantiate (explosion, bossPos + randomOffset, Quaternion.identity), 2f);
			yield return new WaitForSeconds (0.2f);
		}
		yield return new WaitForSeconds (2.5f);
		uiController.SendMessage ("QueueMessages", new string [1] {"Mission Complete!\n" +
			"Well Done, Commander!"
		});
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("LevelComplete");
	}

	IEnumerator BackToMainMenu () {
		yield return new WaitForSeconds (2.5f);
		uiController.SendMessage ("QueueMessages", new string [1] {"Mission Failed\n" +
			"Returning to Main Menu"
		});
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("MainMenu");
	}

	// g/setters
	public Vector2 XRange {
		get {
			return this.xRange;
		}
	}

	public Vector2 YRange {
		get {
			return this.yRange;
		}
	}
}
