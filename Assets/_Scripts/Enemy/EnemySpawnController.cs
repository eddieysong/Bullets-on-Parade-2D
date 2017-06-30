// Eddie Song 2017-06-27
// Controls how a wave of enemies are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	[SerializeField]
	private GameObject enemyShipPrefab;

	[SerializeField]
	private EnemyShipConfigObject enemyShipConfig;

	[SerializeField]
	private int enemyCount;

	[SerializeField]
	private float delayBetweenEnemies;

	[SerializeField]
	private Vector2 startPoint, endPoint;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Coroutine that spawns a single enemy
	IEnumerator SpawnEnemy () {
		for (int i = 0; i <= enemyCount - 1; i++) {
			Instantiate (enemyShipPrefab, startPoint + (endPoint - startPoint) * i / (enemyCount - 1), Quaternion.identity).GetComponent<EnemyMovementController>().LoadConfig(enemyShipConfig);
			yield return new WaitForSeconds (delayBetweenEnemies);
		}
	}
}
