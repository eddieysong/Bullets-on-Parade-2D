﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "EnemyWeapon", order = 2)]
public class EnemyWeaponConfigObject : ScriptableObject {

	public GameObject bullet;
	public FiringPatternConfigObject firingPattern;
	public float delayBetweenFiring = 1f;
	public float fireRateMultiplier = 1f;
//	public Color spriteColor = Color.white;
}