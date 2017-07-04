using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "SpawningPattern", order = 4)]
public class SpawningPatternConfigObject : ScriptableObject {
	public EnemyShipConfigObject enemyShipConfig;
	public int enemyCount;
	public float delayBetweenEnemies;
	public Vector2 startPoint, endPoint;
	public Vector2 destStartPoint, destEndPoint;
	public Color spriteColor = Color.white;

}