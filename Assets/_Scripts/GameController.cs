// Eddie Song 2017-06-27
// Game Controller Script, contains general configurations of the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Vector2 xRange, yRange;

	// handles to prefabs
	[SerializeField]
	private GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnemyKilled (Vector2 enemyPos, float enemyValue) {
		Destroy (Instantiate (explosion, enemyPos, Quaternion.identity), 2f);
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
