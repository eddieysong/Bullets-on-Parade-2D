using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "EnemyShip", order = 1)]
public class EnemyShipConfigObject : ScriptableObject {
	
	public GameObject enemyShipPrefab;
	public float hp = 100;
	public EnemyWeaponConfigObject [] enemyWeaponConfig;
	public float speed;
	public Color thisColor = Color.white;
}