using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "EnemyShip", order = 1)]
public class EnemyShipConfigObject : ScriptableObject {
	public string objectName = "New EnemyShipConfigObject";
	public int enemyShipID = 0;
//	public Sprite sprite;
	public Color thisColor = Color.white;
//	public Vector3[] spawnPoints;
}