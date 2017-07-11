// Eddie Song 2017-07-04
// Scriptable object to contain enemy ship data (weapons, movement speed, etc)

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "EnemyShip", order = 1)]
public class EnemyShipConfigObject : ScriptableObject {
	
	public GameObject enemyShipPrefab;
	public float hp = 100;
	public EnemyWeaponConfigObject [] enemyWeaponConfig;
	public float speed;
	public Color thisColor = Color.white;
	public bool isBoss = false;
}