using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "LevelWaves", order = 5)]
public class LevelWavesConfigObject : ScriptableObject {
	
	public SpawningPatternConfigObject [] waves;
	public float delayBetweenWaves = 5f;
}