// Eddie Song 2017-06-27
// Controls how a wave of enemies are spawned

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	[SerializeField]
	private LevelWavesConfigObject wavesData;

	private float isMirror;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Coroutine that spawns a single enemy
	IEnumerator SpawnEnemy () {
		foreach (SpawningPatternConfigObject wave in wavesData.waves) {
			
			// if the wave should be spawned in "mirror" mode, then multiply the start and end positions by -1
			isMirror = wave.isMirror ? -1 : 1;

			for (int i = 0; i < wave.enemyCount; i++) {
				Vector2 spawnPoint = wave.startPoint + (wave.endPoint - wave.startPoint) * i / Mathf.Max(1, wave.enemyCount - 1);
				spawnPoint.x *= isMirror;

				GameObject newEnemy = Instantiate (wave.enemyShipConfig.enemyShipPrefab, spawnPoint, Quaternion.identity);
				newEnemy.GetComponent<EnemyMovementController> ().IsMirror = wave.isMirror;
				newEnemy.GetComponent<EnemyMovementController> ().LoadConfig (wave.enemyShipConfig);

				Vector2 destPoint = wave.destStartPoint + (wave.destEndPoint - wave.destStartPoint) * i / Mathf.Max(1, wave.enemyCount - 1);
				destPoint.x *= isMirror;

				newEnemy.GetComponent<EnemyMovementController> ().SetDestination (destPoint);
				EnemyWeaponController[] enemyWeaponControllers = newEnemy.GetComponentsInChildren<EnemyWeaponController> ();
				for(int j = 0; j < Mathf.Min(wave.enemyShipConfig.enemyWeaponConfig.Length, enemyWeaponControllers.Length); j ++) {
//					Debug.Log ("xx" + j.ToString());
					if (wave.enemyShipConfig.enemyWeaponConfig [j] != null) {
						enemyWeaponControllers[j].LoadConfig (wave.enemyShipConfig.enemyWeaponConfig[j]);
					}
				}
				yield return new WaitForSeconds (wave.delayBetweenEnemies);
			}
			yield return new WaitForSeconds (wavesData.delayBetweenWaves);
		}
	}
}
