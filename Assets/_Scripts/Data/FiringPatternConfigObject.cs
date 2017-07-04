using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "FiringPattern", order = 3)]
public class FiringPatternConfigObject : ScriptableObject {
	public string objectName = "New FiringPatternConfigObject";
	public int firingPatternID = 0;
	// each Vector3 contains: x = travel speed, y = rotation, z = delay after firing
	public Vector3[] bulletCycle;
	public Color spriteColor = Color.white;

}