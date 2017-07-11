// Eddie Song 2017-07-04
// Scriptable object to contain spawning patterns (waves)

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "SpawningPattern", order = 4)]
public class SpawningPatternConfigObject : ScriptableObject {
	
	public EnemyShipConfigObject enemyShipConfig;
	public int enemyCount;
	public float delayBetweenEnemies;
	public bool isMirror = false;
	public Vector2 startPoint, endPoint;
	public Vector2 destStartPoint, destEndPoint;
//	public Color spriteColor = Color.white;

}