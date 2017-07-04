// Eddie Song 2017-06-27
// Controls how a wave of enemies are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	[SerializeField]
	private SpawningPatternConfigObject [] waves;

	[SerializeField]
	private float timeBetweenWaves;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Coroutine that spawns a single enemy
	IEnumerator SpawnEnemy () {
		foreach (SpawningPatternConfigObject wave in waves) {
			for (int i = 0; i < wave.enemyCount; i++) {
				GameObject newEnemy = Instantiate (wave.enemyShipConfig.enemyShipPrefab, wave.startPoint + (wave.endPoint - wave.startPoint) * i / Mathf.Max(1, wave.enemyCount - 1), Quaternion.identity);
				newEnemy.GetComponent<EnemyMovementController> ().LoadConfig (wave.enemyShipConfig);
				newEnemy.GetComponent<EnemyMovementController> ().SetDestination (wave.destStartPoint + (wave.destEndPoint - wave.destStartPoint) * i / Mathf.Max(1, wave.enemyCount - 1));
				EnemyWeaponController[] enemyWeaponControllers = newEnemy.GetComponentsInChildren<EnemyWeaponController> ();
				for(int j = 0; j < Mathf.Min(wave.enemyShipConfig.enemyWeaponConfig.Length, enemyWeaponControllers.Length); j ++) {
					Debug.Log ("xx" + j.ToString());
					if (wave.enemyShipConfig.enemyWeaponConfig [j] != null) {
						enemyWeaponControllers[j].LoadConfig (wave.enemyShipConfig.enemyWeaponConfig[j]);
					}
				}
				yield return new WaitForSeconds (wave.delayBetweenEnemies);
			}
			yield return new WaitForSeconds (timeBetweenWaves);
		}
	}
}
