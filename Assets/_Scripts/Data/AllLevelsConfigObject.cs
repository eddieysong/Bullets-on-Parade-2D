using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "AllLevels", order = 6)]
public class AllLevelsConfigObject : ScriptableObject {

	public LevelWavesConfigObject [] levels;
}