// Eddie Song 2017-07-04
// Scriptable object to contain enemy firing pattern data

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "FiringPattern", order = 3)]
public class FiringPatternConfigObject : ScriptableObject {

	public bool isBurstFire = false;
	public int numberOfShots = 1;
	public float bulletSpeed = 5f;
	public float fireDuration = 1f;
	public float startAngle, endAngle;
//	public Color spriteColor = Color.white;

}