using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "EnemyWeapon", order = 2)]
public class EnemyWeaponConfigObject : ScriptableObject {
	public string objectName = "New EnemyWeaponConfigObject";
	public int enemyWeaponID = 0;
	public GameObject bullet;
	public FiringPatternConfigObject firingPattern;
	public float fireRateMultiplier = 1f;
	public Color spriteColor = Color.white;
}