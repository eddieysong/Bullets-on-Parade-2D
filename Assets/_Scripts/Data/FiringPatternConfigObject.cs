using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "FiringPattern", order = 3)]
public class FiringPatternConfigObject : ScriptableObject {
	public string objectName = "New FiringPatternConfigObject";
	public int firingPatternID = 0;
	public int numberOfShots = 1;
	public float bulletSpeed = 5f;
	public float fireDuration = 1f;
	public float startAngle, endAngle;
	public Color spriteColor = Color.white;

}